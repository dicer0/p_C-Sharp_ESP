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
using System.IO; //Manejo de archivos


namespace _12._Instrumentación_Virtual_con_Arduino
{
    public partial class Frm_Arduino : Form
    {
        //Variables de instancia
        SerialPort serialPort; //Objeto para puerto serial
        int m = 0;//Numero de muestras
        bool stopAcquisition = false; //Bandera de estado de muestreo
        string[] dataStr = new string[0]; //Datos hacia archivo

        public Frm_Arduino()
        {
            InitializeComponent();
        }

        private void Frm_Arduino_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();//Leyendo los nombres de los puertos
            foreach (string port in ports)
            {
                CB_Port.Text = port;//Asiga los nombres de los puerto serial al combobox
            }
            Btn_Save.Visible = false;
            Btn_Start.Visible = true;
            Btn_Stop.Visible = false;
        }
        //Iniciando el puerto serial
        private bool InitSer()
        {
            bool result = false;
            try
            {
                serialPort = new SerialPort(CB_Port.Text);//Establece conexión con el arduino
                serialPort.BaudRate = 9600; //Tasa de transferencia
                serialPort.WriteTimeout = 100;//Retraso de 100ms
                result = true;
            }
            catch
            {
                MessageBox.Show("Fallo la conexion a la placa");
                result = false;
            }
            return result;
        }

        private async System.Threading.Tasks.Task GetDelay(int ms)
        {
            await System.Threading.Tasks.Task.Delay(ms);
        }//Delay

        private async void Btn_Start_Click(object sender, EventArgs e)//Click sobre el boton start
        {
            Btn_Start.Visible = false;//Ocultando botones
            Btn_Save.Visible = false;//
            bool statusPort = false;//Estado del puerto
            int period = 500;//Delay
            double time = 0;//
            dataStr = new string[0];//Inicializando la variable
            int samples = Convert.ToInt16(NUD_Samples.Value);//Obteniendo el numero de muestras
            m = 0;//Inicializando numero de muestras
            stopAcquisition = false;//Bandera de adquisión
            Plt_Data.Series.Clear();//Inicializando grafica
            Plt_Data.Series.Add("xy");
            Plt_Data.Series["xy"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Plt_Data.Series["xy"].BorderWidth = 3;
            Plt_Data.Series["xy"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            Plt_Data.Series["xy"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            Plt_Data.Series["xy"].MarkerSize = 9;
            Plt_Data.Series["xy"].Color = Color.OrangeRed;
            statusPort = InitSer();
            await GetDelay(2000);
            if (statusPort == true)
            {
                serialPort.Open();
                serialPort.DiscardInBuffer();
                await GetDelay(1000);
                string data = "";
                double value = 0;
                int fail = 0;
                time = 0;
                for (int i = 0; i < samples; i++)
                {
                    if (i == 0)
                    {
                        Btn_Stop.Visible = true;
                    }
                    try
                    {
                        data = serialPort.ReadLine();
                        value = Convert.ToDouble(data) * (5.0 / 1023);
                        Plt_Data.Series["xy"].Points.AddXY(time, value);
                        Array.Resize(ref dataStr, dataStr.Length + 1);
                        dataStr[dataStr.Length - 1] = Convert.ToString(time) + "," + value.ToString("F4");//Dato flotante 4 digitos
                        m++;
                    }
                    catch
                    {
                        fail++;
                    }
                    if (stopAcquisition == true)
                    {
                        break;
                    }
                    time = time + (period / 1000.0);
                    await GetDelay(period);
                }
                serialPort.Close();
            }
            await GetDelay(1000);
            Btn_Stop.Visible = false;
            Btn_Start.Visible = true;
            Btn_Save.Visible = true;
        }

        private async void Btn_Stop_Click(object sender, EventArgs e)
        {
            stopAcquisition = true;
            Btn_Stop.Visible = false;
            Btn_Start.Visible = false;
            Btn_Save.Visible = false;
            await GetDelay(1000);
            Btn_Start.Visible = true;
            Btn_Save.Visible = true;
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Btn_Start.Visible = false;
            Btn_Save.Visible = false;
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    using (StreamWriter writer = new StreamWriter(myStream))
                    {
                        for (int i = 0; i < dataStr.Length; i++)
                        {
                            writer.WriteLine(dataStr[i]);
                        }
                    }
                    myStream.Close();
                }
            }
            Btn_Start.Visible = true;
            Btn_Save.Visible = true;
        }
    }
}