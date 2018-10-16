using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wave
{
    public class Wave_ope
    {
        
        //waveファイル読み取り用変数
        //------------------------------
        private char[] riff_chunk_ID = new char[4];
        private uint riff_chunk_size = 0;
        private char[] riff_form_type = new char[4];
        private char[] fmt_chunk_ID = new char[4];
        private uint fmt_chunk_size = 0;
        private ushort fmt_wave_format_type = 0;
        private ushort fmt_channel = 0;     
        private uint fmt_sample_per_sec;
        private uint fmt_bytes_per_sec;
        private ushort fmt_block_size;
        private ushort fmt_bits_per_sample;
        private char[] data_chunk_ID = new char[4];
        private uint data_chunk_size;  
        private double[] data_LEFT,data_RIGHT,data_MONO;//編集内容リセット用のバックアップ
        private double[] data_tmp1, data_tmp2;//編集、書き込みまで全てこちらの変数で行う。

        //---------ファイル情報用----------------
        public int Channel
        {
            get
            {
                return fmt_channel;
            }
        }//fmt_channelのゲッター
        public uint Sample_Per_Sec()
        {
            return fmt_sample_per_sec;
        }   //fmt_sample_per_secのゲッター
        public double[] Get_Data_Tmp1()
        {
            return data_tmp1;
        }//data_tmp1のゲッター
        public double[] Get_Data_Tmp2()
        {
            return data_tmp2;
        }//data_tmp2のゲッター
        public uint Data_length { get; set; }//音声波形配列の長さ    
        public decimal SampleT { get; set; } //サンプリング周期、精度を高めるためdeximal型
        public bool Read_success { get; set; } = false;//ファイル読み込み成否フラグ
  
        //---------音声再生用変数--------------
        public System.Media.SoundPlayer Player { get; set; } = null;//音声再生オブジェクト

        //---------音声処理用変数--------------
        private double[] res_imp;//インパルス応答、リバーブ、LPFの計算に使用                               
        public void Set_Res_Ims(double[] res_imp)
        {
            this.res_imp = res_imp;
        }//res_impのセッター

        //---------編集範囲用変数---------------
        private decimal arange_min = 0, arange_max = 0;//編集範囲の最小値(sec)と最大値(sec)
        private long index_arange_min = 0, index_arange_max = 0;//編集範囲の最小値と最大値のインデックス
        public void Set_arrange_range(decimal min, decimal max)
        {
            arange_min = min;
            if (arange_min < 0) { arange_min = 0; }
            if (arange_min > (Data_length - 1) * SampleT) { arange_min = (Data_length - 1) * SampleT; }
            arange_max = max;
            if (arange_max < 0) { arange_max = 0; }
            if (arange_max > (Data_length - 1) * SampleT) { arange_max = (Data_length - 1) * SampleT; }

            index_arange_min = (long)(arange_min / SampleT);
            if (index_arange_min < 0) { index_arange_min = 0; }
            if (index_arange_min > Data_length - 1) { index_arange_min = Data_length - 1; }
            index_arange_max = (long)(arange_max / SampleT);
            if (index_arange_max < 0) { index_arange_max = 0; }
            if (index_arange_max > Data_length - 1) { index_arange_max = Data_length - 1; }

            if (index_arange_min != index_arange_max)
            {
                Arange_enable = true;
            }
            else
            {
                Arange_enable = false;
            }
        }//arange_min,arange_max,index_arange_min,index_arange_maxのセッター
        public decimal Get_Arange_Min()
        {
            return arange_min;
        } //arange_minのゲッター
        public decimal Get_Arange_Max()
        {
            return arange_max;
        } //arange_maxのゲッター
        public bool Arange_enable { get; set; } = false;//編集可否フラグ
        public long Get_index(decimal value)
        {
            if (value < 0) { value = 0; }
            if (value > (Data_length - 1) * SampleT) { value = (Data_length - 1) * SampleT; }       
            long index = (long)(value / SampleT);
            if (index < 0) { index = 0; }
            if (index > Data_length - 1) { index = Data_length - 1; }
            return index;
            
        }//arange_min,arange_max,index_arange_min,index_arange_maxのセッター


        //----------リバーブの計算用変数----------
        private double att_rate, delay;
        private int repeat;
        private double[] mod_wave;
        //-----------LPFの計算用変数---------
        private int fe, delta;
        private double[] hann_window;
        private double[] sinc;

       
        //-------コンストラクタ-------------------
        public Wave_ope()
        {

        }

        //--------ファイル情報取得用メソッド------
        public void File_Information()
        {
            string a = new string(riff_chunk_ID);
            string b = riff_chunk_size.ToString();
            string c = new string(riff_form_type);
            string d = new string(fmt_chunk_ID);
            string e = fmt_chunk_size.ToString();
            string f = fmt_wave_format_type.ToString();
            string g = fmt_channel.ToString();
            string h = fmt_sample_per_sec.ToString();
            string i = fmt_bytes_per_sec.ToString();
            string j = fmt_block_size.ToString();
            string k = fmt_bits_per_sample.ToString();
            string l = new string(data_chunk_ID);
            string m = data_chunk_size.ToString();
            string n = Data_length.ToString();
            string o = SampleT.ToString();

            string debug = " riff_chunk_ID:　" + a +
                "\n riff_chunk_size:　" + b +
                "\n riff_form_type:　" + c +
                "\n fmt_chunk_ID:　" + d +
                "\n fmt_chunk_size:　" + e + "バイト" +
                "\n fmt_wave_format_type:　" + f +
                "\n fmt_channel:　" + g + "チャンネル" +
                "\n fmt_sample_per_sec:　" + h +
                "\n fmt_bytes_per_sec:　" + i +
                "\n fmt_block_size:　" + j + "バイト" +
                "\n fmt_bits_per_sample:　　" + k +
                "\n data_chunk_ID:　" + l +
                "\n data_chunk_size:　" + m + "バイト" +
                "\n data_length:　" + n +
                "\n sample_T:　" + o;
            MessageBox.Show(debug);
        }

        //--------畳み込み計算用メソッド----------
        public void Convolution(int type)
        {
            int index;
            double tmp;
            switch (type)
            {
                case 0: //畳み込みをそのまま計算
                    for (long i = index_arange_max; i >= index_arange_min; --i)
                    {
                        for (int n = 0; n < res_imp.Length; ++n)
                        {
                            if (i - n < 0) { continue; }
                            tmp = data_tmp1[i - n] * res_imp[n];
                            data_tmp1[i] = data_tmp1[i] + tmp;
                        }
                        i = i + 0;
                    }
                    if (fmt_channel == 2)
                    {
                        for (long i = index_arange_max; i >= index_arange_min; --i)
                        {
                            for (int n = 0; n < res_imp.Length; ++n)
                            {
                                if (i - n < 0) { continue; }
                                tmp = data_tmp2[i - n] * res_imp[n];
                                data_tmp2[i] = data_tmp2[i] + tmp;
                            }

                        }
                    }
                    break;

                case 1: //リバーブ用に、インパルス応答がある部分だけ計算
                    for (long i = index_arange_max; i >= index_arange_min; --i)
                    {
                        for (int n = 0; n <= repeat; ++n)
                        {
                            index = (int)(n * delay * fmt_sample_per_sec);
                            if (i - index < 0) { continue; }
                            tmp = data_tmp1[i - index] * res_imp[index];
                            data_tmp1[i] = data_tmp1[i] + tmp;
                        }
                    }
                    if (fmt_channel == 2)
                    {
                        for (long i = index_arange_max; i >= index_arange_min; --i)
                        {
                            for (int n = 0; n <= repeat; ++n)
                            {
                                index = (int)(n * delay * fmt_sample_per_sec);
                                if (i - index < 0) { continue; }
                                tmp = data_tmp2[i - index] * res_imp[index];
                                data_tmp2[i] = data_tmp2[i] + tmp;
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        //--------編集内容リセット用メソッド------
        public void Reset_Data()
        {
            if (fmt_channel == 1)
            {
                for (int i = 0; i < data_tmp1.Length; ++i)
                    data_tmp1[i] = data_MONO[i];
            }
            else if (fmt_channel == 2)
            {
                for (int i = 0; i < data_tmp1.Length; ++i)
                {
                    data_tmp1[i] = data_LEFT[i];
                    data_tmp2[i] = data_RIGHT[i];
                }
            }
        }

        //--------振幅レベル変更用メソッド--------
        public void Level_Change(double rate)
        {
            if (fmt_channel == 1)
            {
                for (long i = index_arange_min; i <= index_arange_max; ++i)
                    data_tmp1[i] = data_tmp1[i] * rate;
            }
            else if (fmt_channel == 2)
            {
                for (long i = index_arange_min; i <= index_arange_max; ++i)
                {
                    data_tmp1[i] = data_tmp1[i] * rate;
                    data_tmp2[i] = data_tmp2[i] * rate;
                }
            }
        }

        //----------ファイル入出力用メソッド------------
        //ファイル読み込み
        public bool Read_File(string filename)
        {
            System.IO.FileStream read_file;
            System.IO.BinaryReader br;

            if (System.IO.File.Exists(filename))
            {
                using (read_file = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (br = new System.IO.BinaryReader(read_file))
                    {

                        riff_chunk_ID = br.ReadChars(4);
                        riff_chunk_size = br.ReadUInt32();
                        riff_form_type = br.ReadChars(4);
                        string ID = new string(riff_chunk_ID);
                        string TYPE = new string(riff_form_type);
                        if (ID == "RIFF" && TYPE == "WAVE")
                        {
                            fmt_chunk_ID = br.ReadChars(4);
                            fmt_chunk_size = br.ReadUInt32();
                            fmt_wave_format_type = br.ReadUInt16();
                            fmt_channel = br.ReadUInt16();
                            fmt_sample_per_sec = br.ReadUInt32();
                            fmt_bytes_per_sec = br.ReadUInt32();
                            fmt_block_size = br.ReadUInt16();
                            fmt_bits_per_sample = br.ReadUInt16();
                            data_chunk_ID = br.ReadChars(4);
                            data_chunk_size = br.ReadUInt32();
                            Data_length = data_chunk_size / fmt_block_size;
                            decimal tmp = fmt_sample_per_sec;
                            SampleT = 1 / tmp;
                            if (Read_Data(br))
                            {
                                Read_success = true;
                                //File_Information();
                                return true;
                            }
                            else
                            {
                                Read_success = false;
                                MessageBox.Show("このファイルは読み込めません");
                                return false;
                            }
                        }
                        else
                        {
                            Read_success = false;
                            MessageBox.Show("このファイルはWAVEフォーマットではありません。");
                            return false;
                        }
                    }
                }
            }
            MessageBox.Show("ファイルが存在しません。");
            return false;
        }
        //波形データ読み込み、データはdouble型で格納
        private bool Read_Data(System.IO.BinaryReader br)
        {
            int tmp;
            if (fmt_wave_format_type == 1)
            {
                if (fmt_channel == 1)　//チャンネルが１つならモノラル
                {
                    data_MONO = new double[Data_length];
                    if (fmt_bits_per_sample == 16)
                    {
                        for (int i = 0; i < Data_length; ++i)
                        {
                            tmp = br.ReadInt16();
                            data_MONO[i] = (double)tmp / 32768.0;
                            data_tmp1[i] = data_MONO[i];
                        }
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("量子化８ビットは読み込めません"); //８ビットは読み込まない
                        return false;
                    }
                }
                else if (fmt_channel == 2)  //チャンネルが２つならステレオ
                {
                    data_LEFT = new double[Data_length];
                    data_RIGHT = new double[Data_length];
                    data_tmp1 = new double[Data_length];
                    data_tmp2 = new double[Data_length];

                    if (fmt_bits_per_sample == 16)
                    {
                        for (int i = 0; i < Data_length; ++i)
                        {
                            tmp = br.ReadInt16();
                            data_LEFT[i] = (double)tmp / 32768.0;
                            data_tmp1[i] = data_LEFT[i];
                            tmp = br.ReadInt16();
                            data_RIGHT[i] = (double)tmp / 32768.0;
                            data_tmp2[i] = data_RIGHT[i];
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else  //3ch以上は読み込まない 
                {
                    MessageBox.Show("モノラル・ステレオ以外は読み込めません。");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("PCM以外のデータ形式は読み込めません。");
                return false;
            }
        }
        //波形データをdoubleからshortに変更、データ書き込み時に使用
        private short Double_to_Short(double double_value)
        {
            short data;
            double_value = (double_value + 1) / 2.0 * 65536.0;
            if(double_value > 65535.0)
            {
                double_value = 65535.0;
            }else if (double_value < 0.0)
            {
                double_value = 0.0;
            }
            data = (short)((double_value + 0.5) - 32768); //四捨五入とオフセット
            return data;
        }     
        //ファイル書き込み
        public bool Write_file(string filename)
        {
            System.IO.FileStream write_file;
            System.IO.BinaryWriter bw;
            if (Read_success)
            {
                if (filename != null && filename != "")
                {
                    using (write_file = new System.IO.FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                    {
                        using (bw = new System.IO.BinaryWriter(write_file))
                        {
                            //riff_chunk_ID = br.ReadChars(4);
                            bw.Write(riff_chunk_ID);
                            //riff_chunk_size = br.ReadUInt32();
                            bw.Write(riff_chunk_size);
                            //riff_form_type = br.ReadChars(4);
                            bw.Write(riff_form_type);
                            //fmt_chunk_ID = br.ReadChars(4);
                            bw.Write(fmt_chunk_ID);
                            //fmt_chunk_size = br.ReadUInt32();
                            bw.Write(fmt_chunk_size);
                            //fmt_wave_format_type = br.ReadUInt16();
                            bw.Write(fmt_wave_format_type);
                            //fmt_channel = br.ReadUInt16();
                            bw.Write(fmt_channel);
                            //fmt_sample_per_sec = br.ReadUInt32();
                            bw.Write(fmt_sample_per_sec);
                            //fmt_bytes_per_sec = br.ReadUInt32();
                            bw.Write(fmt_bytes_per_sec);
                            //fmt_block_size = br.ReadUInt16();
                            bw.Write(fmt_block_size);
                            //fmt_bits_per_sample = br.ReadUInt16();
                            bw.Write(fmt_bits_per_sample);
                            //data_chunk_ID = br.ReadChars(4);
                            bw.Write(data_chunk_ID);
                            //data_chunk_size = br.ReadUInt32();
                            bw.Write(data_chunk_size);
                            Write_Data(bw);
                        }
                    }
                    return true;
                }
                MessageBox.Show("ファイル名が不正な値です");
                return false;
            }
            MessageBox.Show("書き込むデータがありません。");
            return false;
        }
        //波形データ書き込み
        private bool Write_Data(System.IO.BinaryWriter bw)
        {
            short tmp;
            if (fmt_channel == 1) //チャンネルが１つならモノラル
            {

                for (int i = 0; i < Data_length; ++i)
                {
                    tmp = Double_to_Short(data_tmp1[i]);
                    bw.Write(tmp);
                }
                return true;
            }
            else if (fmt_channel == 2)  //チャンネルが２つならステレオ
            {
                for (int i = 0; i < Data_length; ++i)
                {
                    tmp = Double_to_Short(data_tmp1[i]);
                    bw.Write(tmp);
                    tmp = Double_to_Short(data_tmp2[i]);
                    bw.Write(tmp);
                }
                return true;
            }
            return false;
        }
 
        //------------音声再生用メソッド---------
        //音声再生用ファイルの書き込み
        private bool Tmp_Write_File()
        {
            System.IO.FileStream write_file;
            System.IO.BinaryWriter bw;

            if (!Arange_enable)
            {
                MessageBox.Show("選択範囲が有効でないため再生できません。");
                return false;
            }
            using (write_file = new System.IO.FileStream("tmp.wav", System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                using (bw = new System.IO.BinaryWriter(write_file))
                {
                    long tmp_length = index_arange_max - index_arange_min + 1;
                    uint tmp_data_chunk_size = (uint)(tmp_length * fmt_block_size);
                    //riff_chunk_ID = br.ReadChars(4);
                    bw.Write(riff_chunk_ID);
                    //riff_chunk_size = br.ReadUInt32();
                    uint tmp_riff_chunk_size = 36 + tmp_data_chunk_size;
                    bw.Write(tmp_riff_chunk_size);
                    //riff_form_type = br.ReadChars(4);
                    bw.Write(riff_form_type);
                    //fmt_chunk_ID = br.ReadChars(4);
                    bw.Write(fmt_chunk_ID);
                    //fmt_chunk_size = br.ReadUInt32();
                    bw.Write(fmt_chunk_size);
                    //fmt_wave_format_type = br.ReadUInt16();
                    bw.Write(fmt_wave_format_type);
                    //fmt_channel = br.ReadUInt16();
                    bw.Write(fmt_channel);
                    //fmt_sample_per_sec = br.ReadUInt32();
                    bw.Write(fmt_sample_per_sec);
                    //fmt_bytes_per_sec = br.ReadUInt32();
                    bw.Write(fmt_bytes_per_sec);
                    //fmt_block_size = br.ReadUInt16();
                    bw.Write(fmt_block_size);
                    //fmt_bits_per_sample = br.ReadUInt16();
                    bw.Write(fmt_bits_per_sample);
                    //data_chunk_ID = br.ReadChars(4);
                    bw.Write(data_chunk_ID);
                    //data_chunk_size = br.ReadUInt32();
                    //bw.Write(data_chunk_size);

                    bw.Write(tmp_data_chunk_size);
                    Tmp_Write_Data(bw);
                }
            }
            return true;
        }
        //音声再生用波形データの書き込み
        private void Tmp_Write_Data(System.IO.BinaryWriter bw)
        {
            short tmp;
            if (fmt_channel == 1) //チャンネルが１つならモノラル
            {

                for (long i = index_arange_min; i <= index_arange_max; ++i)
                {
                    tmp = Double_to_Short(data_tmp1[i]);
                    bw.Write(tmp);
                }
                //return true;
            }
            else if (fmt_channel == 2)  //チャンネルが２つならステレオ
            {


                for (long i = index_arange_min; i <= index_arange_max; ++i)
                {
                    tmp = Double_to_Short(data_tmp1[i]);
                    bw.Write(tmp);
                    tmp = Double_to_Short(data_tmp2[i]);
                    bw.Write(tmp);
                }
                //return true;
            }
            //return false;
        }
        //音声再生
        public void Sound_Play()
        {
            if (Tmp_Write_File()){
                Player = new System.Media.SoundPlayer("tmp.wav");
                Player.Play();
            }
        }
        //音声停止
        public void Sound_Stop()
        {
            Player.Stop();
            Player.Dispose();
            Player = null;
        }

        //-----------リバーブ用メソッド-----------
        //インパルス応答を作成
        public double[] Create_Reverb_imp(double att_rate,int repeat,double delay_time)
        {
            this.att_rate = att_rate;
            this.delay = delay_time;
            this.repeat = repeat;
            int length = (int)(delay_time * repeat * fmt_sample_per_sec) + 1;
            res_imp = new double[length];
            int index;
            //res_imp = new double[repeat + 1];
            res_imp[0] = 1;
            for(int i = 1; i < length; ++i)
            {
                res_imp[i] = 0; 
            }
            for(int i = 1; i < repeat + 1; ++i)
            {
                index = (int)(delay_time * i * fmt_sample_per_sec);
                res_imp[index] = Math.Pow(att_rate, i);
                //res_imp[i] = Math.Pow(att_rate, i);
            }
            return res_imp;
        }
        //リバーブ処理
        public void Reverb()
        {
            Convolution(1);
        }
        
        //----------リング変調用メソッド-----------
        //変調波を作成
        public double[] Create_Mod_Wave(double depth,int rate)
        {
            long length = index_arange_max - index_arange_min + 1;
            mod_wave = new double[length];
            for (int i = 0; i < length; ++i) {
                mod_wave[i] =  depth * Math.Sin(2 * Math.PI * i *rate / fmt_sample_per_sec);
            }
            return mod_wave;
        }
        //リング変調処理
        public void Ring_Mod()
        {
            if (fmt_channel == 1) {
                for (long i = index_arange_min; i < index_arange_max + 1; ++i)
                {
                    data_tmp1[i] = data_tmp1[i] * mod_wave[i - index_arange_min];
                }
            } else if (fmt_channel == 2) {
                for (long i = index_arange_min; i < index_arange_max + 1; ++i)
                {
                    data_tmp1[i] = data_tmp1[i] * mod_wave[i - index_arange_min];
                    data_tmp2[i] = data_tmp2[i] * mod_wave[i - index_arange_min];
                }
            }
        }

        //---------LPF用メソッド--------------------
        //ハニング窓を作成
        public void Han()
        {
            
            int J = (int)Math.Round(3.1 * fmt_sample_per_sec / delta);
            if(J % 2 == 0)
            {
                J = J + 1;
            }
            hann_window = new double[J];
            for(int i = 0; i < J; ++i)
            {
                hann_window[i] = 0.5 - 0.5 * Math.Cos(2 * Math.PI * i / J);
            }
        }
        //LPFインパルス応答を作成
        public double[] Create_LPF_Imp(int fe,int delta)
        {
            if(fe == 0 || delta == 0)
            {
                res_imp = new double[1];
                res_imp[0] = 1;
                return res_imp;
            }
            
            this.fe = fe;
            this.delta = delta;
            Han();
            int length = hann_window.Length;
            sinc = new double[length];
            res_imp = new double[length];
            int center = length / 2;
            for(int i = 0; i < length; ++i)
            {              
                sinc[i] = 2.0 * fe / fmt_sample_per_sec * Math.Sin(2.0 * Math.PI * fe / fmt_sample_per_sec * (i-center)) / (2.0 * Math.PI * fe / fmt_sample_per_sec*(i-center));
            }
            sinc[center] = 2.0 * fe / fmt_sample_per_sec;
            for(int i = 0; i < length; ++i)
            {
                res_imp[i] = sinc[i] * hann_window[i];
            }
            return res_imp;
        }
        //LPF処理
        public void LPF()
        {
            Convolution(0);
        }
    }
}
