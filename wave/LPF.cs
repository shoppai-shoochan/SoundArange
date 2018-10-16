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
    public partial class LPF_form : Form
    {
        Wave_ope wave;
        int edge_frec = 1000;//LPFのパラメータ
        int trans_witdh = 500;//LPFのパラメータ

        public LPF_form(Wave_ope wave)
        {
            InitializeComponent();
            this.wave = wave;//フォーム１からWave_opeインスタンスを取得
        }

        private void LPF_form_Load(object sender, EventArgs e)
        {
            Create_Frec_Series();
        }
        //TextBoxからパラメータをセット
        void Set_Value()
        {
            bool edge_enable;
            bool trans_enable;
            edge_enable = int.TryParse(Frecency_Textbox.Text, out edge_frec);//TextBoxの値をintにできるか？
            trans_enable = int.TryParse(Bandwith_Textbox.Text, out trans_witdh);//TextBoxの値をintにできるか？
            if (!(edge_enable && trans_enable))
            {
                Set_Zero();
            }
        }
        //パラメータをゼロにセット
        void Set_Zero()
        {
            edge_frec = 0;
            trans_witdh = 0;
        }
        //パラメータの更新
        private void Frecency_Textbox_TextChanged(object sender, EventArgs e)
        {
            Set_Value();
            Create_Frec_Series();
        }
        //パラメータの更新
        private void Bandwith_Textbox_TextChanged(object sender, EventArgs e)
        {
            Set_Value();
            Create_Frec_Series();
        }
        //Seriesの作成、チャートに表示
        private void Create_Frec_Series()
        { 
            chart1.Series.RemoveAt(0);
            Series se = new Series();
            se.ChartType = SeriesChartType.Line;
            se.Name = "インパルス応答";
            double[] res_imp = wave.Create_LPF_Imp(edge_frec,trans_witdh);//インパルス応答を作成
            length_Textbox.Text = res_imp.Length.ToString();//インパルス応答の長さを表示        
            chart1.ChartAreas[0].AxisY.Maximum = res_imp.Max();//チャート表示の準備
            chart1.ChartAreas[0].AxisY.Minimum = res_imp.Min();//チャート表示準備
            chart1.ChartAreas[0].AxisX.Maximum = (double)((res_imp.Length - 1) * wave.SampleT);//チャート表示準備
            chart1.ChartAreas[0].AxisX.Minimum = 0;//チャート表示準備
            if (edge_frec == 0 && trans_witdh == 0)
            {
                chart1.ChartAreas[0].AxisY.Maximum = 1.0;//チャート表示の準備
                chart1.ChartAreas[0].AxisY.Minimum = 0.0;//チャート表示の準備
                chart1.ChartAreas[0].AxisX.Maximum = 1.0;//チャート表示の準備
                chart1.ChartAreas[0].AxisX.Minimum = 0;//チャート表示の準備
            }
            //インパルス応答データを追加
            for (int i = 0; i < res_imp.Length; ++i)//インパルス応答の数だけループ
            {
                se.Points.AddXY(i * wave.SampleT, res_imp[i]);
            }
            chart1.Series.Add(se);//チャートに表示
        }
        //Wave_opeオブジェクト引き渡しでフォーム起動
        static public Wave_ope ShowDialog(Wave_ope wave)
        {
            LPF_form f = new LPF_form(wave);
            f.ShowDialog();
            f.Dispose();
            return wave;
        }

    }
}
