namespace wave
{
    partial class Reverb_form
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
            this.Att_rate_Textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Repeat_Textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OK_button = new System.Windows.Forms.Button();
            this.Delay_Textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // Att_rate_Textbox
            // 
            this.Att_rate_Textbox.Location = new System.Drawing.Point(120, 310);
            this.Att_rate_Textbox.Name = "Att_rate_Textbox";
            this.Att_rate_Textbox.Size = new System.Drawing.Size(100, 22);
            this.Att_rate_Textbox.TabIndex = 0;
            this.Att_rate_Textbox.Text = "0.5";
            this.Att_rate_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Att_rate_Textbox.TextChanged += new System.EventHandler(this.Att_rate_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "減衰率";
            // 
            // Repeat_Textbox
            // 
            this.Repeat_Textbox.Location = new System.Drawing.Point(404, 310);
            this.Repeat_Textbox.Name = "Repeat_Textbox";
            this.Repeat_Textbox.Size = new System.Drawing.Size(100, 22);
            this.Repeat_Textbox.TabIndex = 2;
            this.Repeat_Textbox.Text = "10";
            this.Repeat_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Repeat_Textbox.TextChanged += new System.EventHandler(this.Repeat_Textbox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "リピート数";
            // 
            // OK_button
            // 
            this.OK_button.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.OK_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_button.Location = new System.Drawing.Point(672, 399);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(75, 23);
            this.OK_button.TabIndex = 4;
            this.OK_button.Text = "OK";
            this.OK_button.UseVisualStyleBackColor = true;
            // 
            // Delay_Textbox
            // 
            this.Delay_Textbox.Location = new System.Drawing.Point(663, 310);
            this.Delay_Textbox.Name = "Delay_Textbox";
            this.Delay_Textbox.Size = new System.Drawing.Size(100, 22);
            this.Delay_Textbox.TabIndex = 6;
            this.Delay_Textbox.Text = "0.1";
            this.Delay_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Delay_Textbox.TextChanged += new System.EventHandler(this.Delay_Textbox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(565, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "ディレイ(sec)";
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
            this.chart1.Size = new System.Drawing.Size(800, 258);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // Reverb_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.Delay_Textbox);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Repeat_Textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Att_rate_Textbox);
            this.Name = "Reverb_form";
            this.Text = "Reverb_form";
            this.Load += new System.EventHandler(this.Reverb_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Att_rate_Textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Repeat_Textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.TextBox Delay_Textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}