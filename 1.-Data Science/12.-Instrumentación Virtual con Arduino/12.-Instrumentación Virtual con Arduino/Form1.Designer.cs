
namespace _12._Instrumentación_Virtual_con_Arduino
{
    partial class Frm_Arduino
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.Lbl_Port = new System.Windows.Forms.Label();
            this.Lbl_Samples = new System.Windows.Forms.Label();
            this.NUD_Samples = new System.Windows.Forms.NumericUpDown();
            this.CB_Port = new System.Windows.Forms.ComboBox();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Btn_Stop = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Plt_Data = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Samples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Plt_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Port
            // 
            this.Lbl_Port.AutoSize = true;
            this.Lbl_Port.Location = new System.Drawing.Point(63, 51);
            this.Lbl_Port.Name = "Lbl_Port";
            this.Lbl_Port.Size = new System.Drawing.Size(41, 13);
            this.Lbl_Port.TabIndex = 0;
            this.Lbl_Port.Text = "Puerto:";
            // 
            // Lbl_Samples
            // 
            this.Lbl_Samples.AutoSize = true;
            this.Lbl_Samples.Location = new System.Drawing.Point(63, 113);
            this.Lbl_Samples.Name = "Lbl_Samples";
            this.Lbl_Samples.Size = new System.Drawing.Size(53, 13);
            this.Lbl_Samples.TabIndex = 1;
            this.Lbl_Samples.Text = "Muestras:";
            // 
            // NUD_Samples
            // 
            this.NUD_Samples.Location = new System.Drawing.Point(66, 129);
            this.NUD_Samples.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Samples.Name = "NUD_Samples";
            this.NUD_Samples.Size = new System.Drawing.Size(120, 20);
            this.NUD_Samples.TabIndex = 2;
            this.NUD_Samples.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUD_Samples.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CB_Port
            // 
            this.CB_Port.FormattingEnabled = true;
            this.CB_Port.Location = new System.Drawing.Point(66, 67);
            this.CB_Port.Name = "CB_Port";
            this.CB_Port.Size = new System.Drawing.Size(121, 21);
            this.CB_Port.TabIndex = 3;
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(66, 190);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(105, 63);
            this.Btn_Start.TabIndex = 4;
            this.Btn_Start.Text = "Inicio";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Location = new System.Drawing.Point(66, 190);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(105, 63);
            this.Btn_Stop.TabIndex = 5;
            this.Btn_Stop.Text = "Paro";
            this.Btn_Stop.UseVisualStyleBackColor = true;
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(66, 259);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(105, 63);
            this.Btn_Save.TabIndex = 6;
            this.Btn_Save.Text = "Guardar";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Plt_Data
            // 
            chartArea2.Name = "ChartArea1";
            this.Plt_Data.ChartAreas.Add(chartArea2);
            this.Plt_Data.Location = new System.Drawing.Point(273, 51);
            this.Plt_Data.Name = "Plt_Data";
            this.Plt_Data.Size = new System.Drawing.Size(454, 340);
            this.Plt_Data.TabIndex = 7;
            this.Plt_Data.Text = "chart1";
            // 
            // Frm_Arduino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Plt_Data);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Btn_Stop);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.CB_Port);
            this.Controls.Add(this.NUD_Samples);
            this.Controls.Add(this.Lbl_Samples);
            this.Controls.Add(this.Lbl_Port);
            this.Name = "Frm_Arduino";
            this.Text = "SPM Arduino";
            this.Load += new System.EventHandler(this.Frm_Arduino_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Samples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Plt_Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Port;
        private System.Windows.Forms.Label Lbl_Samples;
        private System.Windows.Forms.NumericUpDown NUD_Samples;
        private System.Windows.Forms.ComboBox CB_Port;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.Button Btn_Stop;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.DataVisualization.Charting.Chart Plt_Data;
    }
}