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
    public partial class Reverb_form : Form
    {
        double att_rate = 0.7;//リバーブのパラメータ
        double deley = 0.1;//リバーブのパラメータ
        int repeat_n = 10;//リバーブのパラメータ       
        Wave_ope wave;
        

        public Reverb_form(params Wave_ope[] arg)
        {
            InitializeComponent();
            this.wave = arg[0];//フォーム１からWave_opeインスタンスを取得
        }
        //パラメータの更新
        private void Reverb_form_Load(object sender, EventArgs e)
        {
            CreateSeries();
        }
        private void Att_rate_TextChanged(object sender, EventArgs e)
        {
            Set_Vlaues();
            CreateSeries();
        }
        //パラメータの更新
        private void Delay_Textbox_TextChanged(object sender, EventArgs e)
        {
            Set_Vlaues();
            CreateSeries();
        }
        //パラメータの更新
        private void Repeat_Textbox_TextChanged(object sender, EventArgs e)
        {
            Set_Vlaues();
            CreateSeries();
        }  
        //TextBoxの値からパラメータをセット
        private void Set_Vlaues()
        {
            bool att_enable, repeat_enable, delay_enable;
            att_enable = double.TryParse(Att_rate_Textbox.Text,out att_rate);//TextBoxの値をdoubleに変換できるか？          
            delay_enable = double.TryParse(Delay_Textbox.Text, out deley);//TextBoxの値をdoubleに変換できるか？
            repeat_enable = int.TryParse(Repeat_Textbox.Text, out repeat_n);//TextBoxの値をdoubleに変換できるか？
            if (!(att_enable && repeat_enable && delay_enable))
            {
                SetZero();           
            }
            if(!(0.0 < att_rate && att_rate <= 1.0))//１以下に制限
            {
                SetZero();            
            }
            if(!(0.0<deley && deley <= 1.0))//１秒以下に制限、特に理由なし
            {
                SetZero();             
            }
            if(!(0<repeat_n && repeat_n <= 30))//30以下に制限、特に理由なし
            {
                SetZero();           
            }           
        }
        //パラメータを全てゼロにセット
        private void SetZero()
        {
            att_rate = 0.0;
            deley = 0.0;
            repeat_n = 0;
        }
        //Seriesを作成、チャートに表示
        private void CreateSeries()
        {
            chart1.Series.RemoveAt(0);
            Series se = new Series();
            se.ChartType = SeriesChartType.Line;
            se.Name = "インパルス応答";
            double[] res_imp = wave.Create_Reverb_imp(att_rate, repeat_n, deley);//インパルス応答を作成
            int index;
            //インパルス応答のデータを追加
            for (int i = 0; i <= repeat_n; ++i)//インパルス応答の内、値がある数だけループ
            {
                //インパルス応答がある部分のindexだけデータを追加
                index = (int)(deley * i * wave.Sample_Per_Sec());
                se.Points.AddXY(index * wave.SampleT, res_imp[index]);
            }
            chart1.Series.Add(se);//チャートに表示
        }
        //Wave_opeオブジェクト渡し用でフォーム表示
        static public Wave_ope ShowDialog(Wave_ope wave)
        {
            Reverb_form f = new Reverb_form(wave);
            f.ShowDialog();
            //string receiveText = f.ReturnValue;
            f.Dispose();
            return wave;
        }
    }
}
