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
    public partial class Sravn : Form
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



        public Sravn(int data)
        {
            InitializeComponent();
            this.data = data;
        }

        int data;

        private void Sravn_Load(object sender, EventArgs e)
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

            double a1 = 0, a2 = 0, a3 = 0, a4 = 0, a5 = 0, a6 = 0, a7 = 0, a8 = 0, a9 = 0;
            string fio = "", date = "";
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "SELECT fio, date, a1, a2, a3, a4, a5, a6, a7, a8, a9 FROM t where nom = " + data + ";";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                fio = myDataReader[0].ToString();
                date = myDataReader[1].ToString();
                a1 = Convert.ToDouble(myDataReader[2].ToString()) / 10000;
                a2 = Convert.ToDouble(myDataReader[3].ToString()) / 10000;
                a3 = Convert.ToDouble(myDataReader[4].ToString()) / 10000;
                a4 = Convert.ToDouble(myDataReader[5].ToString()) / 10000;
                a5 = Convert.ToDouble(myDataReader[6].ToString()) / 10000;
                a6 = Convert.ToDouble(myDataReader[7].ToString()) / 10000;
                a7 = Convert.ToDouble(myDataReader[8].ToString()) / 10000;
                a8 = Convert.ToDouble(myDataReader[9].ToString()) / 10000;
                a9 = Convert.ToDouble(myDataReader[10].ToString()) / 10000;
            }
            myConnection.Close();

            this.Text = fio + " Изменен: " + date;

            chart1.Series[0].Points.AddXY(0, a1);
            chart1.Series[0].Points[0].LegendText = "Финансовый потенциал";
            chart1.Series[0].Points.AddXY(1, a2);
            chart1.Series[0].Points[1].LegendText = "Интеллектуальный потенциал";
            chart1.Series[0].Points.AddXY(2, a3);
            chart1.Series[0].Points[2].LegendText = "Организационно-управленческий потенциал";
            chart1.Series[0].Points.AddXY(3, a4);
            chart1.Series[0].Points[3].LegendText = "Маркетинг";
            chart1.Series[0].Points.AddXY(4, a5);
            chart1.Series[0].Points[4].LegendText = "Информационный потенциал";
            chart1.Series[0].Points.AddXY(5, a6);
            chart1.Series[0].Points[5].LegendText = "Опыт";
            chart1.Series[0].Points.AddXY(6, a7);
            chart1.Series[0].Points[6].LegendText = "Внешний климат";
            chart1.Series[0].Points.AddXY(7, a8);
            chart1.Series[0].Points[7].LegendText = "Псих. физич.";
            chart1.Series[0].Points.AddXY(8, a9);
            chart1.Series[0].Points[8].LegendText = "Культура";
        }
    }

    
}
