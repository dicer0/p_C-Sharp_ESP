using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Se agrega una librería dando clic derecho en la parte de:
//Explorador de soluciones -> Referencias -> Agregar Referencia -> Nombre Librería.
using System.IO.Ports; //Puerto Serial
using System.Threading;
using System.IO;


namespace _14._Control_PID_de_Temperatura
{
    public partial class PID_Controller : Form
    {
        //Variables y objetos
        SerialPort serialPort;
        int period;             //Periodo de muestreo.
        int setPoint;           //Punto al que se quiere llegar con el controlador PID.
        int tT;                 //Tiempo total de operación.
        int ti = 1800;          //Tiempo integral (segundos).
        double td = 0.7;        //Tiempo derivativo.
        double t;               //tiempo (segundos).
        double[] time;          //Arreglo para todos los segundos del tiempo.
        double[] temperature;   //Arreglo para los datos de temperatura.
        double[] uPID;          //Arreglo para los datos u(t).
        double[] tH;            //Arreglo para el tiempo en alto.
        double[] tL;            //Arreglo para el tiempo en bajo.
        //SoftwareSerial(): Documentación de Arduino de las tasas de transferencia de datos por segundo.
        int baudRate = 19200;   //Tasa de transferencia de datos máxima del puerto serie del Arduino (bits por segundo).

        public PID_Controller()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Para ver los puertos disponibles
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                CB_SerialPort.Text = port;
            }
            Btn_Save.Visible = false;
        }//Método que se ejecuta cuando se inicializa el formulario de la interfaz gráfica GUI

        private bool initSerial()
        {
            bool value;     //Variable para ver si se ha realizado correctamente la conexión con el puerto serial.
            try
            {
                serialPort = new SerialPort(CB_SerialPort.Text);
                serialPort.BaudRate = baudRate; //Tasa de intercambio de datos del puerto serial.
                serialPort.WriteTimeout = 100;  //Tiempo de espera entre captura de datos de 100 milisegundos.
                value = true;
            }
            catch
            {
                value = false;
            }
            return value;
        }

        private async System.Threading.Tasks.Task GetDelay(int ms)
        {
            await System.Threading.Tasks.Task.Delay(ms);
        }//Get Delay

        //Evento que se ejecuta cuando se dá clic en el botón de Start.
        private async void Btn_Start_Click(object sender, EventArgs e)
        {
            Btn_Start.Visible = false;
            Btn_Save.Visible = false;

            bool statusBoard = false;
            string tdsString = "";

            statusBoard = initSerial();
            await GetDelay(1000);
            period = Convert.ToInt32(NUD_Period.Value);
            setPoint = Convert.ToInt32(NUD_SetPoint.Value);
            tT = Convert.ToInt32(NUD_tT.Value);

            tT *= 60;           //Conversión de tT (min) a segundos.
            if (td < 10)        //99.999 (s) es el valor máximo del tiempo derivativo.
            {
                tdsString = td.ToString("F3");
                tdsString = "0" + tdsString;
            }
            else
            {
                tdsString = td.ToString("F3");
            }
            string parameterMessage = "";
            //9999 es el valor máximo del periodo.
            parameterMessage += period.ToString("D4");
            //El valor máximo del set point es de 99 °C.
            parameterMessage += "," + setPoint.ToString("D2") + ",";
            parameterMessage += tT.ToString("D4") + "," + ti.ToString("D4");
            parameterMessage += "," + tdsString;
            Txt_Display_Values.Text = parameterMessage;

            bool continueSteps = false;

            if (statusBoard == true)
            {
                serialPort.Open();
                try
                {
                    for (int i = 0; i < 2; i++)
                    {
                        await GetDelay(2000);   //Delay de más tiempo.
                        serialPort.WriteLine(parameterMessage);
                        continueSteps = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Failed Communication");
                    continueSteps = false;
                }
            }
            if (continueSteps)
            {
                Plt_PID.Series.Clear();
                Plt_PID.Series.Add("Temperature");
                Plt_PID.Series["Temperature"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                Plt_PID.Series["Temperature"].BorderWidth = 3;
                Plt_PID.Series["Temperature"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
                Plt_PID.Series["Temperature"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                Plt_PID.Series["Temperature"].MarkerSize = 9;
                Plt_PID.Series["Temperature"].Color = Color.OrangeRed;

                time = new double[0];
                temperature = new double[0];
                uPID = new double[0];
                tH = new double[0];
                tL = new double[0];
                double timeRema;
                t = 0;
                int n = Convert.ToInt32(tT / (period / 1000.0));
                int count = 0;
                double u_temp = setPoint * 1.05;                    //Mismo valor que en el Arduino.
                Txt_UpperTemperature.Text = u_temp.ToString("F2");
                double l_temp = setPoint * 0.85;                    //Mismo valor que en el Arduino.
                Txt_LowerTemperature.Text = l_temp.ToString("F2");
                Txt_IntegralTime.Text = Convert.ToString(ti);       //Tiempo integral.
                Txt_DerivativeTime.Text = Convert.ToString(td);

                double u_max = (100.0 / (u_temp - l_temp)) * setPoint;
                Txt_UMax.Text = Convert.ToString(u_max);

                while (count < (n - 10))
                {
                    try
                    {
                        string data = serialPort.ReadLine();
                        string[] splitData = data.Split(new char[] { ',' });

                        if (splitData.Length == 5)
                        {
                            Txt_Display_Values.Text = data;
                            t = Convert.ToDouble(splitData[0]);
                            Array.Resize(ref time, time.Length + 1);
                            time[time.Length - 1] = t;

                            double tempTemp = Convert.ToDouble(splitData[1]);
                            Array.Resize(ref temperature, temperature.Length + 1);
                            temperature[temperature.Length - 1] = tempTemp;

                            double tempUPID = Convert.ToDouble(splitData[2]);
                            Array.Resize(ref uPID, uPID.Length + 1);
                            uPID[uPID.Length - 1] = tempUPID;

                            double temptH = Convert.ToDouble(splitData[3]);
                            Array.Resize(ref tH, tH.Length + 1);
                            tH[tH.Length - 1] = temptH;

                            double temptL = Convert.ToDouble(splitData[4]);
                            Array.Resize(ref tL, tL.Length + 1);
                            tL[tL.Length - 1] = temptL;

                            timeRema = tT - t;
                            Txt_RemainingTime.Text = Convert.ToString(timeRema);
                            Txt_Temperature.Text = Convert.ToString(tempTemp);
                            Txt_UPID.Text = Convert.ToString(tempUPID);
                            Txt_HighTime.Text = Convert.ToString(temptH);
                            Plt_PID.Series["Temperature"].Points.AddXY(t, tempTemp);
                        }
                    }
                    catch
                    {
                        //Do nothing
                    }
                    count++;
                    await GetDelay(period);
                    Btn_Start.Visible = true;
                    Btn_Save.Visible = true;
                }

                serialPort.DiscardInBuffer();
                serialPort.Close();
                MessageBox.Show("Job done.");

            }
        }

        /*StringDataArray: Método para generar un array de puros String donde en el primer elemento se ponga el valor del tiempo, 
        la temperatura, u(t), tiempo en alto th, tiempo en bajo tl, esto lo almacena en varias filas de los mismos datos, esto 
        para poder almacenarlo en un archivo*/
        private string[] StringDataArray(int samples)
        {
            string[] values = new string[samples + 1];
            values[0] = "Time (s), Temperature (C), u(t), tH (ms), tL (ms)";
            string tempStr = "";

            for (int i = 1; i < samples + 1; ++i)
            {
                tempStr = time[i - 1].ToString("F2") + "," + temperature[i - 1].ToString("F2") +
                    "," + uPID[i - 1].ToString("F2") + "," + tH[i - 1].ToString("F2") + "," +
                    tL[i - 1].ToString("F2");
                values[i] = tempStr;
            }
            return values;
        }//StringDataArray: Método para crear un array con los datos recopilados del controlador para poder almacenarlos después.

        //Evento que se ejecuta cuando se dá clic en el botón de Save.
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Btn_Start.Visible = false;
            Btn_Save.Visible = false;

            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] values = StringDataArray(time.Length);
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    using (StreamWriter writer = new StreamWriter(myStream))
                    {
                        for (int i = 0; i < values.Length; ++i)
                        {
                            writer.WriteLine(values[i]);
                        }
                    }
                    myStream.Close();
                }
            }
            Btn_Start.Visible = true;
            Btn_Save.Visible = true;
        }

        //Evento que se ejecuta cuando se dá clic en el botón de Exit.
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();   //Para cerrar la ventanita del GUI.
        }
    }
}