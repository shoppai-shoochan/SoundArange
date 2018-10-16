namespace wave
{
    partial class Ring_form
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
            this.OK_button = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Depth_Textbox = new System.Windows.Forms.TextBox();
            this.Rate_Textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // OK_button
            // 
            this.OK_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_button.Location = new System.Drawing.Point(629, 401);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(75, 23);
            this.OK_button.TabIndex = 0;
            this.OK_button.Text = "OK";
            this.OK_button.UseVisualStyleBackColor = true;
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
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // Depth_Textbox
            // 
            this.Depth_Textbox.Location = new System.Drawing.Point(184, 325);
            this.Depth_Textbox.Name = "Depth_Textbox";
            this.Depth_Textbox.Size = new System.Drawing.Size(100, 22);
            this.Depth_Textbox.TabIndex = 3;
            this.Depth_Textbox.Text = "1.0";
            this.Depth_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Depth_Textbox.TextChanged += new System.EventHandler(this.Depth_Textbox_TextChanged);
            // 
            // Rate_Textbox
            // 
            this.Rate_Textbox.Location = new System.Drawing.Point(410, 325);
            this.Rate_Textbox.Name = "Rate_Textbox";
            this.Rate_Textbox.Size = new System.Drawing.Size(100, 22);
            this.Rate_Textbox.TabIndex = 4;
            this.Rate_Textbox.Text = "10";
            this.Rate_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Rate_Textbox.TextChanged += new System.EventHandler(this.Rate_Textbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "depth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "rate";
            // 
            // Ring_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rate_Textbox);
            this.Controls.Add(this.Depth_Textbox);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.OK_button);
            this.Name = "Ring_form";
            this.Text = "リング変調";
            this.Load += new System.EventHandler(this.Ring_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox Depth_Textbox;
        private System.Windows.Forms.TextBox Rate_Textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}