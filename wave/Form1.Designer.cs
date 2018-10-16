namespace wave
{
    partial class arangeSound
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.name = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.scaleX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.read_Bottun = new System.Windows.Forms.Button();
            this.write_Bottun = new System.Windows.Forms.Button();
            this.arange_Min = new System.Windows.Forms.TextBox();
            this.arange_Max = new System.Windows.Forms.TextBox();
            this.sound_Play_bottun = new System.Windows.Forms.Button();
            this.Reverb_button = new System.Windows.Forms.Button();
            this.LPF_button = new System.Windows.Forms.Button();
            this.Ring_bottun = new System.Windows.Forms.Button();
            this.Reset_data_button = new System.Windows.Forms.Button();
            this.Level_bottun = new System.Windows.Forms.Button();
            this.Level_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Information_bottun = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None;
            chartArea1.AxisX.MaximumAutoSize = 85F;
            chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea1.AxisX.ScaleView.Size = 8000D;
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.AxisX.Title = "sec";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1465, 266);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.chart1_AxisViewChanged);
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
            this.chart1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseUp);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(240, 586);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(239, 22);
            this.name.TabIndex = 1;
            this.name.Text = "パス付でファイル名を入力してください";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(503, 586);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "参照";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // scaleX
            // 
            this.scaleX.Location = new System.Drawing.Point(240, 766);
            this.scaleX.Name = "scaleX";
            this.scaleX.Size = new System.Drawing.Size(153, 22);
            this.scaleX.TabIndex = 3;
            this.scaleX.Text = "5";
            this.scaleX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.scaleX.TextChanged += new System.EventHandler(this.scaleX_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 773);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "秒間";
            // 
            // chart2
            // 
            this.chart2.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None;
            chartArea2.AxisX.ScaleView.Size = 8000D;
            chartArea2.AxisX.Title = "sec";
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Top;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(0, 266);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(1465, 300);
            this.chart2.TabIndex = 5;
            this.chart2.Text = "chart2";
            this.chart2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseDown);
            this.chart2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseUp);
            // 
            // read_Bottun
            // 
            this.read_Bottun.Location = new System.Drawing.Point(240, 630);
            this.read_Bottun.Name = "read_Bottun";
            this.read_Bottun.Size = new System.Drawing.Size(153, 41);
            this.read_Bottun.TabIndex = 6;
            this.read_Bottun.Text = "読み込み";
            this.read_Bottun.UseVisualStyleBackColor = true;
            this.read_Bottun.Click += new System.EventHandler(this.read_Bottun_Click);
            // 
            // write_Bottun
            // 
            this.write_Bottun.Location = new System.Drawing.Point(417, 630);
            this.write_Bottun.Name = "write_Bottun";
            this.write_Bottun.Size = new System.Drawing.Size(161, 41);
            this.write_Bottun.TabIndex = 7;
            this.write_Bottun.Text = "書き込み";
            this.write_Bottun.UseVisualStyleBackColor = true;
            this.write_Bottun.Click += new System.EventHandler(this.write_Bottun_Click);
            // 
            // arange_Min
            // 
            this.arange_Min.Location = new System.Drawing.Point(241, 727);
            this.arange_Min.Name = "arange_Min";
            this.arange_Min.Size = new System.Drawing.Size(153, 22);
            this.arange_Min.TabIndex = 8;
            this.arange_Min.Text = "0";
            this.arange_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // arange_Max
            // 
            this.arange_Max.Location = new System.Drawing.Point(417, 727);
            this.arange_Max.Name = "arange_Max";
            this.arange_Max.Size = new System.Drawing.Size(161, 22);
            this.arange_Max.TabIndex = 9;
            this.arange_Max.Text = "0";
            this.arange_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sound_Play_bottun
            // 
            this.sound_Play_bottun.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sound_Play_bottun.Location = new System.Drawing.Point(1280, 656);
            this.sound_Play_bottun.Name = "sound_Play_bottun";
            this.sound_Play_bottun.Size = new System.Drawing.Size(153, 56);
            this.sound_Play_bottun.TabIndex = 10;
            this.sound_Play_bottun.Text = "PLAY";
            this.sound_Play_bottun.UseVisualStyleBackColor = true;
            this.sound_Play_bottun.Click += new System.EventHandler(this.sound_Play_bottun_Click);
            // 
            // Reverb_button
            // 
            this.Reverb_button.Location = new System.Drawing.Point(1042, 619);
            this.Reverb_button.Name = "Reverb_button";
            this.Reverb_button.Size = new System.Drawing.Size(153, 23);
            this.Reverb_button.TabIndex = 11;
            this.Reverb_button.Text = "Reverb";
            this.Reverb_button.UseVisualStyleBackColor = true;
            this.Reverb_button.Click += new System.EventHandler(this.Reverb_button_Click);
            // 
            // LPF_button
            // 
            this.LPF_button.Location = new System.Drawing.Point(1042, 652);
            this.LPF_button.Name = "LPF_button";
            this.LPF_button.Size = new System.Drawing.Size(153, 23);
            this.LPF_button.TabIndex = 12;
            this.LPF_button.Text = "LPF";
            this.LPF_button.UseVisualStyleBackColor = true;
            this.LPF_button.Click += new System.EventHandler(this.LPF_button_Click);
            // 
            // Ring_bottun
            // 
            this.Ring_bottun.Location = new System.Drawing.Point(1042, 689);
            this.Ring_bottun.Name = "Ring_bottun";
            this.Ring_bottun.Size = new System.Drawing.Size(153, 23);
            this.Ring_bottun.TabIndex = 13;
            this.Ring_bottun.Text = "リング変調";
            this.Ring_bottun.UseVisualStyleBackColor = true;
            this.Ring_bottun.Click += new System.EventHandler(this.Ring_bottun_Click);
            // 
            // Reset_data_button
            // 
            this.Reset_data_button.Location = new System.Drawing.Point(1042, 734);
            this.Reset_data_button.Name = "Reset_data_button";
            this.Reset_data_button.Size = new System.Drawing.Size(153, 23);
            this.Reset_data_button.TabIndex = 14;
            this.Reset_data_button.Text = "Reset";
            this.Reset_data_button.UseVisualStyleBackColor = true;
            this.Reset_data_button.Click += new System.EventHandler(this.Reset_data_button_Click);
            // 
            // Level_bottun
            // 
            this.Level_bottun.Location = new System.Drawing.Point(1042, 581);
            this.Level_bottun.Name = "Level_bottun";
            this.Level_bottun.Size = new System.Drawing.Size(153, 23);
            this.Level_bottun.TabIndex = 15;
            this.Level_bottun.Text = "レベル変更";
            this.Level_bottun.UseVisualStyleBackColor = true;
            this.Level_bottun.Click += new System.EventHandler(this.Level_bottun_Click);
            // 
            // Level_TextBox
            // 
            this.Level_TextBox.Location = new System.Drawing.Point(860, 581);
            this.Level_TextBox.Name = "Level_TextBox";
            this.Level_TextBox.Size = new System.Drawing.Size(153, 22);
            this.Level_TextBox.TabIndex = 16;
            this.Level_TextBox.Text = "1.0";
            this.Level_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 593);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "waveファイル名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 769);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "波形の表示範囲";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(728, 586);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "音圧レベルを変更";
            // 
            // Information_bottun
            // 
            this.Information_bottun.Location = new System.Drawing.Point(1042, 773);
            this.Information_bottun.Name = "Information_bottun";
            this.Information_bottun.Size = new System.Drawing.Size(153, 23);
            this.Information_bottun.TabIndex = 18;
            this.Information_bottun.Text = "ファイル情報";
            this.Information_bottun.UseVisualStyleBackColor = true;
            this.Information_bottun.Click += new System.EventHandler(this.Information_bottun_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 734);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "編集範囲";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(237, 689);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(367, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "編集したい範囲を波形内でドラッグしてください";
            // 
            // arangeSound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 844);
            this.Controls.Add(this.Information_bottun);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Level_TextBox);
            this.Controls.Add(this.Level_bottun);
            this.Controls.Add(this.Reset_data_button);
            this.Controls.Add(this.Ring_bottun);
            this.Controls.Add(this.LPF_button);
            this.Controls.Add(this.Reverb_button);
            this.Controls.Add(this.sound_Play_bottun);
            this.Controls.Add(this.arange_Max);
            this.Controls.Add(this.arange_Min);
            this.Controls.Add(this.write_Bottun);
            this.Controls.Add(this.read_Bottun);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scaleX);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.chart1);
            this.Name = "arangeSound";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.arangeSound_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox scaleX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button read_Bottun;
        private System.Windows.Forms.Button write_Bottun;
        private System.Windows.Forms.TextBox arange_Min;
        private System.Windows.Forms.TextBox arange_Max;
        private System.Windows.Forms.Button sound_Play_bottun;
        private System.Windows.Forms.Button Reverb_button;
        private System.Windows.Forms.Button LPF_button;
        private System.Windows.Forms.Button Ring_bottun;
        private System.Windows.Forms.Button Reset_data_button;
        private System.Windows.Forms.Button Level_bottun;
        private System.Windows.Forms.TextBox Level_TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Information_bottun;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

