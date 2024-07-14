using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.Xml.Serialization;
using System.IO;

namespace Stud
{
    public partial class Form2 : Form
    {
        Props props = new Props(); //экземпляр класса с настройками///////////////////////////////////////

        /*static string serverName = "localhost"; // Адрес сервера (для локальной базы пишите "localhost")
        static string userName = "root"; // Имя пользователя
        static string dbName = "styd"; //Имя базы данных
        static string port = "3306"; // Порт для подключения
        static string password = "root"; // Пароль для подключения
        static string connStr = "server=" + serverName +
                                       ";user=" + userName +
                                       ";database=" + dbName +
                                       ";port=" + port +
                                       ";password=" + password +
                                       ";charset = utf8;";*/

        string serverName = "";
        string userName = "";
        string dbName = "";
        string port = "";
        string password = "";
        string connStr = "";

        double at1=0, at2=0, at3=0, at4=0, at5=0, at6=0, at7=0, at8=0, at9=0; //балл за каждую часть
        int nom; //номер куда писать строку новую будем
        double[] ad = new double[61]; //веса

        public Form2(int data)
        {
            InitializeComponent();
            this.data = data;
        }

        int data;

        private void button1_Click(object sender, EventArgs e) //закрыть
        {
            
                this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e) //далее
        {
            if(tabControl1.SelectedTab == tabPage1)
            {
                button3.Enabled = true;
                tabControl1.SelectedTab = tabPage2;
                return;
            } 
            if (tabControl1.SelectedTab == tabPage2)
            {
                tabControl1.SelectedTab = tabPage3;
                return;
            }
            if (tabControl1.SelectedTab == tabPage3)
            {
                tabControl1.SelectedTab = tabPage4;
                return;
            }
            if (tabControl1.SelectedTab == tabPage4)
            {
                tabControl1.SelectedTab = tabPage5;
                return;
            }
            if (tabControl1.SelectedTab == tabPage5)
            {
                tabControl1.SelectedTab = tabPage6;
                return;
            }
            if (tabControl1.SelectedTab == tabPage6)
            {
                tabControl1.SelectedTab = tabPage7;
                return;
            }
            if (tabControl1.SelectedTab == tabPage7)
            {
                tabControl1.SelectedTab = tabPage8;
                return;
            }
            if (tabControl1.SelectedTab == tabPage8)
            {
                tabControl1.SelectedTab = tabPage9;
                return;
            }
            if (tabControl1.SelectedTab == tabPage9)
            {
                button2.Enabled = false;
                tabControl1.SelectedTab = tabPage10;
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e) //назад
        {
            
            if (tabControl1.SelectedTab == tabPage2)
            {
                button3.Enabled = false;
                tabControl1.SelectedTab = tabPage1;
                return;
            }
            if (tabControl1.SelectedTab == tabPage3)
            {
                tabControl1.SelectedTab = tabPage2;
                return;
            }
            if (tabControl1.SelectedTab == tabPage4)
            {
                tabControl1.SelectedTab = tabPage3;
                return;
            }
            if (tabControl1.SelectedTab == tabPage5)
            {
                tabControl1.SelectedTab = tabPage4;
                return;
            }
            if (tabControl1.SelectedTab == tabPage6)
            {
                tabControl1.SelectedTab = tabPage5;
                return;
            }
            if (tabControl1.SelectedTab == tabPage7)
            {
                tabControl1.SelectedTab = tabPage6;
                return;
            }
            if (tabControl1.SelectedTab == tabPage8)
            {
                tabControl1.SelectedTab = tabPage7;
                return;
            }
            if (tabControl1.SelectedTab == tabPage9)
            {
                tabControl1.SelectedTab = tabPage8;
                return;
            }
            if (tabControl1.SelectedTab == tabPage10)
            {
                button2.Enabled = true;
                tabControl1.SelectedTab = tabPage9;
                return;
            }
        }

        private void Form2_Load(object sender, EventArgs e) //загрузка, нули в текстбоксы, загрузка инфы на правку
        {
            props.ReadXml();
            serverName = props.Fields.serverName;
            userName = props.Fields.userName;
            dbName = props.Fields.dbName;
            port = props.Fields.port;
            password = props.Fields.password;

            connStr = "server=" + serverName +
                                       ";user=" + userName +
                                       ";database=" + dbName +
                                       ";port=" + port +
                                       ";password=" + password +
                                       ";charset = utf8;";


            button3.Enabled = false;
            nom = read();
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox13.Text = "0";
            textBox14.Text = "0";
            textBox15.Text = "0";
            textBox16.Text = "0";
            textBox17.Text = "0";
            textBox18.Text = "0";
            textBox19.Text = "0";
            textBox20.Text = "0";
            textBox21.Text = "0";
            textBox22.Text = "0";
            textBox23.Text = "0";
            textBox24.Text = "0";
            textBox25.Text = "0";
            textBox26.Text = "0";
            textBox27.Text = "0";
            textBox36.Text = "0";
            textBox35.Text = "0";
            textBox34.Text = "0";
            textBox33.Text = "0";
            textBox48.Text = "0";
            textBox47.Text = "0";
            textBox46.Text = "0";
            textBox45.Text = "0";
            textBox44.Text = "0";
            textBox42.Text = "0";
            textBox41.Text = "0";
            textBox40.Text = "0";
            textBox43.Text = "0";
            textBox39.Text = "0";
            textBox38.Text = "0";
            textBox37.Text = "0";
            textBox49.Text = "0";
            textBox28.Text = "0";
            if(data!=0)
            {
                z0(data);
                z1(data);
                z2(data);
                z3(data);
                z4(data);
                z5(data);
                z6(data);
                z7(data);
                z8(data);
                z9(data);
            }
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e) //закрытие формы, сэйв
        {
            
                t0();
                t1();
                t2();
                t3();
                t4();
                t5();
                t6();
                t7();
                t8();
                t9();

                t();
            if (data == 0)
            {
                nom++;
                write(nom);
            }
            
        }

        private int read()
        {
            int asd = 0;
           
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "select nom.* from nom";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
            }
            myConnection.Close();

            return asd;
        }

        private void write(int asd)
        {
           
            MySqlConnection myConnection = new MySqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }



            string CommandText = "UPDATE nom SET nom = " + asd + " WHERE qwe=1";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();


            myConnection.Close();

        }

        private int compress(int a0, int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9)
        {
            int res = 0;
            if (a0 == 1) res = res + 1;
            if (a1 == 1) res = res + 2;
            if (a2 == 1) res = res + 4;
            if (a3 == 1) res = res + 8;
            if (a4 == 1) res = res + 16;
            if (a5 == 1) res = res + 32;
            if (a6 == 1) res = res + 64;
            if (a7 == 1) res = res + 128;
            if (a8 == 1) res = res + 256;
            if (a9 == 1) res = res + 512;

            return res;
        }

        private int decompress0(int b)
        {
            int res = 0;
            res = b % 2;
            return res;
        }

        private int decompress1(int b)
        {
            int res = 0;
            b = b / 2;
            res = b % 2;
            return res;
        }

        private int decompress2(int b)
        {
            int res = 0;
            b = b / 4;
            res = b % 2;
            return res;
        }

        private int decompress3(int b)
        {
            int res = 0;
            b = b / 8;
            res = b % 2;
            return res;
        }

        private int decompress4(int b)
        {
            int res = 0;
            b = b / 16;
            res = b % 2;
            return res;
        }

        private int decompress5(int b)
        {
            int res = 0;
            b = b / 32;
            res = b % 2;
            return res;
        }

        private int decompress6(int b)
        {
            int res = 0;
            b = b / 64;
            res = b % 2;
            return res;
        }

        private int decompress7(int b)
        {
            int res = 0;
            b = b / 128;
            res = b % 2;
            return res;
        }

        private int decompress8(int b)
        {
            int res = 0;
            b = b / 256;
            res = b % 2;
            return res;
        }

        private int decompress9(int b)
        {
            int res = 0;
            res = b / 512;
            return res;
        }

        //******************************************
        //***** Блок сэйва
        //*******************************************
        private void t()
        {
            DateTime date1 = new DateTime();
            date1 = DateTime.Now;
            String aga = Convert.ToString(date1);
            aga = aga.Substring(0, 16);


            MySqlConnection myConnection = new MySqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            int as1, as2, as3, as4, as5, as6, as7, as8, as9;
            as1 = Convert.ToInt32(at1 * 10000);
            as2 = Convert.ToInt32(at2 * 10000);
            as3 = Convert.ToInt32(at3 * 10000);
            as4 = Convert.ToInt32(at4 * 10000);
            as5 = Convert.ToInt32(at5 * 10000);
            as6 = Convert.ToInt32(at6 * 10000);
            as7 = Convert.ToInt32(at7 * 10000);
            as8 = Convert.ToInt32(at8 * 10000);
            as9 = Convert.ToInt32(at9 * 10000);

            double b;
            b = (at1+at2+at3+at4+at5+at6+at7+at8+at9) / 9;
            int bs = Convert.ToInt32(b * 10000);

            string CommandText;
            if (data == 0) CommandText = "INSERT INTO  `t` (`nom`, `fio`, `date`, `a1`, `a2`, `a3`, `a4`, `a5`, `a6`, `a7`, `a8`, `a9`, `b`) VALUES (" + nom + " , '" + textBox5.Text + "', '" + aga + "', " + as1 + ", " + as2 + ", " + as3 + ", " + as4 + ", " + as5 + ", " + as6 + ", " + as7 + ", " + as8 + ", " + as9 + ", " + bs + ")";
            else CommandText = "UPDATE t SET fio='" + textBox5.Text + "', date='" + aga + "', a1=" + as1 + ", a2=" + as2 + ", a3=" + as3 + ", a4=" + as4 + ", a5=" + as5 + ", a6=" + as6 + ", a7=" + as7 + ", a8=" + as8 + ", a9=" + as9 + ", b=" + bs + " WHERE nom=" + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();

        }

        private void t0()
        {
            
            MySqlConnection myConnection = new MySqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            int qwe = 0;
            if (radioButton2.Checked) qwe = 1;
            string CommandText;
            if (data == 0) CommandText = "INSERT INTO  `t0` (`nom`, `name`, `pol`, `vozr`, `mestorab`, `podrazd`, `dol`) VALUES (" + nom + " , '" + textBox5.Text + "', " + qwe + ", '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
            else CommandText = "UPDATE t0 SET name='" + textBox5.Text + "', pol=" + qwe + ", vozr='" + textBox1.Text + "', mestorab='" + textBox2.Text + "', podrazd='" + textBox3.Text + "', dol='" + textBox4.Text + "' WHERE nom=" + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        private void t1()
        {
            
            MySqlConnection myConnection = new MySqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            int qwe = 0;
            if (radioButton4.Checked) qwe = 1;
            if (radioButton5.Checked) qwe = 2;
            if (radioButton6.Checked) qwe = 3;
            int asd = 0;
            if (radioButton8.Checked) asd = 1;
            if (radioButton9.Checked) asd = 2;
            string CommandText;
            if (data == 0) CommandText = "INSERT INTO  `t1` (`nom`, `zar`, `ycheb`, `tren`, `instr`, `vozm`) VALUES (" + nom +" , '" + qwe + "', " + Convert.ToInt32(textBox6.Text) + ", '" + Convert.ToInt32(textBox7.Text) + "', '" + Convert.ToInt32(textBox8.Text) + "', '" + asd + "')";
            else CommandText = "UPDATE t1 SET zar=" + qwe + ", ycheb=" + Convert.ToInt32(textBox6.Text) + ", tren=" + Convert.ToInt32(textBox7.Text) + ", instr=" + Convert.ToInt32(textBox8.Text) + ", vozm=" + asd + " WHERE nom=" + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            at1 = 0;
            myConnection.Open();
            CommandText = "select t1 from admin";
            myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            string qwert;
            double asdfg;
            int zxcvb;
            for (int i = 1; i <= 60; i++)
            {
                myDataReader.Read();
                qwert = myDataReader[0].ToString();
                zxcvb = Convert.ToInt32(qwert);
                asdfg = Convert.ToDouble(zxcvb);
                ad[i] = asdfg / 10000;
            }
            myConnection.Close();

            if (qwe == 0) at1 += ad[1];
            if (qwe == 1) at1 += ad[2];
            if (qwe == 2) at1 += ad[3];
            if (qwe == 3) at1 += ad[4];

            if (asd == 0) at1 += ad[10];
            if (asd == 1) at1 += ad[11];
            if (asd == 2) at1 += ad[12];

            at1 += Convert.ToInt32(textBox6.Text) * ad[6];
            at1 += Convert.ToInt32(textBox7.Text) * ad[7];
            at1 += Convert.ToInt32(textBox8.Text) * ad[8];
        }

        private void t2()
        {
            
            MySqlConnection myConnection = new MySqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            int qwe = 0;
            if (radioButton11.Checked) qwe = 1;
            if (radioButton12.Checked) qwe = 2;
            if (radioButton13.Checked) qwe = 3;
            if (radioButton14.Checked) qwe = 4;
            if (radioButton15.Checked) qwe = 5;
            if (radioButton16.Checked) qwe = 6;
            if (radioButton17.Checked) qwe = 7;
            if (radioButton18.Checked) qwe = 8;
            if (radioButton19.Checked) qwe = 9;
            if (radioButton20.Checked) qwe = 10;
            int asd = 0;
            int a0 = 0, a1 = 0, a2 = 0, a3 = 0, a4 = 0, a5 = 0, a6 = 0, a7 = 0, a8 = 0;
            if (checkBox7.Checked) a0 = 1;
            if (checkBox8.Checked) a1 = 1;
            if (checkBox9.Checked) a2 = 1;
            if (checkBox10.Checked) a3 = 1;
            if (checkBox11.Checked) a4 = 1;
            if (checkBox12.Checked) a5 = 1;
            if (checkBox13.Checked) a6 = 1;
            if (checkBox14.Checked) a7 = 1;
            if (checkBox15.Checked) a8 = 1;
            asd = compress(a0, a1, a2, a3, a4, a5, a6, a7, a8, 0);
            int zxc = 0;
            if (radioButton34.Checked) zxc = 1;
            if (radioButton35.Checked) zxc = 2;
            if (radioButton36.Checked) zxc = 3;
            int zxcq = 0;
            if (radioButton30.Checked) zxcq = 1;
            if (radioButton31.Checked) zxcq = 2;
            if (radioButton32.Checked) zxcq = 3;
            string CommandText;
            if (data == 0) CommandText = "INSERT INTO  `t2` (`nom`, `kv`, `obr`, `nap`, `naps`, `st1`, `st2`, `st3`, `kva`, `vuz`, `vuz1`, `vuz2`, `pu1`, `pu2`, `pu3`, `pu4`, `pu5`, `pu6`, `pu7`, `pu8`, `pu9`, `re1`, `re2`, `re3`, `re4`) VALUES (" + nom + " , " +

                zxcq + ", " + qwe + ", " + asd + ", '" + textBox9.Text + "', '" + Convert.ToInt32(textBox11.Text) + "', '" + Convert.ToInt32(textBox12.Text) + "', '" + Convert.ToInt32(textBox13.Text) +
                "', '" + zxc + "', '" + textBox10.Text + "', '" + textBox51.Text + "', '" + textBox52.Text + "', '" +
                Convert.ToInt32(textBox14.Text) + "', '" + Convert.ToInt32(textBox15.Text) + "', '" + Convert.ToInt32(textBox16.Text) + "', '" + Convert.ToInt32(textBox17.Text) + "', '" + Convert.ToInt32(textBox18.Text) + "', '" + Convert.ToInt32(textBox19.Text) + "', '" + Convert.ToInt32(textBox20.Text) + "', '" + Convert.ToInt32(textBox21.Text) + "', '" + Convert.ToInt32(textBox22.Text) +
                "', '" + Convert.ToInt32(textBox23.Text) + "', '" + Convert.ToInt32(textBox24.Text) + "', '" + Convert.ToInt32(textBox25.Text) + "', '" + Convert.ToInt32(textBox26.Text) + "')";

            else CommandText = "UPDATE t2 SET kv=" + zxcq + ", obr=" + qwe + ", nap=" + asd + ", naps='" + textBox9.Text + "', st1=" + Convert.ToInt32(textBox11.Text) + ", st2=" + Convert.ToInt32(textBox12.Text) + ", st3=" + Convert.ToInt32(textBox13.Text) +
                    ", kva = " + zxc + ", vuz='" + textBox10.Text + "', vuz1='" + textBox51.Text + "', vuz2='" + textBox52.Text + "', pu1=" + Convert.ToInt32(textBox14.Text) + ", pu2=" + Convert.ToInt32(textBox15.Text) + ", pu3=" + Convert.ToInt32(textBox16.Text) + ", pu4=" + Convert.ToInt32(textBox17.Text) + ", pu5=" + Convert.ToInt32(textBox18.Text) + ", pu6=" + Convert.ToInt32(textBox19.Text) + ", pu7=" + Convert.ToInt32(textBox20.Text) + ", pu8=" + Convert.ToInt32(textBox21.Text) + ", pu9=" + Convert.ToInt32(textBox22.Text) +
                    ", re1=" + Convert.ToInt32(textBox23.Text) + ", re2=" + Convert.ToInt32(textBox24.Text) + ", re3=" + Convert.ToInt32(textBox25.Text) + ", re4=" + Convert.ToInt32(textBox26.Text) + " WHERE nom = " + data + "; ";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            at2 = 0;
            myConnection.Open();
            CommandText = "select t2 from admin";
            myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            string qwert;
            double asdfg;
            int zxcvb;
            for (int i = 1; i <= 60; i++)
            {
                myDataReader.Read();
                qwert = myDataReader[0].ToString();
                zxcvb = Convert.ToInt32(qwert);
                asdfg = Convert.ToDouble(zxcvb);
                ad[i] = asdfg / 10000;
            }
            myConnection.Close();

            if (qwe == 0) at2 += ad[1];
            if (qwe == 1) at2 += ad[2];
            if (qwe == 2) at2 += ad[3];
            if (qwe == 3) at2 += ad[4];
            if (qwe == 4) at2 += ad[5];
            if (qwe == 5) at2 += ad[6];
            if (qwe == 6) at2 += ad[7];
            if (qwe == 7) at2 += ad[8];
            if (qwe == 8) at2 += ad[9];
            if (qwe == 9) at2 += ad[10];
            if (qwe == 10) at2 += ad[11];

            if (a0 == 1) at2 += ad[13];
            if (a1 == 1) at2 += ad[14];
            if (a2 == 1) at2 += ad[15];
            if (a3 == 1) at2 += ad[16];
            if (a4 == 1) at2 += ad[17];
            if (a5 == 1) at2 += ad[18];
            if (a6 == 1) at2 += ad[19]; 
            if (a7 == 1) at2 += ad[20];
            if (a8 == 1) at2 += ad[21];

            if (zxc == 0) at2 += ad[41];
            if (zxc == 1) at2 += ad[42];
            if (zxc == 2) at2 += ad[43];
            if (zxc == 3) at2 += ad[44];

            if (zxcq == 0) at2 += ad[45];
            if (zxcq == 1) at2 += ad[46];
            if (zxcq == 2) at2 += ad[47];
            if (zxcq == 3) at2 += ad[48];

            at2 += Convert.ToInt32(textBox11.Text) * ad[23];
            at2 += Convert.ToInt32(textBox12.Text) * ad[24];
            at2 += Convert.ToInt32(textBox13.Text) * ad[25];

            at2 += Convert.ToInt32(textBox14.Text) * ad[26];
            at2 += Convert.ToInt32(textBox15.Text) * ad[27];
            at2 += Convert.ToInt32(textBox16.Text) * ad[28];
            at2 += Convert.ToInt32(textBox17.Text) * ad[29];
            at2 += Convert.ToInt32(textBox18.Text) * ad[30];
            at2 += Convert.ToInt32(textBox19.Text) * ad[31];
            at2 += Convert.ToInt32(textBox20.Text) * ad[32];
            at2 += Convert.ToInt32(textBox21.Text) * ad[33];
            at2 += Convert.ToInt32(textBox22.Text) * ad[34];

            at2 += Convert.ToInt32(textBox23.Text) * ad[36];
            at2 += Convert.ToInt32(textBox24.Text) * ad[37];
            at2 += Convert.ToInt32(textBox25.Text) * ad[38];
            at2 += Convert.ToInt32(textBox26.Text) * ad[39];
        }

        private void t3()
        {
            
            MySqlConnection myConnection = new MySqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            int qwe1 = 0;
            if (radioButton38.Checked) qwe1 = 1;
            if (radioButton39.Checked) qwe1 = 2;
            int qwe2 = 0;
            if (radioButton41.Checked) qwe2 = 1;
            int qwe3 = 0;
            if (radioButton43.Checked) qwe3 = 1;
            int qwe4 = 0;
            if (radioButton45.Checked) qwe4 = 1;
            if (radioButton46.Checked) qwe4 = 2;
            int qwe5 = 0;
            if (radioButton48.Checked) qwe5 = 1;
            if (radioButton49.Checked) qwe5 = 2;
            int qwe6 = 0;
            if (radioButton51.Checked) qwe6 = 1;
            if (radioButton52.Checked) qwe6 = 2;
            if (radioButton53.Checked) qwe6 = 3;
            int qwe7 = 0;
            if (radioButton55.Checked) qwe7 = 1;
            if (radioButton56.Checked) qwe7 = 2;
            string CommandText;
            if (data == 0) CommandText = "INSERT INTO  `t3` (`nom`, `lid`, `pl`, `avt`, `eks`, `chu`, `sot`, `con`, `otv`) VALUES (" + nom + " , '" + Convert.ToInt32(textBox27.Text) + "', " + qwe1 + ", '" + qwe2 + "', '" + qwe3 + "', '" + qwe4 + "', '" + qwe5 + "', '" + qwe6 + "', '" + qwe7 + "')";
            else CommandText = "UPDATE t3 SET lid=" + Convert.ToInt32(textBox27.Text) + ", pl=" + qwe1 + ", avt=" + qwe2 + ", eks=" + qwe3 + ", chu=" + qwe4 + ", sot=" + qwe5 + ", con=" + qwe6 + ", otv=" + qwe7 + " WHERE nom=" + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();


            myConnection.Close();

            at3 = 0;
            myConnection.Open();
            CommandText = "select t3 from admin";
            myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            string qwert;
            double asdfg;
            int zxcvb;
            for (int i = 1; i <= 60; i++)
            {
                myDataReader.Read();
                qwert = myDataReader[0].ToString();
                zxcvb = Convert.ToInt32(qwert);
                asdfg = Convert.ToDouble(zxcvb);
                ad[i] = asdfg / 10000;
            }
            myConnection.Close();

            if (qwe1 == 0) at3 += ad[3];
            if (qwe1 == 1) at3 += ad[4];
            if (qwe1 == 2) at3 += ad[5];
           
            if (qwe2 == 0) at3 += ad[7];
            if (qwe2 == 1) at3 += ad[8];
            
            if (qwe3 == 0) at3 += ad[10];
            if (qwe3 == 1) at3 += ad[11];
            
            if (qwe4 == 0) at3 += ad[13];
            if (qwe4 == 1) at3 += ad[14];
            if (qwe4 == 2) at3 += ad[15];

            if (qwe5 == 0) at3 += ad[17];
            if (qwe5 == 1) at3 += ad[18];
            if (qwe5 == 2) at3 += ad[19];

            if (qwe6 == 0) at3 += ad[21];
            if (qwe6 == 1) at3 += ad[22];
            if (qwe6 == 2) at3 += ad[23];
            if (qwe6 == 3) at3 += ad[24];

            if (qwe7 == 0) at3 += ad[26];
            if (qwe7 == 1) at3 += ad[27];
            if (qwe7 == 2) at3 += ad[28];
            
            at3 += Convert.ToInt32(textBox27.Text) * ad[1];
            
        }

        private void t4()
        {
            
            MySqlConnection myConnection = new MySqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            int qwe1 = 0;
            if (radioButton139.Checked) qwe1 = 1;
            if (radioButton138.Checked) qwe1 = 2;
            if (radioButton137.Checked) qwe1 = 3;
            int qwe2 = 0;
            if (radioButton135.Checked) qwe2 = 1;
            if (radioButton134.Checked) qwe2 = 2;
            if (radioButton133.Checked) qwe2 = 3;
            int qwe3 = 0;
            if (radioButton131.Checked) qwe3 = 1;
            if (radioButton130.Checked) qwe3 = 2;
            int qwe4 = 0;
            if (radioButton128.Checked) qwe4 = 1;
            if (radioButton127.Checked) qwe4 = 2;
            if (radioButton126.Checked) qwe4 = 3;
            int qwe5 = 0;
            if (radioButton124.Checked) qwe5 = 1;
            if (radioButton123.Checked) qwe5 = 2;
            int qwe6 = 0;
            if (radioButton158.Checked) qwe6 = 1;
            if (radioButton157.Checked) qwe6 = 2;
            int qwe7 = 0;
            if (radioButton149.Checked) qwe7 = 1;
            if (radioButton148.Checked) qwe7 = 2;
            int qwe8 = 0;
            if (radioButton146.Checked) qwe8 = 1;
            if (radioButton145.Checked) qwe8 = 2;
            int qwe9 = 0;
            if (radioButton153.Checked) qwe9 = 1;
            int qwe10 = 0;
            if (radioButton151.Checked) qwe10 = 1;
            int qwe11 = 0;
            if (radioButton155.Checked) qwe11 = 1;
            int qwe12 = 0;
            if (radioButton143.Checked) qwe12 = 1;
            if (radioButton142.Checked) qwe12 = 2;
            if (radioButton141.Checked) qwe12 = 3;

            string CommandText;
            if (data == 0) CommandText = "INSERT INTO  `t4` (`nom`, `tem`, `sem`, `obs`, `kom`, `obu`, `kol`, `ada`, `bre1`, `bre2`, `bre3`, `oce`, `kri`, `sam`, `ste`, `sov`, `zam`) VALUES (" + nom + " , " +
                qwe1 + ", " + qwe2 + ", " + qwe3 + ", " + qwe4 + ", " + qwe5 + ", " + qwe6 + ", " + qwe7 +
                ", " + Convert.ToInt32(textBox36.Text) + ", " + Convert.ToInt32(textBox35.Text) + ", " + Convert.ToInt32(textBox34.Text) +
                ", " + qwe8 + ", " + qwe9 + ", " + qwe10 + ", " + qwe11 +
                ", " + Convert.ToInt32(textBox33.Text) + ", " + qwe12 + ")";
            else CommandText = "UPDATE t4 SET tem=" + qwe1 + ", sem=" + qwe2 + ", obs=" + qwe3 + ", kom=" + qwe4 + ", obu=" + qwe5 + ", kol=" + qwe6 + ", ada=" + qwe7 + ", bre1=" + Convert.ToInt32(textBox36.Text) + ", bre2=" + Convert.ToInt32(textBox35.Text) + ", bre3=" + Convert.ToInt32(textBox34.Text) +
                    ", oce=" + qwe8 + ", kri=" + qwe9 + ", sam=" + qwe10 + ", ste=" + qwe11 + ", sov=" + Convert.ToInt32(textBox33.Text) + ", zam=" + qwe12 + " WHERE nom=" + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();


            myConnection.Close();

            at4 = 0;
            myConnection.Open();
            CommandText = "select t4 from admin";
            myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            string qwert;
            double asdfg;
            int zxcvb;
            for (int i = 1; i <= 60; i++)
            {
                myDataReader.Read();
                qwert = myDataReader[0].ToString();
                zxcvb = Convert.ToInt32(qwert);
                asdfg = Convert.ToDouble(zxcvb);
                ad[i] = asdfg / 10000;
            }
            myConnection.Close();

            if (qwe1 == 0) at4 += ad[1];
            if (qwe1 == 1) at4 += ad[2];
            if (qwe1 == 2) at4 += ad[3];
            if (qwe1 == 3) at4 += ad[4];

            if (qwe2 == 0) at4 += ad[6];
            if (qwe2 == 1) at4 += ad[7];
            if (qwe2 == 2) at4 += ad[8];
            if (qwe2 == 3) at4 += ad[9];

            if (qwe3 == 0) at4 += ad[11];
            if (qwe3 == 1) at4 += ad[12];
            if (qwe3 == 2) at4 += ad[13];

            if (qwe4 == 0) at4 += ad[29];
            if (qwe4 == 1) at4 += ad[30];
            if (qwe4 == 2) at4 += ad[31];
            if (qwe4 == 3) at4 += ad[32];

            if (qwe5 == 0) at4 += ad[34];
            if (qwe5 == 1) at4 += ad[35];
            if (qwe5 == 2) at4 += ad[36];

            if (qwe6 == 0) at4 += ad[11];
            if (qwe6 == 1) at4 += ad[12];
            if (qwe6 == 2) at4 += ad[13];
            
            if (qwe7 == 0) at4 += ad[38];
            if (qwe7 == 1) at4 += ad[39];
            if (qwe7 == 2) at4 += ad[40];

            if (qwe8 == 0) at4 += ad[46];
            if (qwe8 == 1) at4 += ad[47];
            if (qwe8 == 2) at4 += ad[48];

            if (qwe9 == 0) at4 += ad[22];
            if (qwe9 == 1) at4 += ad[23];

            if (qwe10 == 0) at4 += ad[26];
            if (qwe10 == 1) at4 += ad[27];

            if (qwe11 == 0) at4 += ad[19];
            if (qwe11 == 1) at4 += ad[20];
            
            if (qwe12 == 0) at4 += ad[51];
            if (qwe12 == 1) at4 += ad[52];
            if (qwe12 == 2) at4 += ad[53];
            if (qwe12 == 3) at4 += ad[54];

            at4 += Convert.ToInt32(textBox36.Text) * ad[42];
            at4 += Convert.ToInt32(textBox35.Text) * ad[43];
            at4 += Convert.ToInt32(textBox34.Text) * ad[44];
            at4 += Convert.ToInt32(textBox33.Text) * ad[50];
        }

        private void t5()
        {
           
            MySqlConnection myConnection = new MySqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            int qwe1 = 0;
            int a0 = 0, a1 = 0, a2 = 0, a3 = 0;
            if (checkBox16.Checked) a0 = 1;
            if (checkBox17.Checked) a1 = 1;
            if (checkBox18.Checked) a2 = 1;
            if (checkBox19.Checked) a3 = 1;
            qwe1 = compress(a0, a1, a2, a3, 0, 0, 0, 0, 0, 0);
            int qwe2 = 0;
            if (radioButton87.Checked) qwe2 = 1;
            if (radioButton88.Checked) qwe2 = 2;
            if (radioButton89.Checked) qwe2 = 3;
            int qwe3 = 0;
            if (radioButton91.Checked) qwe3 = 1;
            int qwe4 = 0;
            if (radioButton93.Checked) qwe4 = 1;
            int qwe5 = 0;
            if (radioButton95.Checked) qwe5 = 1;
            if (radioButton96.Checked) qwe5 = 2;

            string CommandText;
            if (data == 0) CommandText = "INSERT INTO  `t5` (`nom`, `pra`, `pras`, `nav`, `navs`, `pat`, `vla`, `ych`) VALUES (" + nom + " , " +
                qwe1 + ", '" + textBox29.Text + "', " + qwe2 + ", '" + textBox30.Text + "', " + qwe3 + ", " + qwe4 +
                ", " + qwe5 + ")";
            else CommandText = "UPDATE t5 SET pra=" + qwe1 + ", pras='" + textBox29.Text + "', nav=" + qwe2 + ", navs='" + textBox30.Text + "', pat=" + qwe3 + ", vla=" + qwe4 + ", ych=" + qwe5 + " WHERE nom=" + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();


            myConnection.Close();

            at5 = 0;
            myConnection.Open();
            CommandText = "select t5 from admin";
            myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            string qwert;
            double asdfg;
            int zxcvb;
            for (int i = 1; i <= 60; i++)
            {
                myDataReader.Read();
                qwert = myDataReader[0].ToString();
                zxcvb = Convert.ToInt32(qwert);
                asdfg = Convert.ToDouble(zxcvb);
                ad[i] = asdfg / 10000;
            }
            myConnection.Close();

            if (a0 == 1) at5 += ad[1];
            if (a1 == 1) at5 += ad[2];
            if (a2 == 1) at5 += ad[3];
            if (a3 == 1) at5 += ad[4];

            if (qwe2 == 0) at5 += ad[6];
            if (qwe2 == 1) at5 += ad[7];
            if (qwe2 == 2) at5 += ad[8];
            if (qwe2 == 3) at5 += ad[9];

            if (qwe3 == 0) at5 += ad[11];
            if (qwe3 == 1) at5 += ad[12];
            
            if (qwe4 == 0) at5 += ad[14];
            if (qwe4 == 1) at5 += ad[15];
            
            if (qwe5 == 0) at5 += ad[17];
            if (qwe5 == 1) at5 += ad[18];
            if (qwe5 == 2) at5 += ad[19];        
            
        }

        private void t6()
        {
           
            MySqlConnection myConnection = new MySqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            int qwe1 = 0;
            if (radioButton171.Checked) qwe1 = 1;
            if (radioButton170.Checked) qwe1 = 2;
            if (radioButton169.Checked) qwe1 = 3;
            if (radioButton168.Checked) qwe1 = 4;
            int qwe2 = 0;
            int a0 = 0, a1 = 0, a2 = 0, a3 = 0;
            if (checkBox20.Checked) a0 = 1;
            if (checkBox21.Checked) a1 = 1;
            if (checkBox22.Checked) a2 = 1;
            if (checkBox23.Checked) a3 = 1;
            qwe2 = compress(a0, a1, a2, a3, 0, 0, 0, 0, 0, 0);
            int qwe3 = 0;
            int q0 = 0, q1 = 0, q2 = 0, q3 = 0;
            if (checkBox24.Checked) q0 = 1;
            if (checkBox25.Checked) q1 = 1;
            if (checkBox26.Checked) q2 = 1;
            if (checkBox27.Checked) q3 = 1;
            qwe3 = compress(q0, q1, q2, q3, 0, 0, 0, 0, 0, 0);
            int qwe4 = 0;
            if (radioButton173.Checked) qwe4 = 1;

            int asd1 = 0;
            if (checkBox1.Checked) asd1 = 1;
            int asd2 = 0;
            if (checkBox2.Checked) asd2 = 1;
            int asd3 = 0;
            if (checkBox3.Checked) asd3 = 1;
            int asd4 = 0;
            if (checkBox4.Checked) asd4 = 1;
            int asd5 = 0;
            if (checkBox5.Checked) asd5 = 1;
            int asd6 = 0;
            if (checkBox6.Checked) asd6 = 1;
            string CommandText;
            if (data == 0)  CommandText = "INSERT INTO  `t6` (`nom`, `a1`, `a2`, `a3`, `a4`, `a5`, `a6`, `a7`, `a8`, `a9`, `a10`, `a11`, `a12`, `a13`, `b1`, `b2`, `b3`, `b4`, `b5`, `b6`, `c1`, `c2`, `c3`, `c4`, `d`) VALUES (" + nom + " , " +
                Convert.ToInt32(textBox48.Text) + ", " + Convert.ToInt32(textBox47.Text) + ", " + Convert.ToInt32(textBox46.Text) + ", " +
                Convert.ToInt32(textBox45.Text) + ", " + Convert.ToInt32(textBox44.Text) + ", " + Convert.ToInt32(textBox42.Text) + ", " +
                Convert.ToInt32(textBox41.Text) + ", " + Convert.ToInt32(textBox40.Text) + ", " + Convert.ToInt32(textBox43.Text) + ", " +
                Convert.ToInt32(textBox39.Text) + ", " + Convert.ToInt32(textBox38.Text) + ", " + Convert.ToInt32(textBox37.Text) + ", " +
                Convert.ToInt32(textBox49.Text) + ", " + asd1 + ", " + asd2 + ", " + asd3 + ", " + asd4 + ", " + asd5 + ", " + asd6 + ", " +
                qwe1 + ", " + qwe2 + ", " + qwe3 + ", " + qwe4 + ", '" +
                textBox50.Text + "')";
            else CommandText = "UPDATE t6 SET a1=" + Convert.ToInt32(textBox48.Text) + ", a2=" + Convert.ToInt32(textBox47.Text) + ", a3=" + Convert.ToInt32(textBox46.Text) + ", a4=" + Convert.ToInt32(textBox45.Text) + ", a5=" + Convert.ToInt32(textBox44.Text) + ", a6=" + Convert.ToInt32(textBox42.Text) + ", a7=" + Convert.ToInt32(textBox41.Text) + ", a8=" + Convert.ToInt32(textBox40.Text) + ", a9=" + Convert.ToInt32(textBox43.Text) + ", a10=" + Convert.ToInt32(textBox39.Text) + ", a11=" + Convert.ToInt32(textBox38.Text) + ", a12=" + Convert.ToInt32(textBox37.Text) + ", a13=" + Convert.ToInt32(textBox49.Text) +
                    ",b1=" + asd1 + ", b2=" + asd2 + ", b3=" + asd3 + ", b4=" + asd4 + ", b5=" + asd5 + ", b6=" + asd6 + ", c1=" + qwe1 + ", c2=" + qwe2 + ", c3=" + qwe3 + ", c4=" + qwe4 + ", d='" + textBox50.Text + "' WHERE nom=" + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();


            myConnection.Close();

            at6 = 0;
            myConnection.Open();
            CommandText = "select t6 from admin";
            myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            string qwert;
            double asdfg;
            int zxcvb;
            for (int i = 1; i <= 60; i++)
            {
                myDataReader.Read();
                qwert = myDataReader[0].ToString();
                zxcvb = Convert.ToInt32(qwert);
                asdfg = Convert.ToDouble(zxcvb);
                ad[i] = asdfg / 10000;
            }
            myConnection.Close();

            if (qwe1 == 0) at6 += ad[4];
            if (qwe1 == 1) at6 += ad[5];
            if (qwe1 == 2) at6 += ad[6];
            if (qwe1 == 3) at6 += ad[7];
            if (qwe1 == 4) at6 += ad[8];

            if (a0 == 1) at6 += ad[40];
            if (a1 == 1) at6 += ad[41];
            if (a2 == 1) at6 += ad[42];
            if (a3 == 1) at6 += ad[43];

            if (q0 == 1) at6 += ad[28];
            if (q1 == 1) at6 += ad[29];
            if (q2 == 1) at6 += ad[30];
            if (q3 == 1) at6 += ad[31];

            if (qwe4 == 0) at6 += ad[1];
            if (qwe4 == 1) at6 += ad[2];

            if (asd1 == 1) at6 += ad[33];
            if (asd2 == 1) at6 += ad[34];
            if (asd3 == 1) at6 += ad[35];
            if (asd4 == 1) at6 += ad[36];
            if (asd5 == 1) at6 += ad[37];
            if (asd6 == 1) at6 += ad[38];


            at6 += Convert.ToInt32(textBox48.Text) * ad[10];
            at6 += Convert.ToInt32(textBox47.Text) * ad[11];
            at6 += Convert.ToInt32(textBox46.Text) * ad[12];
            at6 += Convert.ToInt32(textBox45.Text) * ad[13];

            at6 += Convert.ToInt32(textBox44.Text) * ad[15];

            at6 += Convert.ToInt32(textBox42.Text) * ad[17];
            at6 += Convert.ToInt32(textBox41.Text) * ad[18];
            at6 += Convert.ToInt32(textBox40.Text) * ad[19];

            at6 += Convert.ToInt32(textBox43.Text) * ad[21];

            at6 += Convert.ToInt32(textBox39.Text) * ad[23];
            at6 += Convert.ToInt32(textBox38.Text) * ad[25];
            at6 += Convert.ToInt32(textBox37.Text) * ad[26];

            at6 += Convert.ToInt32(textBox49.Text) * ad[45];
        }

        private void t7()
        {
            
            MySqlConnection myConnection = new MySqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            int qwe1 = 0;
            if (radioButton98.Checked) qwe1 = 1;
            if (radioButton99.Checked) qwe1 = 2;
            if (radioButton100.Checked) qwe1 = 3;
            int qwe2 = 0;
            if (radioButton102.Checked) qwe2 = 1;
            if (radioButton103.Checked) qwe2 = 2;
            int qwe3 = 0;
            int a0 = 0, a1 = 0, a2 = 0, a3 = 0;
            if (checkBox28.Checked) a0 = 1;
            if (checkBox29.Checked) a1 = 1;
            if (checkBox30.Checked) a2 = 1;
            if (checkBox31.Checked) a3 = 1;
            qwe3 = compress(a0, a1, a2, a3, 0, 0, 0, 0, 0, 0);
            int qwe4 = 0;
            int q0 = 0, q1 = 0, q2 = 0, q3 = 0, q4 = 0, q5 = 0;
            if (checkBox32.Checked) q0 = 1;
            if (checkBox33.Checked) q1 = 1;
            if (checkBox34.Checked) q2 = 1;
            if (checkBox35.Checked) q3 = 1;
            if (checkBox36.Checked) q4 = 1;
            if (checkBox37.Checked) q5 = 1;
            qwe4 = compress(q0, q1, q2, q3, q4, q5, 0, 0, 0, 0);
            int qwe5 = 0;
            if (radioButton115.Checked) qwe5 = 1;
            if (radioButton116.Checked) qwe5 = 2;
            int qwe6 = 0;
            if (radioButton118.Checked) qwe6 = 1;
            if (radioButton119.Checked) qwe6 = 2;
            int qwe7 = 0;
            int w0 = 0, w1 = 0, w2 = 0;
            if (checkBox38.Checked) w0 = 1;
            if (checkBox39.Checked) w1 = 1;
            if (checkBox40.Checked) w2 = 1;
            qwe7 = compress(w0, w1, w2, 0, 0, 0, 0, 0, 0, 0);

            string CommandText;
            if (data == 0) CommandText = "INSERT INTO  `t7` (`nom`, `a1`, `a2`, `a3`, `a4`, `a5`, `a6`, `a7`, `d1`, `d2`) VALUES (" + nom + " , " +
                qwe1 + ", " + qwe2 + ", " + qwe3 + ", " + qwe4 + ", " + qwe5 + ", " + qwe6 + ", " + qwe7 +
                ", '" + textBox32.Text + "', '" + textBox31.Text + "')";
            else CommandText = "UPDATE t7 SET a1=" + qwe1 + ", a2=" + qwe2 + ", a3=" + qwe3 + ", a4=" + qwe4 + ", a5=" + qwe5 + ", a6=" + qwe6 + ", a7=" + qwe7 + ", d1='" + textBox32.Text + "', d2='" + textBox31.Text + "' WHERE nom=" + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();


            myConnection.Close();

            at7 = 0;
            myConnection.Open();
            CommandText = "select t7 from admin";
            myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            string qwert;
            double asdfg;
            int zxcvb;
            for (int i = 1; i <= 60; i++)
            {
                myDataReader.Read();
                qwert = myDataReader[0].ToString();
                zxcvb = Convert.ToInt32(qwert);
                asdfg = Convert.ToDouble(zxcvb);
                ad[i] = asdfg / 10000;
            }
            myConnection.Close();

            if (qwe1 == 0) at7 += ad[1];
            if (qwe1 == 1) at7 += ad[2];
            if (qwe1 == 2) at7 += ad[3];
            if (qwe1 == 3) at7 += ad[4];
           
            if (qwe2 == 0) at7 += ad[6];
            if (qwe2 == 1) at7 += ad[7];
            if (qwe2 == 2) at7 += ad[8];
            
            if (qwe3 == 0) at7 += ad[17];
            if (qwe3 == 1) at7 += ad[18];
            if (qwe3 == 2) at7 += ad[19];
            if (qwe3 == 3) at7 += ad[20];

            if (qwe4 == 0) at7 += ad[10];
            if (qwe4 == 1) at7 += ad[11];
            if (qwe4 == 2) at7 += ad[12];
            if (qwe4 == 3) at7 += ad[13];
            if (qwe4 == 4) at7 += ad[14];
            if (qwe4 == 5) at7 += ad[15];

            if (qwe5 == 0) at7 += ad[22];
            if (qwe5 == 1) at7 += ad[23];
            if (qwe5 == 2) at7 += ad[24];
            
            if (qwe6 == 0) at7 += ad[26];
            if (qwe6 == 1) at7 += ad[27];
            if (qwe6 == 2) at7 += ad[28];
            
            if (qwe7 == 0) at7 += ad[30];
            if (qwe7 == 1) at7 += ad[31];
            if (qwe7 == 2) at7 += ad[32];

        }

        private void t8()
        {
            
            MySqlConnection myConnection = new MySqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            int qwe1 = 0;
            if (radioButton76.Checked) qwe1 = 1;
            if (radioButton77.Checked) qwe1 = 2;
            int qwe2 = 0;
            if (radioButton79.Checked) qwe2 = 1;
            if (radioButton80.Checked) qwe2 = 2;
            if (radioButton81.Checked) qwe2 = 3;

            string CommandText;
            if (data == 0) CommandText = "INSERT INTO  `t8` (`nom`, `a1`, `a2`, `d`) VALUES (" + nom + " , " +
                qwe1 + ", " + qwe2 +
                ", " + Convert.ToInt32(textBox28.Text) + ")";
            else CommandText = "UPDATE t8 SET a1=" + qwe1 + ", a2=" + qwe2 + ", d=" + Convert.ToInt32(textBox28.Text) + " WHERE nom=" + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();


            myConnection.Close();

            at8 = 0;
            myConnection.Open();
            CommandText = "select t8 from admin";
            myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            string qwert;
            double asdfg;
            int zxcvb;
            for (int i = 1; i <= 60; i++)
            {
                myDataReader.Read();
                qwert = myDataReader[0].ToString();
                zxcvb = Convert.ToInt32(qwert);
                asdfg = Convert.ToDouble(zxcvb);
                ad[i] = asdfg / 10000;
            }
            myConnection.Close();

            if (qwe1 == 0) at8 += ad[3];
            if (qwe1 == 1) at8 += ad[4];
            if (qwe1 == 2) at8 += ad[5];

            if (qwe2 == 0) at8 += ad[7];
            if (qwe2 == 1) at8 += ad[8];
            if (qwe2 == 2) at8 += ad[9];
            if (qwe2 == 3) at8 += ad[10];

            at8 += Convert.ToInt32(textBox28.Text) * ad[1];

        }

        private void t9()
        {
            
            MySqlConnection myConnection = new MySqlConnection(connStr);
            try
            {
                myConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

            int qwe1 = 0;
            if (radioButton58.Checked) qwe1 = 1;
            int qwe2 = 0;
            if (radioButton60.Checked) qwe2 = 1;
            int qwe3 = 0;
            if (radioButton62.Checked) qwe3 = 1;
            int qwe4 = 0;
            if (radioButton64.Checked) qwe4 = 1;
            int qwe5 = 0;
            if (radioButton66.Checked) qwe5 = 1;
            int qwe6 = 0;
            if (radioButton68.Checked) qwe6 = 1;
            int qwe7 = 0;
            if (radioButton70.Checked) qwe7 = 1;
            int qwe8 = 0;
            if (radioButton72.Checked) qwe8 = 1;
            int qwe9 = 0;
            if (radioButton74.Checked) qwe9 = 1;
            string CommandText;
            if (data == 0) CommandText = "INSERT INTO  `t9` (`nom`, `a1`, `a2`, `a3`, `a4`, `a5`, `a6`, `a7`, `a8`, `a9`) VALUES (" + nom + " , " +
                qwe1 + ", " + qwe2 + ", " + qwe3 + ", " + qwe4 + ", " + qwe5 + ", " + qwe6 + ", " + qwe7 +
                ", " + qwe8 + ", " + qwe9 + ")";
            else CommandText = "UPDATE t9 SET a1=" + qwe1 + ", a2=" + qwe2 + ", a3=" + qwe3 + ", a4=" + qwe4 + ", a5=" + qwe5 + ", a6=" + qwe6 + ", a7=" + qwe7 + ", a8=" + qwe8 + ", a9=" + qwe9 + " WHERE nom=" + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();


            myConnection.Close();

            at9 = 0;
            myConnection.Open();
            CommandText = "select t9 from admin";
            myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            string qwert;
            double asdfg;
            int zxcvb;
            for (int i = 1; i <= 60; i++)
            {
                myDataReader.Read();
                qwert = myDataReader[0].ToString();
                zxcvb = Convert.ToInt32(qwert);
                asdfg = Convert.ToDouble(zxcvb);
                ad[i] = asdfg / 10000;
            }
            myConnection.Close();

            if (qwe1 == 0) at9 += ad[1];
            if (qwe1 == 1) at9 += ad[2];
            
            if (qwe2 == 0) at9 += ad[25];
            if (qwe2 == 1) at9 += ad[26];

            if (qwe3 == 0) at9 += ad[4];
            if (qwe3 == 1) at9 += ad[5];

            if (qwe4 == 0) at9 += ad[7];
            if (qwe4 == 1) at9 += ad[8];

            if (qwe5 == 0) at9 += ad[10];
            if (qwe5 == 1) at9 += ad[11];
        
            if (qwe6 == 0) at9 += ad[13];
            if (qwe6 == 1) at9 += ad[14];

            if (qwe7 == 0) at9 += ad[16];
            if (qwe7 == 1) at9 += ad[17];

            if (qwe8 == 0) at9 += ad[19];
            if (qwe8 == 1) at9 += ad[20];

            if (qwe9 == 0) at9 += ad[22];
            if (qwe9 == 1) at9 += ad[23];

        }

        //***************************************************************************************************************************
        //***** Блок загрузки
        //***************************************************************************************************************************
        private void z0(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "SELECT name, pol, vozr, mestorab, podrazd, dol FROM t0 where nom = " + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                textBox5.Text = myDataReader[0].ToString();
                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 1) radioButton2.Checked = true;
                else radioButton1.Checked = true;
                textBox1.Text = myDataReader[2].ToString();
                textBox2.Text = myDataReader[3].ToString();
                textBox3.Text = myDataReader[4].ToString();
                textBox4.Text = myDataReader[5].ToString();
            }
            myConnection.Close();

        }

        private void z1(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "SELECT zar, ycheb, tren, instr, vozm FROM t1 where nom = " + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) radioButton3.Checked = true;
                if (asd == 1) radioButton4.Checked = true;
                if (asd == 2) radioButton5.Checked = true;
                if (asd == 3) radioButton6.Checked = true;

                textBox6.Text = myDataReader[1].ToString();
                textBox7.Text = myDataReader[2].ToString();
                textBox8.Text = myDataReader[3].ToString();

                asd = Convert.ToInt32(myDataReader[4].ToString());
                if (asd == 0) radioButton7.Checked = true;
                if (asd == 1) radioButton8.Checked = true;
                if (asd == 2) radioButton9.Checked = true;
            }
            myConnection.Close();

        }

        private void z2(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "SELECT kv, obr, nap, naps, st1, st2, st3, kva, vuz, vuz1, vuz2, pu1, pu2, pu3, pu4, pu5, pu6, pu7, pu8, pu9, re1, re2, re3, re4 FROM t2 where nom = " + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) radioButton29.Checked = true;
                if (asd == 1) radioButton30.Checked = true;
                if (asd == 2) radioButton31.Checked = true;
                if (asd == 3) radioButton32.Checked = true;

                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 0) radioButton10.Checked = true;
                if (asd == 1) radioButton11.Checked = true;
                if (asd == 2) radioButton12.Checked = true;
                if (asd == 3) radioButton13.Checked = true;
                if (asd == 4) radioButton14.Checked = true;
                if (asd == 5) radioButton15.Checked = true;
                if (asd == 6) radioButton16.Checked = true;
                if (asd == 7) radioButton17.Checked = true;
                if (asd == 8) radioButton18.Checked = true;
                if (asd == 9) radioButton19.Checked = true;
                if (asd == 10) radioButton20.Checked = true;

                asd = Convert.ToInt32(myDataReader[2].ToString());
                if (decompress0(asd)==1) checkBox7.Checked = true;
                if (decompress1(asd) == 1) checkBox8.Checked = true;
                if (decompress2(asd) == 1) checkBox9.Checked = true;
                if (decompress3(asd) == 1) checkBox10.Checked = true;
                if (decompress4(asd) == 1) checkBox11.Checked = true;
                if (decompress5(asd) == 1) checkBox12.Checked = true;
                if (decompress6(asd) == 1) checkBox13.Checked = true;
                if (decompress7(asd) == 1) checkBox14.Checked = true;
                if (decompress8(asd) == 1) checkBox15.Checked = true;

                textBox9.Text = myDataReader[3].ToString();

                textBox11.Text = myDataReader[4].ToString();
                textBox12.Text = myDataReader[5].ToString();
                textBox13.Text = myDataReader[6].ToString();

                asd = Convert.ToInt32(myDataReader[7].ToString());
                if (asd == 0) radioButton33.Checked = true;
                if (asd == 1) radioButton34.Checked = true;
                if (asd == 2) radioButton35.Checked = true;
                if (asd == 3) radioButton36.Checked = true;

                textBox10.Text = myDataReader[8].ToString();
                textBox51.Text = myDataReader[9].ToString();
                textBox52.Text = myDataReader[10].ToString();

                textBox14.Text = myDataReader[11].ToString();
                textBox15.Text = myDataReader[12].ToString();
                textBox16.Text = myDataReader[13].ToString();
                textBox17.Text = myDataReader[14].ToString();
                textBox18.Text = myDataReader[15].ToString();
                textBox19.Text = myDataReader[16].ToString();
                textBox20.Text = myDataReader[17].ToString();
                textBox21.Text = myDataReader[18].ToString();
                textBox22.Text = myDataReader[19].ToString();

                textBox23.Text = myDataReader[20].ToString();
                textBox24.Text = myDataReader[21].ToString();
                textBox25.Text = myDataReader[22].ToString();
                textBox26.Text = myDataReader[23].ToString();

            }
            myConnection.Close();

        }

        private void z3(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "SELECT lid, pl, avt, eks, chu, sot, con, otv FROM t3 where nom = " + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                textBox27.Text = myDataReader[0].ToString();

                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 0) radioButton37.Checked = true;
                if (asd == 1) radioButton38.Checked = true;
                if (asd == 2) radioButton39.Checked = true;

                asd = Convert.ToInt32(myDataReader[2].ToString());
                if (asd == 0) radioButton40.Checked = true;
                if (asd == 1) radioButton41.Checked = true;

                asd = Convert.ToInt32(myDataReader[3].ToString());
                if (asd == 0) radioButton42.Checked = true;
                if (asd == 1) radioButton43.Checked = true;

                asd = Convert.ToInt32(myDataReader[4].ToString());
                if (asd == 0) radioButton44.Checked = true;
                if (asd == 1) radioButton45.Checked = true;
                if (asd == 2) radioButton46.Checked = true;

                asd = Convert.ToInt32(myDataReader[5].ToString());
                if (asd == 0) radioButton47.Checked = true;
                if (asd == 1) radioButton48.Checked = true;
                if (asd == 2) radioButton49.Checked = true;

                asd = Convert.ToInt32(myDataReader[6].ToString());
                if (asd == 0) radioButton50.Checked = true;
                if (asd == 1) radioButton51.Checked = true;
                if (asd == 2) radioButton52.Checked = true;
                if (asd == 3) radioButton53.Checked = true;

                asd = Convert.ToInt32(myDataReader[7].ToString());
                if (asd == 0) radioButton54.Checked = true;
                if (asd == 1) radioButton55.Checked = true;
                if (asd == 2) radioButton56.Checked = true;


            }
            myConnection.Close();

        }

        private void z4(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "SELECT tem, sem, obs, kom, obu, kol, ada, bre1, bre2, bre3, oce, kri, sam, ste, sov, zam FROM t4 where nom = " + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) radioButton140.Checked = true;
                if (asd == 1) radioButton139.Checked = true;
                if (asd == 2) radioButton138.Checked = true;
                if (asd == 3) radioButton137.Checked = true;

                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 0) radioButton136.Checked = true;
                if (asd == 1) radioButton135.Checked = true;
                if (asd == 2) radioButton134.Checked = true;
                if (asd == 3) radioButton133.Checked = true;

                asd = Convert.ToInt32(myDataReader[2].ToString());
                if (asd == 0) radioButton132.Checked = true;
                if (asd == 1) radioButton131.Checked = true;
                if (asd == 2) radioButton130.Checked = true;

                asd = Convert.ToInt32(myDataReader[3].ToString());
                if (asd == 0) radioButton129.Checked = true;
                if (asd == 1) radioButton128.Checked = true;
                if (asd == 2) radioButton127.Checked = true;
                if (asd == 3) radioButton126.Checked = true;

                asd = Convert.ToInt32(myDataReader[4].ToString());
                if (asd == 0) radioButton125.Checked = true;
                if (asd == 1) radioButton124.Checked = true;
                if (asd == 2) radioButton123.Checked = true;

                asd = Convert.ToInt32(myDataReader[5].ToString());
                if (asd == 0) radioButton159.Checked = true;
                if (asd == 1) radioButton158.Checked = true;
                if (asd == 2) radioButton157.Checked = true;

                asd = Convert.ToInt32(myDataReader[6].ToString());
                if (asd == 0) radioButton150.Checked = true;
                if (asd == 1) radioButton149.Checked = true;
                if (asd == 2) radioButton148.Checked = true;

                textBox36.Text = myDataReader[7].ToString();
                textBox35.Text = myDataReader[8].ToString();
                textBox34.Text = myDataReader[9].ToString();

                asd = Convert.ToInt32(myDataReader[10].ToString());
                if (asd == 0) radioButton147.Checked = true;
                if (asd == 1) radioButton146.Checked = true;
                if (asd == 2) radioButton145.Checked = true;

                asd = Convert.ToInt32(myDataReader[11].ToString());
                if (asd == 0) radioButton154.Checked = true;
                if (asd == 1) radioButton153.Checked = true;

                asd = Convert.ToInt32(myDataReader[12].ToString());
                if (asd == 0) radioButton152.Checked = true;
                if (asd == 1) radioButton151.Checked = true;

                asd = Convert.ToInt32(myDataReader[13].ToString());
                if (asd == 0) radioButton156.Checked = true;
                if (asd == 1) radioButton155.Checked = true;

                textBox33.Text = myDataReader[14].ToString();

                asd = Convert.ToInt32(myDataReader[15].ToString());
                if (asd == 0) radioButton144.Checked = true;
                if (asd == 1) radioButton143.Checked = true;
                if (asd == 2) radioButton142.Checked = true;
                if (asd == 3) radioButton141.Checked = true;

            }
            myConnection.Close();

        }

        private void z5(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "SELECT pra, pras, nav, navs, pat, vla, ych  FROM t5 where nom = " + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (decompress0(asd) == 1) checkBox16.Checked = true;
                if (decompress1(asd) == 1) checkBox17.Checked = true;
                if (decompress2(asd) == 1) checkBox18.Checked = true;
                if (decompress3(asd) == 1) checkBox19.Checked = true;

                textBox29.Text = myDataReader[1].ToString();

                asd = Convert.ToInt32(myDataReader[2].ToString());
                if (asd == 0) radioButton86.Checked = true;
                if (asd == 1) radioButton87.Checked = true;
                if (asd == 2) radioButton88.Checked = true;
                if (asd == 3) radioButton89.Checked = true;

                textBox30.Text = myDataReader[3].ToString();

                asd = Convert.ToInt32(myDataReader[4].ToString());
                if (asd == 0) radioButton90.Checked = true;
                if (asd == 1) radioButton91.Checked = true;

                asd = Convert.ToInt32(myDataReader[5].ToString());
                if (asd == 0) radioButton92.Checked = true;
                if (asd == 1) radioButton93.Checked = true;

                asd = Convert.ToInt32(myDataReader[6].ToString());
                if (asd == 0) radioButton94.Checked = true;
                if (asd == 1) radioButton95.Checked = true;
                if (asd == 2) radioButton96.Checked = true;

            }
            myConnection.Close();

        }

        private void z6(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "SELECT a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, b1, b2, b3, b4, b5, b6, c1, c2, c3, c4, d  FROM t6 where nom = " + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                textBox48.Text = myDataReader[0].ToString();
                textBox47.Text = myDataReader[1].ToString();
                textBox46.Text = myDataReader[2].ToString();
                textBox45.Text = myDataReader[3].ToString();
                textBox44.Text = myDataReader[4].ToString();
                textBox42.Text = myDataReader[5].ToString();
                textBox41.Text = myDataReader[6].ToString();
                textBox40.Text = myDataReader[7].ToString();
                textBox43.Text = myDataReader[8].ToString();
                textBox39.Text = myDataReader[9].ToString();
                textBox38.Text = myDataReader[10].ToString();
                textBox37.Text = myDataReader[11].ToString();
                textBox49.Text = myDataReader[12].ToString();

                asd = Convert.ToInt32(myDataReader[13].ToString());
                if (asd == 1) checkBox1.Checked = true;

                asd = Convert.ToInt32(myDataReader[14].ToString());
                if (asd == 1) checkBox2.Checked = true;

                asd = Convert.ToInt32(myDataReader[15].ToString());
                if (asd == 1) checkBox3.Checked = true;

                asd = Convert.ToInt32(myDataReader[16].ToString());
                if (asd == 1) checkBox4.Checked = true;

                asd = Convert.ToInt32(myDataReader[17].ToString());
                if (asd == 1) checkBox5.Checked = true;

                asd = Convert.ToInt32(myDataReader[18].ToString());
                if (asd == 1) checkBox6.Checked = true;
                
                asd = Convert.ToInt32(myDataReader[19].ToString());
                if (asd == 0) radioButton172.Checked = true;
                if (asd == 1) radioButton171.Checked = true;
                if (asd == 2) radioButton170.Checked = true;
                if (asd == 3) radioButton169.Checked = true;
                if (asd == 4) radioButton168.Checked = true;

                asd = Convert.ToInt32(myDataReader[20].ToString());
                if (decompress0(asd) == 1) checkBox20.Checked = true;
                if (decompress1(asd) == 1) checkBox21.Checked = true;
                if (decompress2(asd) == 1) checkBox22.Checked = true;
                if (decompress3(asd) == 1) checkBox23.Checked = true;

                asd = Convert.ToInt32(myDataReader[21].ToString());
                if (decompress0(asd) == 1) checkBox24.Checked = true;
                if (decompress1(asd) == 1) checkBox25.Checked = true;
                if (decompress2(asd) == 1) checkBox26.Checked = true;
                if (decompress3(asd) == 1) checkBox27.Checked = true;

                asd = Convert.ToInt32(myDataReader[22].ToString());
                if (asd == 0) radioButton174.Checked = true;
                if (asd == 1) radioButton173.Checked = true;

                textBox50.Text = myDataReader[23].ToString();

            }
            myConnection.Close();

        }

        private void z7(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "SELECT a1, a2, a3, a4, a5, a6, a7, d1, d2 FROM t7 where nom = " + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) radioButton97.Checked = true;
                if (asd == 1) radioButton98.Checked = true;
                if (asd == 2) radioButton99.Checked = true;
                if (asd == 3) radioButton100.Checked = true;

                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 0) radioButton101.Checked = true;
                if (asd == 1) radioButton102.Checked = true;
                if (asd == 2) radioButton103.Checked = true;

                asd = Convert.ToInt32(myDataReader[2].ToString());
                if (decompress0(asd) == 1) checkBox28.Checked = true;
                if (decompress1(asd) == 1) checkBox29.Checked = true;
                if (decompress2(asd) == 1) checkBox30.Checked = true;
                if (decompress3(asd) == 1) checkBox31.Checked = true;

                asd = Convert.ToInt32(myDataReader[3].ToString());
                if (decompress0(asd) == 1) checkBox32.Checked = true;
                if (decompress1(asd) == 1) checkBox33.Checked = true;
                if (decompress2(asd) == 1) checkBox34.Checked = true;
                if (decompress3(asd) == 1) checkBox35.Checked = true;
                if (decompress4(asd) == 1) checkBox36.Checked = true;
                if (decompress5(asd) == 1) checkBox37.Checked = true;

                asd = Convert.ToInt32(myDataReader[4].ToString());
                if (asd == 0) radioButton114.Checked = true;
                if (asd == 1) radioButton115.Checked = true;
                if (asd == 2) radioButton116.Checked = true;

                asd = Convert.ToInt32(myDataReader[5].ToString());
                if (asd == 0) radioButton117.Checked = true;
                if (asd == 1) radioButton118.Checked = true;
                if (asd == 2) radioButton119.Checked = true;

                asd = Convert.ToInt32(myDataReader[6].ToString());
                if (decompress0(asd) == 1) checkBox38.Checked = true;
                if (decompress1(asd) == 1) checkBox39.Checked = true;
                if (decompress2(asd) == 1) checkBox40.Checked = true;

                textBox32.Text = myDataReader[7].ToString();
                textBox31.Text = myDataReader[8].ToString();

            }
            myConnection.Close();

        }

        private void z8(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "SELECT a1, a2, d FROM t8 where nom = " + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) radioButton75.Checked = true;
                if (asd == 1) radioButton76.Checked = true;
                if (asd == 2) radioButton77.Checked = true;
                
                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 0) radioButton78.Checked = true;
                if (asd == 1) radioButton79.Checked = true;
                if (asd == 2) radioButton80.Checked = true;
                if (asd == 3) radioButton81.Checked = true;

                textBox28.Text = myDataReader[2].ToString();

            }
            myConnection.Close();

        }

        private void z9(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "SELECT a1, a2, a3, a4, a5, a6, a7, a8, a9 FROM t9 where nom = " + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) radioButton57.Checked = true;
                if (asd == 1) radioButton58.Checked = true;
                
                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 0) radioButton59.Checked = true;
                if (asd == 1) radioButton60.Checked = true;

                asd = Convert.ToInt32(myDataReader[2].ToString());
                if (asd == 0) radioButton61.Checked = true;
                if (asd == 1) radioButton62.Checked = true;

                asd = Convert.ToInt32(myDataReader[3].ToString());
                if (asd == 0) radioButton63.Checked = true;
                if (asd == 1) radioButton64.Checked = true;

                asd = Convert.ToInt32(myDataReader[4].ToString());
                if (asd == 0) radioButton65.Checked = true;
                if (asd == 1) radioButton66.Checked = true;

                asd = Convert.ToInt32(myDataReader[5].ToString());
                if (asd == 0) radioButton67.Checked = true;
                if (asd == 1) radioButton68.Checked = true;

                asd = Convert.ToInt32(myDataReader[6].ToString());
                if (asd == 0) radioButton69.Checked = true;
                if (asd == 1) radioButton70.Checked = true;

                asd = Convert.ToInt32(myDataReader[7].ToString());
                if (asd == 0) radioButton71.Checked = true;
                if (asd == 1) radioButton72.Checked = true;

                asd = Convert.ToInt32(myDataReader[8].ToString());
                if (asd == 0) radioButton73.Checked = true;
                if (asd == 1) radioButton74.Checked = true;

            }
            myConnection.Close();

        }
    }
}
