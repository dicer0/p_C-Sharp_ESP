﻿
namespace _10._Graficación_Matricial_Múltiple
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.Plt_Data = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Txt_display_data = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Plt_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Leer y graficar datos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Btn_ReadPlotData_Click);
            // 
            // Plt_Data
            // 
            chartArea1.Name = "ChartArea1";
            this.Plt_Data.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Plt_Data.Legends.Add(legend1);
            this.Plt_Data.Location = new System.Drawing.Point(351, 13);
            this.Plt_Data.Margin = new System.Windows.Forms.Padding(4);
            this.Plt_Data.Name = "Plt_Data";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Plt_Data.Series.Add(series1);
            this.Plt_Data.Size = new System.Drawing.Size(703, 528);
            this.Plt_Data.TabIndex = 1;
            this.Plt_Data.Text = "chart1";
            this.Plt_Data.Click += new System.EventHandler(this.Btn_ReadPlotData_Click);
            // 
            // Txt_display_data
            // 
            this.Txt_display_data.Location = new System.Drawing.Point(13, 74);
            this.Txt_display_data.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_display_data.Multiline = true;
            this.Txt_display_data.Name = "Txt_display_data";
            this.Txt_display_data.ReadOnly = true;
            this.Txt_display_data.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Txt_display_data.Size = new System.Drawing.Size(330, 467);
            this.Txt_display_data.TabIndex = 2;
            this.Txt_display_data.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.Txt_display_data);
            this.Controls.Add(this.Plt_Data);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.Btn_ReadPlotData_Click);
            ((System.ComponentModel.ISupportInitialize)(this.Plt_Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart Plt_Data;
        private System.Windows.Forms.TextBox Txt_display_data;
    }
}