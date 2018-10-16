namespace wave
{
    partial class LPF_form
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Frecency_Textbox = new System.Windows.Forms.TextBox();
            this.Bandwith_Textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OK_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.length_Textbox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(800, 319);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Frecency_Textbox
            // 
            this.Frecency_Textbox.Location = new System.Drawing.Point(144, 426);
            this.Frecency_Textbox.Name = "Frecency_Textbox";
            this.Frecency_Textbox.Size = new System.Drawing.Size(100, 22);
            this.Frecency_Textbox.TabIndex = 2;
            this.Frecency_Textbox.Text = "1000";
            this.Frecency_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Frecency_Textbox.TextChanged += new System.EventHandler(this.Frecency_Textbox_TextChanged);
            // 
            // Bandwith_Textbox
            // 
            this.Bandwith_Textbox.Location = new System.Drawing.Point(382, 426);
            this.Bandwith_Textbox.Name = "Bandwith_Textbox";
            this.Bandwith_Textbox.Size = new System.Drawing.Size(100, 22);
            this.Bandwith_Textbox.TabIndex = 3;
            this.Bandwith_Textbox.Text = "300";
            this.Bandwith_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Bandwith_Textbox.TextChanged += new System.EventHandler(this.Bandwith_Textbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "エッジ周波数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "遷移帯域幅";
            // 
            // OK_button
            // 
            this.OK_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_button.Location = new System.Drawing.Point(637, 488);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(75, 23);
            this.OK_button.TabIndex = 6;
            this.OK_button.Text = "OK";
            this.OK_button.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "周波数応答の長さ";
            // 
            // length_Textbox
            // 
            this.length_Textbox.AutoSize = true;
            this.length_Textbox.Location = new System.Drawing.Point(205, 352);
            this.length_Textbox.Name = "length_Textbox";
            this.length_Textbox.Size = new System.Drawing.Size(15, 15);
            this.length_Textbox.TabIndex = 8;
            this.length_Textbox.Text = "0";
            // 
            // LPF_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.length_Textbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Bandwith_Textbox);
            this.Controls.Add(this.Frecency_Textbox);
            this.Controls.Add(this.chart1);
            this.Name = "LPF_form";
            this.Text = "LPF_form";
            this.Load += new System.EventHandler(this.LPF_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox Frecency_Textbox;
        private System.Windows.Forms.TextBox Bandwith_Textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label length_Textbox;
    }
}