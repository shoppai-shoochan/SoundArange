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
    public partial class Ring_form : Form
    {
        double depth = 1.0;//リング変調のパラメータ
        int rate = 10;//リング変調のパラメータ
        Wave_ope wave;

        public Ring_form(Wave_ope arg)
        {
            InitializeComponent();
            wave = arg;    //フォーム１からWave_opeインスタンス取得
        }
       
        private void Ring_form_Load(object sender, EventArgs e)
        {
            CreateSeries();
        }
        //現在のパラメータでSeriesを作成、チャートに表示
        private void CreateSeries()
        {
            chart1.Series.RemoveAt(0);
            Series se = new Series();
            se.ChartType = SeriesChartType.Line;
            se.Name = "変調波";
            double amp;
            if(depth == 0)
            {
                amp = 1;
            }else
            {
                amp = depth;//depthが振幅の最大
            }
            chart1.ChartAreas[0].AxisY.Maximum = amp;//チャート表示範囲の設定
            chart1.ChartAreas[0].AxisY.Minimum = -amp;//チャート表示範囲の設定
            double[] mod_wave = wave.Create_Mod_Wave(depth, rate);//変調波作成
            //変調波のデータを追加
            for (int i = 0; i < wave.Sample_Per_Sec(); ++i)//１秒間のサンプル数だけループ
            {
                se.Points.AddXY(i * wave.SampleT, mod_wave[i]);
            }
            chart1.Series.Add(se);//チャートに表示
        }
        //パラメータのセット
        private void Set_Vlaues()
        {
            bool depth_enable, rate_enable;
            depth_enable = double.TryParse(Depth_Textbox.Text, out depth);//Textboxの値がdoubleに変換可能？
            rate_enable = int.TryParse(Rate_Textbox.Text, out rate);//Textboxの値がdoubleに変換可能?
            if (!(depth_enable && rate_enable))
            {
                Set_Zero();//パラメータはゼロ
            }
        }
        //パラメータをゼロにセット
        private void Set_Zero()
        {
            depth = 0.0;
            rate = 0;
        }  
        //パラメータ更新
        private void Depth_Textbox_TextChanged(object sender, EventArgs e)
        {
            Set_Vlaues();
            CreateSeries();
            System.Threading.Thread.Sleep(300);//入れないと例外が発生する。
        }
        //パラメータ更新
        private void Rate_Textbox_TextChanged(object sender, EventArgs e)
        {
            Set_Vlaues();
            CreateSeries();
            System.Threading.Thread.Sleep(300);//入れないと例外が発生する。
        }
        //Wave_opeインスタンス引き渡しでフォーム起動
        static public Wave_ope ShowDialog(Wave_ope wave)
        {
            Ring_form f = new Ring_form(wave);
            f.ShowDialog();
            f.Dispose();
            return wave;
        }

    }
}
