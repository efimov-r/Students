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
using System.Globalization;
using System.Threading;

using System.Xml.Serialization;
using System.IO;

namespace Stud
{
    public partial class Form1 : Form
    {
        Props props = new Props(); //экземпляр класса с настройками///////////////////////////////////////
        MySqlDataAdapter da;
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

        int s1 = 0, s2 = 0, s3 = 0, s4 = 0, s5 = 0, ss=0; // переменные для построения стольб. диаг., значение и количество

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) //добавление
        {
            Form2 newForm = new Form2(0);
            newForm.ShowDialog();
            reload();
        }

        private void button3_Click(object sender, EventArgs e) //админка
        {
            admin newForm = new admin();
            newForm.ShowDialog();
            reload();
        }

        private void button6_Click(object sender, EventArgs e) //очистить поле с столб. диаг.
        {
            s1 = 0;
            s2 = 0;
            s3 = 0;
            s4 = 0;
            s5 = 0;
            ss = 0;
            reload();
            chart1.Series[0].Points.Clear();
        }

        private void button7_Click(object sender, EventArgs e) //добавить к столб. диаг.
        {
            string qaz = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string qaz2 = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "select nom from t where fio = '" + qaz + "' AND date = '" + qaz2 + "';";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            string qwe;
            int zxc;
            myDataReader.Read();
            qwe = myDataReader[0].ToString();
            zxc = Convert.ToInt32(qwe);
            myConnection.Close();

            if (ss == 0)
            {
                s1 = zxc;
                ss++;
            }
            else
            if (ss == 1)
            {
                s2 = zxc;
                ss++;
            }
            else
            if (ss == 2)
            {
                s3 = zxc;
                ss++;
            }
            else
            if (ss == 3)
            {
                s4 = zxc;
                ss++;
            }
            else
            if (ss == 4)
            {
                s5 = zxc;
                ss++;
            }
            reload();
            postroit();
        }

        private void postroit() //построить столб. диаг.
        {
            int i = ss;
            int data = 0;
            chart1.Series[0].Points.Clear();
            while(i!=0)
            {
                double a = 0;
                MySqlConnection myConnection = new MySqlConnection(connStr);
                myConnection.Open();

                if (i == 1) data = s1;
                if (i == 2) data = s2;
                if (i == 3) data = s3;
                if (i == 4) data = s4;
                if (i == 5) data = s5;

                string CommandText = "SELECT b FROM t where nom = " + data + ";";
                MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
                MySqlDataReader myDataReader = myCommand.ExecuteReader();

                while (myDataReader.Read())
                {
                    a = Convert.ToDouble(myDataReader[0].ToString()) / 10000;
                }
                myConnection.Close();

                chart1.Series[0].Points.AddXY(i, a);
                

                i--;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            teatovaua newFo = new teatovaua();
            newFo.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            props.ReadXml();
            if(props.Fields.fivestart == true)
            {
                teatovaua newFor = new teatovaua();
                newFor.ShowDialog();

                props.ReadXml();
                props.Fields.fivestart = false;
                props.WriteXml();
            }

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

            reload();
        }

        private void reload() //перезагрузка, загрузка формы
        {
            

            //dataGridView1.Width = 500;
            //dataGridView1.Height = 250;
            //dataGridView1.Dock = DockStyle.Fill;

            // Объект DataAdapter выступает в роли посредника при взаимодействии базы данных
            // и хранящегося в памяти объекта DataTable
            //da = new MySqlDataAdapter("SELECT fio, a1, a2, a3, a4, a5, a6, a7, a8, a9, b FROM t", connStr);
            da = new MySqlDataAdapter("SELECT fio, date, fio, fio, fio, fio, fio, fio, fio, fio, fio, fio FROM t", connStr);

            // Объект CommandBuilder автоматически выполняет команды UPDATE и INSERT
            MySqlCommandBuilder cb = new MySqlCommandBuilder(da);

            // Объект DataTable отслеживает и сохраняет в памяти изменения
            DataTable dt = new DataTable();

            // Теперь заполняем объект DataTable данными
            da.Fill(dt);

            // Привязываем элемент управления DataGridView к объекту DataTable
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "ФИО";
            dataGridView1.Columns[1].HeaderText = "Дата измен.";
            dataGridView1.Columns[2].HeaderText = "фин. пот.";
            dataGridView1.Columns[3].HeaderText = "интеллект. пот.";
            dataGridView1.Columns[4].HeaderText = "орг. упр.";
            dataGridView1.Columns[5].HeaderText = "маркетинг";
            dataGridView1.Columns[6].HeaderText = "информац.";
            dataGridView1.Columns[7].HeaderText = "опыт";
            dataGridView1.Columns[8].HeaderText = "внеш. климат";
            dataGridView1.Columns[9].HeaderText = "псих. физич.";
            dataGridView1.Columns[10].HeaderText = "культура";
            dataGridView1.Columns[11].HeaderText = "общий";



            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection myConnection = new MySqlConnection(connStr);  /////заполнение данными
            string qwe;
            double asd;
            int zxc;
            int i = 0;
            string CommandText;
            MySqlCommand myCommand;
            MySqlDataReader myDataReader;
            for (int ii = 1; ii <= 9; ii++)
            {
                myConnection.Open();

                CommandText = "select a" + ii + " from t";
                myCommand = new MySqlCommand(CommandText, myConnection);
                myDataReader = myCommand.ExecuteReader();

                i = 0;
                while (myDataReader.Read())
                {
                    qwe = myDataReader[0].ToString();
                    zxc = Convert.ToInt32(qwe);
                    asd = Convert.ToDouble(zxc);
                    asd = asd / 10000;
                    qwe = Convert.ToString(asd);
                    dataGridView1.Rows[i].Cells[ii+1].Value = qwe;
                    i++;
                }

                myConnection.Close();
            }

            myConnection.Open();

            CommandText = "select b from t";
            myCommand = new MySqlCommand(CommandText, myConnection);
            myDataReader = myCommand.ExecuteReader();
            i = 0;

            while (myDataReader.Read())
            {
                qwe = myDataReader[0].ToString();
                zxc = Convert.ToInt32(qwe);
                asd = Convert.ToDouble(zxc);
                asd = asd / 10000;
                qwe = Convert.ToString(asd);
                dataGridView1.Rows[i].Cells[11].Value = qwe;
                i++;
            }

            myConnection.Close();
            //////////////////////////////////////////////////////////////////////////////////////закончили

            dataGridView1.ReadOnly = true;


            string fio = "", date = "";
            if (s1 != 0) //первая сирока для сравнение
            {
                myConnection = new MySqlConnection(connStr);
                myConnection.Open();

                CommandText = "SELECT fio, date FROM t where nom = " + s1 + ";";
                myCommand = new MySqlCommand(CommandText, myConnection);
                myDataReader = myCommand.ExecuteReader();

                while (myDataReader.Read())
                {
                    fio = myDataReader[0].ToString();
                    date = myDataReader[1].ToString();
                }
                myConnection.Close();

                textBox1.Text = fio + " Изменен: " + date;
            }
            else textBox1.Text = "";

            if (s2 != 0) //вторая строка для сравнения
            {
                myConnection = new MySqlConnection(connStr);
                myConnection.Open();

                CommandText = "SELECT fio, date FROM t where nom = " + s2 + ";";
                myCommand = new MySqlCommand(CommandText, myConnection);
                myDataReader = myCommand.ExecuteReader();

                while (myDataReader.Read())
                {
                    fio = myDataReader[0].ToString();
                    date = myDataReader[1].ToString();
                }
                myConnection.Close();

                textBox2.Text = fio + " Изменен: " + date;
            }
            else textBox2.Text = "";

            if (s3 != 0) //третья строка для сравнения
            {
                myConnection = new MySqlConnection(connStr);
                myConnection.Open();

                CommandText = "SELECT fio, date FROM t where nom = " + s3 + ";";
                myCommand = new MySqlCommand(CommandText, myConnection);
                myDataReader = myCommand.ExecuteReader();

                while (myDataReader.Read())
                {
                    fio = myDataReader[0].ToString();
                    date = myDataReader[1].ToString();
                }
                myConnection.Close();

                textBox3.Text = fio + " Изменен: " + date;
            }
            else textBox3.Text = "";

            if (s4 != 0) //четвертая строка для сравнения
            {
                myConnection = new MySqlConnection(connStr);
                myConnection.Open();

                CommandText = "SELECT fio, date FROM t where nom = " + s4 + ";";
                myCommand = new MySqlCommand(CommandText, myConnection);
                myDataReader = myCommand.ExecuteReader();

                while (myDataReader.Read())
                {
                    fio = myDataReader[0].ToString();
                    date = myDataReader[1].ToString();
                }
                myConnection.Close();

                textBox4.Text = fio + " Изменен: " + date;
            }
            else textBox4.Text = "";

            if (s5 != 0) //пятая строка для сравнения
            {
                myConnection = new MySqlConnection(connStr);
                myConnection.Open();

                CommandText = "SELECT fio, date FROM t where nom = " + s5 + ";";
                myCommand = new MySqlCommand(CommandText, myConnection);
                myDataReader = myCommand.ExecuteReader();

                while (myDataReader.Read())
                {
                    fio = myDataReader[0].ToString();
                    date = myDataReader[1].ToString();
                }
                myConnection.Close();

                textBox5.Text = fio + " Изменен: " + date;
            }
            else textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) // изменить
        {
            string qaz = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string qaz2 = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "select nom from t where fio = '" + qaz + "' AND date = '" + qaz2 + "';";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            string qwe;
            int zxc;
            myDataReader.Read();
                qwe = myDataReader[0].ToString();
                zxc = Convert.ToInt32(qwe);
            myConnection.Close();

            Form2 newForm = new Form2(zxc);
            newForm.ShowDialog();
            reload();
        }

        private void button4_Click(object sender, EventArgs e) //удалить
        {
            string qaz = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string qaz2 = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "delete from t where fio = '" + qaz + "' AND date = '" + qaz2 + "';";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            reload();
        }

        private void button5_Click(object sender, EventArgs e)//сравнение
        {
            string qaz = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string qaz2 = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "select nom from t where fio = '" + qaz + "' AND date = '" + qaz2 + "';";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            string qwe;
            int zxc;
            myDataReader.Read();
            qwe = myDataReader[0].ToString();
            zxc = Convert.ToInt32(qwe);
            myConnection.Close();

            Sravn newForm = new Sravn(zxc);
            newForm.ShowDialog();
        }
    }

    public class PropsFields
    {
        public String XMLFileName = Application.StartupPath + "\\settings.xml";
        //Чтобы добавить настройку в программу просто добавьте туда строку вида -
        //public ТИП ИМЯ_ПЕРЕМЕННОЙ = значение_переменной_по_умолчанию;
        public Boolean fivestart = true;

        public string serverName = "localhost"; // Адрес сервера (для локальной базы пишите "localhost")
        public string userName = "root"; // Имя пользователя
        public string dbName = ""; //Имя базы данных
        public string port = "3306"; // Порт для подключения
        public string password = ""; // Пароль для подключения
    }
    //Класс работы с настройками
    public class Props
    {
        public PropsFields Fields;

        public Props()
        {
            Fields = new PropsFields();
        }
        //Запись настроек в файл
        public void WriteXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(PropsFields));

            TextWriter writer = new StreamWriter(Fields.XMLFileName);
            ser.Serialize(writer, Fields);
            writer.Close();
        }
        //Чтение насроек из файла
        public void ReadXml()
        {
            if (File.Exists(Fields.XMLFileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(PropsFields));
                TextReader reader = new StreamReader(Fields.XMLFileName);
                Fields = ser.Deserialize(reader) as PropsFields;
                reader.Close();
            }
            else
            {
                //можно написать вывод сообщения если файла не существует
            }
        }
    }
}
