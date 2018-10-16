using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace wave
{
    public partial class arangeSound : Form
    {
        double x_range_mouse_down, x_range_mouse_up;//チャート内でマウスがアップダウンした場所の値を保存
        double y_range_mouse_down, y_range_mouse_up;//チャート内でマウスがアップダウンした場所の値を保存
        bool chart1_mouse_down_f = false;//チャート内でのマウスの状態フラグ、マウスがダウンしてればtrue
        bool chart2_mouse_down_f = false;//チャート内でのマウスの状態フラグ、マウスがダウンしてればtrue
        string read_filename;//読み込みファイル名
        string write_filename;//書き込みファイル名
        Wave_ope wave = new Wave_ope();//Wave_opeクラスのインスタンス、Wave_opeでファイルの編集等行う。
        
        //コンストラクタ
        public arangeSound()
        {
            InitializeComponent();
        }
        //パラメータの初期化
        private void arangeSound_Load(object sender, EventArgs e)
        {
            write_Bottun.Enabled = false;
            sound_Play_bottun.Enabled = false;
            Reverb_button.Enabled = false;
            LPF_button.Enabled = false;
            Ring_bottun.Enabled = false;
            Reset_data_button.Enabled = false;
            Information_bottun.Enabled = false;
            Level_bottun.Enabled = false;
            Create_Ano();
        }
        
        //---------チャート関係---------------
        //チャートにannotationを追加
        private void Create_Ano()
        {
            LineAnnotation ano1 = new LineAnnotation();
            LineAnnotation ano2 = new LineAnnotation();
            LineAnnotation ano3 = new LineAnnotation();
            LineAnnotation ano4 = new LineAnnotation();

            ano1.AxisX = chart1.ChartAreas[0].AxisX;
            ano2.AxisX = chart1.ChartAreas[0].AxisX;
            ano3.AxisX = chart2.ChartAreas[0].AxisX;
            ano4.AxisX = chart2.ChartAreas[0].AxisX;
            ano1.AxisY = chart1.ChartAreas[0].AxisY;
            ano2.AxisY = chart1.ChartAreas[0].AxisY;
            ano3.AxisY = chart2.ChartAreas[0].AxisY;
            ano4.AxisY = chart2.ChartAreas[0].AxisY;

            ano1.IsSizeAlwaysRelative = false;
            ano2.IsSizeAlwaysRelative = false;
            ano3.IsSizeAlwaysRelative = false;
            ano4.IsSizeAlwaysRelative = false;

            ano1.LineColor = Color.Red;
            ano2.LineColor = Color.Red;
            ano3.LineColor = Color.Red;
            ano4.LineColor = Color.Red;

            ano1.Name = "Line1";
            ano2.Name = "Line2";
            ano3.Name = "Line1";
            ano4.Name = "Line2";

            chart1.Annotations.Add(ano1);
            chart1.Annotations.Add(ano2);
            chart2.Annotations.Add(ano3);
            chart2.Annotations.Add(ano4);
        }
        //チャート表示範囲を更新
        private void scaleX_TextChanged(object sender, EventArgs e)
        {
            int size;
            if (int.TryParse(scaleX.Text, out size))//TextBoxの値を変換
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Size = size;//スクロールしないで表示される幅のセット
                chart2.ChartAreas[0].AxisX.ScaleView.Size = size;//スクロールしないで表示される幅のセット              
                chart1.ChartAreas[0].AxisX.Minimum = -size * 2;//チャート表示の最小値
                chart2.ChartAreas[0].AxisX.Minimum = -size * 2;//チャート表示の最小値
                chart1.ChartAreas[0].AxisX.Maximum = (double)((decimal)wave.Data_length * wave.SampleT + 1) + (2 * size);//チャート表示の最大値
                chart2.ChartAreas[0].AxisX.Maximum = (double)((decimal)wave.Data_length * wave.SampleT + 1) + (2 * size);//チャート表示の最大値
                chart1.ChartAreas[0].AxisX.Interval = 1;//補助線の間隔
                chart2.ChartAreas[0].AxisX.Interval = 1;//補助線の間隔                
            }
            
        }
        //Seriesを作成、チャートに表示
        private void Add_Series(double[] data, decimal unit, string se_name, int chart_n)
        {
            long inc;
            long plot_n = 50000;//プロット数の最大値
            long view_index_min, view_index_max;
            view_index_min = 0;
            view_index_max = data.Length;
            if(view_index_max - view_index_min > plot_n)
            {
                inc = (view_index_max - view_index_min) / plot_n;
            }
            else
            {
                inc = 1;
            }
            if (chart_n == 1)
            {
                Series se = new Series();
                se.ChartType = SeriesChartType.Line;
                se.Name = se_name;
                for (long i = view_index_min; i < view_index_max; i = i + inc)
                {
                    se.Points.AddXY(i * unit, data[i]);
                }
                chart1.Series.Add(se);
            }
            if (chart_n == 2)
            {
                Series se = new Series();
                se.ChartType = SeriesChartType.Line;
                se.Name = se_name;
                for (long i = view_index_min; i < view_index_max; i = i+inc)
                {
                    se.Points.AddXY(i * unit, data[i]);
                }
                chart2.Series.Add(se);
            }
        }
        //チャートの設定
        private void Chart_Setting(int chart_n)
        {

            if (chart_n == 1)
            {
                string series_name = "L";
                if (wave.Channel == 1) { series_name = "MONO"; }
                chart1.Series.RemoveAt(0);
                Add_Series(wave.Get_Data_Tmp1(), wave.SampleT, series_name, 1);
                chart1.ChartAreas[0].AxisX.ScaleView.Size = (double)((decimal)wave.Data_length * wave.SampleT + 1);
                chart1.ChartAreas[0].AxisX.Minimum = -1;
                chart1.ChartAreas[0].AxisX.Maximum = (double)((decimal)wave.Data_length * wave.SampleT + 1);
                chart1.ChartAreas[0].AxisX.Interval = 1;
            }
            if (chart_n == 2)
            {
                if (wave.Channel == 1)
                {
                    return;
                }
                chart2.Series.RemoveAt(0);
                Add_Series(wave.Get_Data_Tmp2(), wave.SampleT, "R", 2);
                chart2.ChartAreas[0].AxisX.ScaleView.Size = (double)((decimal)wave.Data_length * wave.SampleT + 1);
                chart2.ChartAreas[0].AxisX.Minimum = -1;
                chart2.ChartAreas[0].AxisX.Maximum = (double)((decimal)wave.Data_length * wave.SampleT + 1);
                chart2.ChartAreas[0].AxisX.Interval = 1;
            }
        }
  
        //---------編集範囲関係---------------
        //マウスダウンした場所の値の保存
        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            x_range_mouse_down = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);//マウスダウンした場所のチャート内における値を保存
            y_range_mouse_down = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);//マウスダウンした場所のチャート内における値を保存
            if (Check_In_Chart_Area(x_range_mouse_down, y_range_mouse_down,e,1))//値がチャートのグラフ領域内か？
            {
                chart1_mouse_down_f = true;
            }    
        }
        //マウスダウンした場所の値の保存
        private void chart2_MouseDown(object sender, MouseEventArgs e)
        {
            x_range_mouse_down = chart2.ChartAreas[0].AxisX.PixelPositionToValue(e.X);//マウスダウンした場所のチャート内における値を保存
            y_range_mouse_down = chart2.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);//マウスダウンした場所のチャート内における値を保存
            if (Check_In_Chart_Area(x_range_mouse_down, y_range_mouse_down, e, 2))//値がチャートのグラフ領域内か？
            {
                chart2_mouse_down_f = true;
            }
        }
        //マウスアップした場所の値を保存、チャートに編集範囲を表示
        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!(0<e.Y && e.Y<=100)) { return; }//例外対策
            x_range_mouse_up = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X); //x クライアント座標→x chart値
            y_range_mouse_up = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y); //y クライアント座標→y chart値
            if (Check_In_Chart_Area(x_range_mouse_up, y_range_mouse_up, e, 1))
            {
                if (chart1_mouse_down_f && x_range_mouse_down != x_range_mouse_up)//マウスがchart1内でダウンした状態でかつ、値が同じでない
                {
                    if (x_range_mouse_down > x_range_mouse_up)
                    {
                        double tmp = x_range_mouse_up;
                        x_range_mouse_up = x_range_mouse_down;
                        x_range_mouse_down = tmp;
                    }
                    wave.Set_arrange_range((decimal)x_range_mouse_down, (decimal)x_range_mouse_up);//編集範囲をwaveインスタンスにセット
                    arange_Min.Text = wave.Get_Arange_Min().ToString("F3");//編集範囲を表示
                    arange_Max.Text = wave.Get_Arange_Max().ToString("F3");//編集範囲を表示
                    sound_Play_bottun.Enabled = wave.Arange_enable;
                    Drow_Line(1);
                    Drow_Line(2);
                }
            }
            chart1_mouse_down_f = false;
        }
        //マウスアップした場所の値を保存、チャートに編集範囲を表示
        private void chart2_MouseUp(object sender, MouseEventArgs e)
        {
            if(!(0 < e.Y && e.Y <= 100)) { return; }//例外対策
            x_range_mouse_up = chart2.ChartAreas[0].AxisX.PixelPositionToValue(e.X); //x クライアント座標→x chart値
            y_range_mouse_up = chart2.ChartAreas[0].AxisY.PixelPositionToValue(e.Y); //y クライアント座標→y chart値
            if (Check_In_Chart_Area(x_range_mouse_up, y_range_mouse_up, e, 2))
            {
                if (chart2_mouse_down_f && x_range_mouse_down != x_range_mouse_up)
                {
                    if (x_range_mouse_down > x_range_mouse_up)
                    {
                        double tmp = x_range_mouse_up;
                        x_range_mouse_up = x_range_mouse_down;
                        x_range_mouse_down = tmp;
                    }
                    wave.Set_arrange_range((decimal)x_range_mouse_down, (decimal)x_range_mouse_up);
                    arange_Min.Text = wave.Get_Arange_Min().ToString("F3");
                    arange_Max.Text = wave.Get_Arange_Max().ToString("F3");
                    sound_Play_bottun.Enabled = wave.Arange_enable;
                    Drow_Line(1);
                    Drow_Line(2);
                }
            }

            chart2_mouse_down_f = false;
        }
        //値がチャートのグラフ領域内か判定
        private bool Check_In_Chart_Area(double x, double y, MouseEventArgs e, int chart_n)
        {
            if (chart_n == 1)
            {
                //現在のチャート表示領域内の最小値と最大値を取得
                double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double yMax = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
                double yMin = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                return xMin < x && x < xMax && yMin < y && y < yMax;
            }
            if (chart_n == 2)
            {
                double xMax = chart2.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double xMin = chart2.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double yMax = chart2.ChartAreas[0].AxisY.ScaleView.ViewMaximum;
                double yMin = chart2.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                return xMin < x && x < xMax && yMin < y && y < yMax;
            }
            return false;
        }
        //編集範囲を線で表示
        private void Drow_Line(int chart_n)
        {
            if (chart_n == 1)
            {
                //編集範囲の最小値のx座標に縦に線を入れる
                chart1.Annotations[0].X = (double)wave.Get_Arange_Min();//編集範囲の最小値
                chart1.Annotations[0].Y = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                chart1.Annotations[0].Width = 0;
                chart1.Annotations[0].Height = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum - chart1.Annotations[0].Y;
                //編集範囲の最大値のx座標に縦に線を入れる
                chart1.Annotations[1].X = (double)wave.Get_Arange_Max();//編集範囲の最大値           
                chart1.Annotations[1].Y = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                chart1.Annotations[1].Width = 0;
                chart1.Annotations[1].Height = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum - chart1.Annotations[1].Y;
            }
            else if (chart_n == 2)
            {
                //編集範囲の最小値のx座標に縦に線を入れる
                chart2.Annotations[0].X = (double)wave.Get_Arange_Min();//編集範囲の最小値
                chart2.Annotations[0].Y = chart2.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                chart2.Annotations[0].Width = 0;
                chart2.Annotations[0].Height = chart2.ChartAreas[0].AxisY.ScaleView.ViewMaximum - chart2.Annotations[0].Y;
                //編集範囲の最大値のx座標に縦に線を入れる
                chart2.Annotations[1].X = (double)wave.Get_Arange_Max();//編集範囲の最大値
                chart2.Annotations[1].Y = chart2.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                chart2.Annotations[1].Width = 0;
                chart2.Annotations[1].Height = chart2.ChartAreas[0].AxisY.ScaleView.ViewMaximum - chart2.Annotations[1].Y;
            }
        }

        //-----------ファイル入出力関係
        //Waveファイル名を取得
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_dialog = new OpenFileDialog();
            file_dialog.Filter = "waveファイル(*.wav)|*.wav";
            file_dialog.FilterIndex = 1;
            file_dialog.RestoreDirectory = true;
            file_dialog.CheckFileExists = false;
            file_dialog.Title = "WAVEファイルを選択してください";
            file_dialog.RestoreDirectory = true;
            if (file_dialog.ShowDialog() == DialogResult.OK)
            {
                name.Text = file_dialog.FileName;
            }
        }
        //ファイル書き込み
        private void write_Bottun_Click(object sender, EventArgs e)
        {
            write_filename = name.Text;
            if(write_filename == read_filename)
            {
                MessageBox.Show("元のファイル名とは違う名前に変更して下さい。");
                name.Text = null;               
            }
            else
            {
                wave.Write_file(write_filename);
                MessageBox.Show("ファイルを作成しました。");
            }
        }
        //ファイル読み込み
        private void read_Bottun_Click(object sender, EventArgs e)
        {
            if (name.Text != null)
            {
                if (wave.Read_File(name.Text))//読み込み成功?
                {                  
                    Chart_Setting(1);
                    Chart_Setting(2);                  
                    read_filename = name.Text;
                    write_Bottun.Enabled = true;//ボタンを有効
                    sound_Play_bottun.Enabled = true;//ボタンを有効
                    Reverb_button.Enabled = true;//ボタンを有効
                    LPF_button.Enabled = true;//ボタンを有効
                    Ring_bottun.Enabled = true;//ボタンを有効
                    Reset_data_button.Enabled = true;//ボタンを有効
                    Information_bottun.Enabled = true;//ボタンを有効
                    Level_bottun.Enabled = true;//ボタンを有効
                }
            }
        }


        //--------音声処理ボタン関係-----------
        //音声情報表示
        private void Information_bottun_Click(object sender, EventArgs e)
        {
            wave.File_Information();
        }
        //音声再生
        private void sound_Play_bottun_Click(object sender, EventArgs e)
        {
            if (wave.Player != null)
            {
                wave.Sound_Stop();
                sound_Play_bottun.Text = "PLAY";
            }
            else
            {
                wave.Sound_Play();
                sound_Play_bottun.Text = "STOP";
            }
        }        
        //編集データをリセット
        private void Reset_data_button_Click(object sender, EventArgs e)
        {
            if (wave.Read_success)
            {
                wave.Reset_Data();//元データの値に戻す
                Chart_Setting(1);//チャート更新
                Chart_Setting(2);//チャート更新
            }

        }
        //レベル変更
        private void Level_bottun_Click(object sender, EventArgs e)
        {
            if (wave.Arange_enable)
            {
                double level;
                if (double.TryParse(Level_TextBox.Text, out level))//Textboxの値をdoubleに変換
                {
                    wave.Level_Change(level);
                }
                Chart_Setting(1);//チャート更新
                Chart_Setting(2);//チャート更新
            }
            else
            {
                MessageBox.Show("編集範囲が選択されていません");
            }
        }
        //リング変調フォーム起動、リング変調処理
        private void Ring_bottun_Click(object sender, EventArgs e)
        {
            if (wave.Arange_enable) 
            {
                wave = Ring_form.ShowDialog(wave);//フォーム起動
                wave.Ring_Mod();//リング変調処理
                Chart_Setting(1);//チャートを更新
                Chart_Setting(2);//チャートを更新
            }
            else
            {
                MessageBox.Show("編集範囲が選択されていません");
            }
            
        }

        private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
        {
            //Chart_Setting(1);
            //Chart_Setting(2);
        }

        //リバーブフォーム起動、リバーブ処理
        private void Reverb_button_Click(object sender, EventArgs e)
        {
            if (wave.Arange_enable)
            {
                wave = Reverb_form.ShowDialog(wave);//フォーム起動
                wave.Reverb();//リバーブ処理
                Chart_Setting(1);//チャートを更新
                Chart_Setting(2);//チャートを更新
            }
            else
            {
                MessageBox.Show("編集範囲が選択されていません");
            }
        }
        //LPFフォーム起動、LPF処理
        private void LPF_button_Click(object sender, EventArgs e)
        {
            if (wave.Arange_enable)
            {
                wave = LPF_form.ShowDialog(wave); //フォーム起動
                wave.LPF();//LPF処理
                Chart_Setting(1);//チャートを更新
                Chart_Setting(2);//チャートを更新
            }
            else
            {
                MessageBox.Show("編集範囲が選択されていません。");
            }
        }

    }


    
}
