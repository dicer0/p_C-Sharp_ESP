using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Se usa la librería System Numerics, agregada dando clic derecho en la parte de:
//Explorador de soluciones -> Referencias -> Agregar Referencia -> Nombre Librería.
using System.IO; //Librería utilizada para poder manipular archivos
using System.Windows.Forms.DataVisualization;

namespace _10._Graficación_Matricial_Múltiple
{
    public partial class Form1 : Form
    {
        //Variables de instancia de la clase
        int rows;
        int columns;
        double[,] data;

        public Form1()
        {
            InitializeComponent();
        }//Fin del constructor del GUI (Graphical User Interface) o Form.

        //Método que llena la matriz data con los datos leídos del archivo Excel.
        private void PopulateData(int rows, int columns, string[] lines)
        {
            string[] temp = new string[columns];
            data = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                temp = lines[i].Split(',', '\t');
                for (int j = 0; j < columns; j++)
                {
                    data[i, j] = Convert.ToDouble(temp[j]);
                }   //2do Bucle for.
            }   //1er Bucle for.

        }   //Fin del método PopulateData()

        /*Método que se emplea para obtener la transpuesta de la matriz de datos, Se debe obtener la transpuesta de los 
        datos extraídos porque siempre de los archivos de Excel estos son extraídos de forma vertical y los necesitamos 
        de forma horizontal para que puedan ser graficados con C#.*/
        private double[,] Transposed(int rows, int columns)
        {
            double[,] transposed;
            transposed = new double[columns, rows];
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    transposed[i, j] = data[j, i];
                }
            }
            return transposed;
        }   //Fin del método Transposed()

        //Método que se usa en la creación de la gráfica matricial múltiple.
        private void Plot(int row, int col)
        {
            double[,] transposed = Transposed(row, col);
            string seriesNum;
            double x;
            double y;
            for (int i = 1; i < col; i++)
            {
                //Creación dinámica de gráficas.
                seriesNum = "Series" + Convert.ToString(i);
                Plt_Data.Series.Add(seriesNum);
                Plt_Data.Series[seriesNum].ChartType =
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                for (int j = 0; j < row; j++)
                {
                    x = transposed[0, j];
                    y = transposed[i, j];
                    Plt_Data.Series[seriesNum].Points.AddXY(x, y);
                }
            }
        }   //Fin del método Plot()

        //Evento que se produce cuando se oprime el botón de Btn_ReadPlotData
        private void Btn_ReadPlotData_Click(object sender, EventArgs e)
        {
            //Código para abrir el archivo de Excel.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            //Uso de una ventana emergente que muestre el explorador de archivos para seleccionar el archivo Excel.
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string line;
                string[] saveLine = new string[0];
                string[] temp;
                Txt_display_data.Text = "";
                System.IO.Stream stream = openFileDialog.OpenFile();
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                {
                    //Bucle while que lee todas las líneas del archivo Excel hasta que no encuentre más caracteres
                    while ((line = reader.ReadLine()) != null)
                    {
                        Array.Resize(ref saveLine, saveLine.Length + 1);
                        saveLine[saveLine.Length - 1] = line;

                    }   //Bucle while
                }   //Instrucción using
                stream.Close();     //Close(): Método que sirve para cerrar el archivo abierto.

                /*Se asigna a la propiedad wordwrap un valor booleano False en la caja de texto para que se muestren las 
                dos barras de desplazamiento, y que así se puedan ver completamente los datos leídos del archivo Excel.*/
                //Bucle for para desplegar en la caja de texto Txt_DisplayData los datos recopilados del archivo Excel.
                for (int i = 0; i < saveLine.Length; i++)
                {
                    Txt_display_data.Text += saveLine[i] + "\r\n";
                }
                /*El método Split() se aplica a la primera línea leída de los datos provenientes del archivo Excel para así 
                generar un vector, cada elemento de este vector corresponde al valor de una columna.
                Con el método Length aplicado al vector temp, se proporciona el número de columnas del archivo.*/
                temp = saveLine[0].Split(',', '\t');
                columns = temp.Length;
                rows = saveLine.Length;
                //Se llena la matriz data con los datos recopilados.
                PopulateData(rows, columns, saveLine);
                Plt_Data.Series.Clear();    //Limpieza de la gráfica.
                Plot(rows, columns);        //Gráficación de los datos.
            }
        }   //Fin del método Btn_ReadPlotData_Click()
    }   //Fin de la clase Form del GUI
}   //Fin del namespace