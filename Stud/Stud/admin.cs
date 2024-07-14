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
    public partial class admin : Form
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


        int sost = 0;


        double at1 = 0, at2 = 0, at3 = 0, at4 = 0, at5 = 0, at6 = 0, at7 = 0, at8 = 0, at9 = 0; //балл за каждую часть
        int nom; //номер куда писать строку новую будем
        double[] ad = new double[61]; //веса


        public admin()
        {
            InitializeComponent();
        }

        

        private void admin_Load(object sender, EventArgs e)
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


            f1();
            sost = 1;
            button2.Enabled = false;
            load(1);
    }

        private void load(int t)
        {
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();

            string CommandText = "select t" + t + " from admin";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            string qwe;
            double asd;
            int zxc;
            for (int i = 1; i <= 60; i++)
            {
                myDataReader.Read();
                qwe = myDataReader[0].ToString();
                zxc = Convert.ToInt32(qwe);
                asd = Convert.ToDouble(zxc);
                asd = asd / 10000;
                qwe = Convert.ToString(asd);
                this.Controls["textbox" + i.ToString()].Text = qwe;
            }
            myConnection.Close();
        }

        private void save(int t)
        {
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();
            string CommandText;
            MySqlCommand myCommand;
            int asd;
            double qwe;
            for (int i = 1; i <= 60; i++)
            {
                //asd = Convert.ToInt32(this.Controls["textbox" + i.ToString()].Text);
                qwe = Convert.ToDouble(this.Controls["textbox" + i.ToString()].Text);
                qwe = qwe * 10000;
                asd = Convert.ToInt32(qwe);
                CommandText = "UPDATE admin SET t" + t + "=" + asd + " WHERE nom=" + i + ";";
                myCommand = new MySqlCommand(CommandText, myConnection);
                myCommand.ExecuteNonQuery();

            }
            myConnection.Close();

        }

        private void f1()
        {
            groupBox2.Visible = false;
            this.Text = "Оценка финансового потенциала";
            clear();
            label1.Text = "Заработок до 15 тыс. руб.";
            label2.Text = "15-25 тыс. руб.";
            label3.Text = "25-50 тыс. руб.";
            label4.Text = "50 и более тыс. руб.";
            label5.Text = "";
            label6.Text = "вес тыс. руб. дохода, потрач. на учебную литературу";
            label7.Text = "вес тыс. руб. дохода, потрач. на участие в тренингах";
            label8.Text = "вес тыс. руб. дохода, потрач. на преобретения инструментария";
            label9.Text = "";
            label10.Text = "безграничное привлечение доп. финанс. средств";
            label11.Text = "ограниченное привлечение доп. финанс. средств";
            label12.Text = "нет возможности привлечение доп. финанс. средств";

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            

        }

        private void f2()
        {
            groupBox2.Visible = true;
            this.Text = "Оценка интеллектуального потенциала";
            clear();
            label1.Text = "среднее образование";
            label2.Text = "средне-профессиональное образование";
            label3.Text = "незаконченное высшее образование";
            label4.Text = "бакалавр";
            label5.Text = "специалист";
            label6.Text = "магистр";
            label7.Text = "2 высших и более";
            label8.Text = "аспирант";
            label9.Text = "кандидат наук";
            label10.Text = "доктор наук";
            label11.Text = "академик";
            label12.Text = "";
            label13.Text = "гуманитарное направление";
            label14.Text = "экономическое направление";
            label15.Text = "юридическое направлениее";
            label16.Text = "творческое направление";
            label17.Text = "техническое направление";
            label18.Text = "педагогическое направление";
            label19.Text = "медицинское направление";
            label20.Text = "сельскохозяйственное направление";
            label21.Text = "иное направление";
            label22.Text = "";
            label23.Text = "один год общего стажа работы";
            label24.Text = "один год стажа в инновационной сфере";
            label25.Text = "один год стажа в научной сфере";
            label26.Text = "один тезис";
            label27.Text = "одна статья РИНЦ";
            label28.Text = "одна статья ВАК";
            label29.Text = "одна статья SKOPUS";
            label30.Text = "одна статья Web of science";
            label31.Text = "одна личная монография";
            label32.Text = "одна монография в соавторстве";
            label33.Text = "одно личное учебное пособие";
            label34.Text = "одно учебное пособие в соавторстве";
            label35.Text = "";
            label36.Text = "одна рецензия оппонирование диссертации";
            label37.Text = "одна рецензия монографии, уч. пособ. и т. п.";
            label38.Text = "одна рецензия автореферата диссертации";
            label39.Text = "одна рецензия статьи";
            label40.Text = "";
            label41.Text = "ежегод. повыш. квалиф. в профессиональной сфере";
            label42.Text = "раз в 3 года повыш. квалиф. в профессиональной сфере";
            label43.Text = "раз в 5 лет квалиф. в профессиональной сфере";
            label44.Text = "никогда не повыш. квалиф. в профессиональной сфере";
            label45.Text = "ежегод. повыш. квалиф. в другой сфере";
            label46.Text = "раз в 3 года повыш. квалиф. в другой сфере";
            label47.Text = "раз в 5 лет повыш. квалиф. в другой сфере";
            label48.Text = "никогда не повыш. квалиф. в другой сфере";

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
            textBox15.Visible = true;
            textBox16.Visible = true;
            textBox17.Visible = true;
            textBox18.Visible = true;
            textBox19.Visible = true;
            textBox20.Visible = true;
            textBox21.Visible = true;
            textBox23.Visible = true;
            textBox24.Visible = true;
            textBox25.Visible = true;
            textBox26.Visible = true;
            textBox27.Visible = true;
            textBox28.Visible = true;
            textBox29.Visible = true;
            textBox30.Visible = true;
            textBox31.Visible = true;
            textBox32.Visible = true;
            textBox33.Visible = true;
            textBox34.Visible = true;
            textBox36.Visible = true;
            textBox37.Visible = true;
            textBox38.Visible = true;
            textBox39.Visible = true;
            textBox41.Visible = true;
            textBox42.Visible = true;
            textBox43.Visible = true;
            textBox44.Visible = true;
            textBox45.Visible = true;
            textBox46.Visible = true;
            textBox47.Visible = true;
            textBox48.Visible = true;
           
        }

        private void f3()
        {
            groupBox2.Visible = true;
            this.Text = "Организационно-управленчекий потенциал";
            clear();
            label1.Text = "вес одного балла стремления к лидерству";
            label2.Text = "";
            label3.Text = "планирую деятельность и руководствуюсь";
            label4.Text = "планирую деятельность и не руководствуюсь";
            label5.Text = "не планирую";
            label6.Text = "";
            label7.Text = "способен к созданию авторской концепции";
            label8.Text = "не способен к созданию авторской концепции";
            label9.Text = "";
            label10.Text = "способени к организации эксперимента";
            label11.Text = "не способен к организации эксперимента";
            label12.Text = "";
            label13.Text = "всегда использую чужой опыт творч. деят.";
            label14.Text = "иногда использую чужой опыт творч. деят.";
            label15.Text = "никогда использую чужой опыт творч. деят.";
            label16.Text = "";
            label17.Text = "всегда сотрудничаю";
            label18.Text = "сотрудничаю иногда";
            label19.Text = "предпочитаю работать один";
            label20.Text = "";
            label21.Text = "способен решать конфликты";
            label22.Text = "способен, если являюсь участником";
            label23.Text = "способен, если не являюсь участником";
            label24.Text = "не способен решать конфликты";
            label25.Text = "";
            label26.Text = "беру ответственность за себя и других";
            label27.Text = "беру ответственность за себя";
            label28.Text = "не способен брать ответственность";

            textBox1.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
            textBox15.Visible = true;
            textBox17.Visible = true;
            textBox18.Visible = true;
            textBox19.Visible = true;
            textBox21.Visible = true;
            textBox22.Visible = true;
            textBox23.Visible = true;
            textBox24.Visible = true;
            textBox26.Visible = true;
            textBox27.Visible = true;
            textBox28.Visible = true;
           

        }

        private void f4()
        {
            groupBox2.Visible = true;
            this.Text = "Маркетинговый потенциал";
            clear();
            label1.Text = "холерик";
            label2.Text = "меланхолик";
            label3.Text = "сангвинник";
            label4.Text = "флегматик";
            label5.Text = "";
            label6.Text = "холост/не замужем";
            label7.Text = "холост/не замужем, родитель";
            label8.Text = "женат/замужем, родитель";
            label9.Text = "женат/замужем";
            label10.Text = "";
            label11.Text = "руководитель высшего звена";
            label12.Text = "руководитель среднего звена";
            label13.Text = "подчиненный";
            label14.Text = "";
            label15.Text = "руководитель общественной организации, движения";
            label16.Text = "участник общественной организации, движения";
            label17.Text = "нет";
            label18.Text = "";
            label19.Text = "способен отказаться от стереотипов";
            label20.Text = "не способен отказаться от стериотипов";
            label21.Text = "";
            label22.Text = "способен к оценочным суждениям";
            label23.Text = "не способен к оценочным суждениям";
            label24.Text = "";
            label25.Text = "";
            label26.Text = "способен к самоанализу";
            label27.Text = "не способен к самоанализу";
            label28.Text = "";
            label29.Text = "предпочитаю находится в зоне комфорта";
            label30.Text = "могу выходить из зоны комфорта";
            label31.Text = "не способен работать в некомфортных условиях";
            label32.Text = "редко испытываю дискомфорт в процессе работы";
            label33.Text = "";
            label34.Text = "быстро обучаюсь во всех сыферах";
            label35.Text = "быстро обучаюсь в профессиональной сфере";
            label36.Text = "трудность в усвоении материала";
            label37.Text = "";
            label38.Text = "готов адаптироваться";
            label39.Text = "не готов адаптироваться";
            label40.Text = "частично готов адаптироваться";
            label41.Text = "";
            label42.Text = "один балл по самопрезентации";
            label43.Text = "один балл по коммуникабельности";
            label44.Text = "один балл по способности убеждать";
            label45.Text = "";
            label46.Text = "сильное стремление получения оценки со стороны";
            label47.Text = "умеренное стремление получ. оценки со стороны";
            label48.Text = "безразлично";
            label49.Text = "";
            label50.Text = "один балл за стремление к совершенствованию";
            label51.Text = "раз в 3 года меняю сферу деят.";
            label52.Text = "раз в 5 лет меняю сферу деят.";
            label53.Text = "раз в 10 лет меняю сферу деят.";
            label54.Text = "не менял сферу деятельности";
            label55.Text = "";
            label56.Text = "карьерн. рост в теч. 2 лет";
            label57.Text = "карьерн. рост в теч. 5 лет";
            label58.Text = "карьерн. рост в теч. 10 лет";
            label59.Text = "предел должностного роста";
            label60.Text = "не было продвижения";

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox13.Visible = true;
            textBox15.Visible = true;
            textBox16.Visible = true;
            textBox17.Visible = true;
            textBox19.Visible = true;
            textBox20.Visible = true;
            textBox22.Visible = true;
            textBox23.Visible = true;
            textBox26.Visible = true;
            textBox27.Visible = true;
            textBox29.Visible = true;
            textBox30.Visible = true;
            textBox31.Visible = true;
            textBox32.Visible = true;
            textBox34.Visible = true;
            textBox35.Visible = true;
            textBox36.Visible = true;
            textBox38.Visible = true;
            textBox39.Visible = true;
            textBox40.Visible = true;
            textBox42.Visible = true;
            textBox43.Visible = true;
            textBox44.Visible = true;
            textBox46.Visible = true;
            textBox47.Visible = true;
            textBox48.Visible = true;
            textBox50.Visible = true;
            textBox51.Visible = true;
            textBox52.Visible = true;
            textBox53.Visible = true;
            textBox54.Visible = true;
            textBox56.Visible = true;
            textBox57.Visible = true;
            textBox58.Visible = true;
            textBox59.Visible = true;
            textBox60.Visible = true;
        }

        private void f5()
        {
            groupBox2.Visible = false;
            this.Text = "Информационно-методический потенциал";
            clear();
            label1.Text = "знание норм.-прав. в обл. инновац. деят.";
            label2.Text = "зниние норм.-прав. в обл. бухгалтерского учета";
            label3.Text = "зниние норм.-прав. в обл. налогооблажения";
            label4.Text = "зниние норм.-прав. в обл. * отраслевой сфере";
            label5.Text = "";
            label6.Text = "профессионал программных продуктов";
            label7.Text = "увер. пользователь программных продуктов";
            label8.Text = "Word, Excel, Internet";
            label9.Text = "другое";
            label10.Text = "";
            label11.Text = "есть навыки патентного поиска";
            label12.Text = "нет навыков патентного поиска";
            label13.Text = "";
            label14.Text = "владение методами исследования";
            label15.Text = "не владение методами исследования";
            label16.Text = "";
            label17.Text = "активный участник отраслевых выставак";
            label18.Text = "слушатель отраслевых выставок";
            label19.Text = "наблюдатель отраслевых выставок";

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox14.Visible = true;
            textBox15.Visible = true;
            textBox17.Visible = true;
            textBox18.Visible = true;
            textBox19.Visible = true;
            

        }

        private void f6()
        {
            groupBox2.Visible = true;
            this.Text = "Опыт реализации инновационных проектов";
            clear();
            label1.Text = "есть опыт инновационной деятельности";
            label2.Text = "нет опыта инновационной деятельности";
            label3.Text = "";
            label4.Text = "исключительное наличие интел. права";
            label5.Text = "авторское наличие интел. права";
            label6.Text = "соавторское наличие интел. права";
            label7.Text = "иное интел. право";
            label8.Text = "нет интел. права";
            label9.Text = "";
            label10.Text = "одно произведение науки";
            label11.Text = "одно произведение литературы";
            label12.Text = "одно географическое";
            label13.Text = "одна программа ЭВМ";
            label14.Text = "";
            label15.Text = "один объект смежных прав";
            label16.Text = "";
            label17.Text = "одно изобретение";
            label18.Text = "одна полезная модель";
            label19.Text = "один промышленный образец";
            label20.Text = "";
            label21.Text = "одно селекционное достижение";
            label22.Text = "";
            label23.Text = "одно право на топологию микросхемы";
            label24.Text = "";
            label25.Text = "одно право на секрет производства";
            label26.Text = "одно право на средство индивидуализации";
            label27.Text = "";
            label28.Text = "подана заявка";
            label29.Text = "срок действия не истек";
            label30.Text = "срок действия истек";
            label31.Text = "используемый ни практике";
            label32.Text = "";
            label33.Text = "руководитель проекта";
            label34.Text = "технолог/инженер";
            label35.Text = "маркетолог/экономист";
            label36.Text = "технич. исполнитель";
            label37.Text = "изобретатель/разработчик";
            label38.Text = "внешний консультант";
            label39.Text = "";
            label40.Text = "уч. в конкурсе муниципального ур.";
            label41.Text = "уч. в конкурсе регионального ур.";
            label42.Text = "уч. в конкурсе федерального ур.";
            label43.Text = "уч. в конкурсе международного ур.";
            label44.Text = "";
            label45.Text = "один выйгранный грант или конкурс";

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox13.Visible = true;
            textBox15.Visible = true;
            textBox17.Visible = true;
            textBox18.Visible = true;
            textBox19.Visible = true;
            textBox21.Visible = true;
            textBox23.Visible = true;
            textBox25.Visible = true;
            textBox26.Visible = true;
            textBox28.Visible = true;
            textBox29.Visible = true;
            textBox30.Visible = true;
            textBox31.Visible = true;
            textBox33.Visible = true;
            textBox34.Visible = true;
            textBox35.Visible = true;
            textBox36.Visible = true;
            textBox37.Visible = true;
            textBox38.Visible = true;
            textBox40.Visible = true;
            textBox41.Visible = true;
            textBox42.Visible = true;
            textBox43.Visible = true;
            textBox45.Visible = true;
            
        }

        private void f7()
        {
            groupBox2.Visible = true;
            this.Text = "Внешний информационный климат";
            clear();
            label1.Text = "регулярная работа в инновационной сфере";
            label2.Text = "периодическая работа в информационной сфере";
            label3.Text = "эпизодическая работа в информационной сфере";
            label4.Text = "нет работы в инновационной сфере";
            label5.Text = "";
            label6.Text = "обеспечение исследований не ограничено";
            label7.Text = "обеспечение исследований ограничено";
            label8.Text = "обеспечение исследований не доступно";
            label9.Text = "";
            label10.Text = "мотивация со стороны руководителя";
            label11.Text = "мотивация со стороны коллег";
            label12.Text = "мотивация со стороны непосредственного руководителя";
            label13.Text = "мотивация со стороны органов власти";
            label14.Text = "мотивация со стороны заказчиков";
            label15.Text = "иная мотивация";
            label16.Text = "";
            label17.Text = "матер. стимул. предприятием";
            label18.Text = "матер. стимул. органами власти";
            label19.Text = "матер. стимул. негос. фондами";
            label20.Text = "иное материальное стимулирование";
            label21.Text = "";
            label22.Text = "отсут. времени для инновационной работы";
            label23.Text = "ограничено время для инновационной работы";
            label24.Text = "не ограния. для инновационной работы";
            label25.Text = "";
            label26.Text = "огранич. доступ повышения квалификации";
            label27.Text = "не огранич. доступ повышения квалификации";
            label28.Text = "не доступно повышение квалификации";
            label29.Text = "";
            label30.Text = "помощник - внутр. ресурсы организации";
            label31.Text = "помощник - внешние источники";
            label32.Text = "помощ не доступна";

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
            textBox15.Visible = true;
            textBox17.Visible = true;
            textBox18.Visible = true;
            textBox19.Visible = true;
            textBox20.Visible = true;
            textBox22.Visible = true;
            textBox23.Visible = true;
            textBox24.Visible = true;
            textBox26.Visible = true;
            textBox27.Visible = true;
            textBox28.Visible = true;
            textBox30.Visible = true;
            textBox31.Visible = true;
            textBox32.Visible = true;
            

        }

        private void f8()
        {
            groupBox2.Visible = false;
            this.Text = "Психо-физиологический потенциал";
            clear();
            label1.Text = "один балл работоспособности";
            label2.Text = "";
            label3.Text = "плохо перенашу стрессы";
            label4.Text = "хорошо справляюсь с небольшими проблемами";
            label5.Text = "справляюсь с серьезными проблемами";
            label6.Text = "";
            label7.Text = "готов к смене места жит. и команд.";
            label8.Text = "готов к смене места жит., не готов к команд.";
            label9.Text = "готов к команд, но не к смене места жит.";
            label10.Text = "не готов к смене места жит. и команд.";

            textBox1.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
           
        }

        private void f9()
        {
            groupBox2.Visible = false;
            this.Text = "Инновационная культура";
            clear();
            label1.Text = "слежу за перед. опытом в сфере деят.";
            label2.Text = "не слежу за перед. опытом в сфере деят.";
            label3.Text = "";
            label4.Text = "осознаю недостаточность достигнутого";
            label5.Text = "не осознаю достаточность достигнутого";
            label6.Text = "";
            label7.Text = "высокий уровень притязаний";
            label8.Text = "низкий уровень притязаний";
            label9.Text = "";
            label10.Text = "есть потребность в контакте с людьми";
            label11.Text = "нет потребности в контакте с людьми";
            label12.Text = "";
            label13.Text = "потребность в новизне";
            label14.Text = "нет потребности в новизне";
            label15.Text = "";
            label16.Text = "потребностьв поиске";
            label17.Text = "нет потребности в поиске";
            label18.Text = "";
            label19.Text = "ощущение собственной готовности";
            label20.Text = "нет ощущения собственной готовности";
            label21.Text = "";
            label22.Text = "испытываете потребность в самовыражении";
            label23.Text = "не испытываете потребность в самовыражении";
			label24.Text = "";
            label25.Text = "открыты новому";
            label26.Text = "не открыты новому";

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
            textBox16.Visible = true;
            textBox17.Visible = true;
            textBox19.Visible = true;
            textBox20.Visible = true;
            textBox22.Visible = true;
            textBox23.Visible = true;
			textBox25.Visible = true;
            textBox26.Visible = true;
            

        }

        private void clear()
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";
            label19.Text = "";
            label20.Text = "";
            label21.Text = "";
            label22.Text = "";
            label23.Text = "";
            label24.Text = "";
            label25.Text = "";
            label26.Text = "";
            label27.Text = "";
            label28.Text = "";
            label29.Text = "";
            label30.Text = "";
            label31.Text = "";
            label32.Text = "";
            label33.Text = "";
            label34.Text = "";
            label35.Text = "";
            label36.Text = "";
            label37.Text = "";
            label38.Text = "";
            label39.Text = "";
            label40.Text = "";
            label41.Text = "";
            label42.Text = "";
            label43.Text = "";
            label44.Text = "";
            label45.Text = "";
            label46.Text = "";
            label47.Text = "";
            label48.Text = "";
            label49.Text = "";
            label50.Text = "";
            label51.Text = "";
            label52.Text = "";
            label53.Text = "";
            label54.Text = "";
            label55.Text = "";
            label56.Text = "";
            label57.Text = "";
            label58.Text = "";
            label59.Text = "";
            label60.Text = "";

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            textBox15.Visible = false;
            textBox16.Visible = false;
            textBox17.Visible = false;
            textBox18.Visible = false;
            textBox19.Visible = false;
            textBox20.Visible = false;
            textBox21.Visible = false;
            textBox22.Visible = false;
            textBox23.Visible = false;
            textBox24.Visible = false;
            textBox25.Visible = false;
            textBox26.Visible = false;
            textBox27.Visible = false;
            textBox28.Visible = false;
            textBox29.Visible = false;
            textBox30.Visible = false;
            textBox31.Visible = false;
            textBox32.Visible = false;
            textBox33.Visible = false;
            textBox34.Visible = false;
            textBox35.Visible = false;
            textBox36.Visible = false;
            textBox37.Visible = false;
            textBox38.Visible = false;
            textBox39.Visible = false;
            textBox40.Visible = false;
            textBox41.Visible = false;
            textBox42.Visible = false;
            textBox43.Visible = false;
            textBox44.Visible = false;
            textBox45.Visible = false;
            textBox46.Visible = false;
            textBox47.Visible = false;
            textBox48.Visible = false;
            textBox49.Visible = false;
            textBox50.Visible = false;
            textBox51.Visible = false;
            textBox52.Visible = false;
            textBox53.Visible = false;
            textBox54.Visible = false;
            textBox55.Visible = false;
            textBox56.Visible = false;
            textBox57.Visible = false;
            textBox58.Visible = false;
            textBox59.Visible = false;
            textBox60.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sost == 1)
            {
                save(1);
                sost = 2;
                load(2);
                button2.Enabled = true;
                f2();
                return;
            }
            if (sost == 2)
            {
                save(2);
                sost = 3;
                load(3);
                f3();
                return;
            }
            if (sost == 3)
            {
                save(3);
                sost = 4;
                load(4);
                f4();
                return;
            }
            if (sost == 4)
            {
                save(4);
                sost = 5;
                load(5);
                f5();
                return;
            }
            if (sost == 5)
            {
                save(5);
                sost = 6;
                load(6);
                f6();
                return;
            }
            if (sost == 6)
            {
                save(6);
                sost = 7;
                load(7);
                f7();
                return;
            }
            if (sost == 7)
            {
                save(7);
                sost = 8;
                load(8);
                f8();
                return;
            }
            if (sost == 8)
            {
                save(8);
                sost = 9;
                load(9);
                button1.Enabled = false;
                f9();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sost == 2)
            {
                save(2);
                sost = 1;
                button2.Enabled = false;
                f1();
                load(1);
                return;
            }
            if (sost == 3)
            {
                save(3);
                sost = 2;
                load(2);
                f2();
                return;
            }
            if (sost == 4)
            {
                save(4);
                sost = 3;
                load(3);
                f3();
                return;
            }
            if (sost == 5)
            {
                save(5);
                sost = 4;
                load(4);
                f4();
                return;
            }
            if (sost == 6)
            {
                save(6);
                sost = 5;
                load(5);
                f5();
                return;
            }
            if (sost == 7)
            {
                save(7);
                sost = 6;
                load(6);
                f6();
                return;
            }
            if (sost == 8)
            {
                save(8);
                sost = 7;
                load(7);
                f7();
                return;
            }
            if (sost == 9)
            {
                save(9);
                button1.Enabled = true;
                sost = 8;
                load(8);
                f8();
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            save(sost);

            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();
            string CommandText = "select nom from t;";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            MySqlDataReader myDataReader = myCommand.ExecuteReader();

            string qwe;
            int zxc;
            while (myDataReader.Read())
            {
                qwe = myDataReader[0].ToString();
                zxc = Convert.ToInt32(qwe);
                z1(zxc);
                z2(zxc);
                z3(zxc);
                z4(zxc);
                z5(zxc);
                z6(zxc);
                z7(zxc);
                z8(zxc);
                z9(zxc);

                myConnection = new MySqlConnection(connStr);
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
                b = (at1 + at2 + at3 + at4 + at5 + at6 + at7 + at8 + at9) / 9;
                int bs = Convert.ToInt32(b * 10000);

                CommandText = "UPDATE t SET  a1=" + as1 + ", a2=" + as2 + ", a3=" + as3 + ", a4=" + as4 + ", a5=" + as5 + ", a6=" + as6 + ", a7=" + as7 + ", a8=" + as8 + ", a9=" + as9 + ", b=" + bs + " WHERE nom=" + zxc + ";";
                myCommand = new MySqlCommand(CommandText, myConnection);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            myConnection.Close();
        }

        private void z1(int data)
        {
            int asd;

            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();
            string CommandText = "select t1 from admin";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
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


            myConnection.Open();

            CommandText = "SELECT zar, ycheb, tren, instr, vozm FROM t1 where nom = " + data + ";";
            myCommand = new MySqlCommand(CommandText, myConnection);
            myDataReader = myCommand.ExecuteReader();
            at1 = 0;
            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) at1 += ad[1];
                if (asd == 1) at1 += ad[2];
                if (asd == 2) at1 += ad[3];
                if (asd == 3) at1 += ad[4];

                asd = Convert.ToInt32(myDataReader[4].ToString());
                if (asd == 0) at1 += ad[10];
                if (asd == 1) at1 += ad[11];
                if (asd == 2) at1 += ad[12];

                at1 += Convert.ToInt32(myDataReader[1].ToString()) * ad[6];
                at1 += Convert.ToInt32(myDataReader[2].ToString()) * ad[7];
                at1 += Convert.ToInt32(myDataReader[3].ToString()) * ad[8];
            }
            myConnection.Close();
        }

        private void z2(int data)
        {
            int asd;

            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();
            string CommandText = "select t2 from admin";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
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



            myConnection.Open();

            CommandText = "SELECT kv, obr, nap, naps, st1, st2, st3, kva, vuz, pu1, pu2, pu3, pu4, pu5, pu6, pu7, pu8, pu9, re1, re2, re3, re4 FROM t2 where nom = " + data + ";";
            myCommand = new MySqlCommand(CommandText, myConnection);
            myDataReader = myCommand.ExecuteReader();
            at2 = 0;
            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) at2 += ad[45];
                if (asd == 1) at2 += ad[46];
                if (asd == 2) at2 += ad[47];
                if (asd == 3) at2 += ad[48];

                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 0) at2 += ad[1];
                if (asd == 1) at2 += ad[2];
                if (asd == 2) at2 += ad[3];
                if (asd == 3) at2 += ad[4];
                if (asd == 4) at2 += ad[5];
                if (asd == 5) at2 += ad[6];
                if (asd == 6) at2 += ad[7];
                if (asd == 7) at2 += ad[8];
                if (asd == 8) at2 += ad[9];
                if (asd == 9) at2 += ad[10];
                if (asd == 10) at2 += ad[11];

                asd = Convert.ToInt32(myDataReader[2].ToString());
                if (asd == 0) at2 += ad[13];
                if (asd == 1) at2 += ad[14];
                if (asd == 2) at2 += ad[15];
                if (asd == 3) at2 += ad[16];
                if (asd == 4) at2 += ad[17];
                if (asd == 5) at2 += ad[18];
                if (asd == 6) at2 += ad[19];
                if (asd == 7) at2 += ad[20];
                if (asd == 8) at2 += ad[21];

                textBox9.Text = myDataReader[3].ToString();

                asd = Convert.ToInt32(myDataReader[7].ToString());
                if (asd == 0) at2 += ad[41];
                if (asd == 1) at2 += ad[42];
                if (asd == 2) at2 += ad[43];
                if (asd == 3) at2 += ad[44];

                at2 += Convert.ToInt32(myDataReader[4].ToString()) * ad[23];
                at2 += Convert.ToInt32(myDataReader[5].ToString()) * ad[24];
                at2 += Convert.ToInt32(myDataReader[6].ToString()) * ad[25];

                at2 += Convert.ToInt32(myDataReader[9].ToString()) * ad[26];
                at2 += Convert.ToInt32(myDataReader[10].ToString()) * ad[27];
                at2 += Convert.ToInt32(myDataReader[11].ToString()) * ad[28];
                at2 += Convert.ToInt32(myDataReader[12].ToString()) * ad[29];
                at2 += Convert.ToInt32(myDataReader[13].ToString()) * ad[30];
                at2 += Convert.ToInt32(myDataReader[14].ToString()) * ad[31];
                at2 += Convert.ToInt32(myDataReader[15].ToString()) * ad[32];
                at2 += Convert.ToInt32(myDataReader[16].ToString()) * ad[33];
                at2 += Convert.ToInt32(myDataReader[17].ToString()) * ad[34];

                at2 += Convert.ToInt32(myDataReader[18].ToString()) * ad[36];
                at2 += Convert.ToInt32(myDataReader[19].ToString()) * ad[37];
                at2 += Convert.ToInt32(myDataReader[20].ToString()) * ad[38];
                at2 += Convert.ToInt32(myDataReader[21].ToString()) * ad[39];

            }
            myConnection.Close();            
            
        }

        private void z3(int data)
        {
            int asd;

            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();
            String CommandText = "select t3 from admin";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
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


            
            myConnection.Open();

            CommandText = "SELECT lid, pl, avt, eks, chu, sot, con, otv FROM t3 where nom = " + data + ";";
            myCommand = new MySqlCommand(CommandText, myConnection);
            myDataReader = myCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 0) at3 += ad[3];
                if (asd == 1) at3 += ad[4];
                if (asd == 2) at3 += ad[5];

                asd = Convert.ToInt32(myDataReader[2].ToString());
                if (asd == 0) at3 += ad[7];
                if (asd == 1) at3 += ad[8];

                asd = Convert.ToInt32(myDataReader[3].ToString());
                if (asd == 0) at3 += ad[10];
                if (asd == 1) at3 += ad[11];

                asd = Convert.ToInt32(myDataReader[4].ToString());
                if (asd == 0) at3 += ad[13];
                if (asd == 1) at3 += ad[14];
                if (asd == 2) at3 += ad[15];

                asd = Convert.ToInt32(myDataReader[5].ToString());
                if (asd == 0) at3 += ad[17];
                if (asd == 1) at3 += ad[18];
                if (asd == 2) at3 += ad[19];

                asd = Convert.ToInt32(myDataReader[6].ToString());
                if (asd == 0) at3 += ad[21];
                if (asd == 1) at3 += ad[22];
                if (asd == 2) at3 += ad[23];
                if (asd == 3) at3 += ad[24];

                asd = Convert.ToInt32(myDataReader[7].ToString());
                if (asd == 0) at3 += ad[26];
                if (asd == 1) at3 += ad[27];
                if (asd == 2) at3 += ad[28];

                at3 += Convert.ToInt32(myDataReader[0].ToString()) * ad[1];
            }
            myConnection.Close();
        }

        private void z4(int data)
        {
            int asd;

            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();
            String CommandText = "select t4 from admin";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
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

            
            myConnection.Open();

            CommandText = "SELECT tem, sem, obs, kom, obu, kol, ada, bre1, bre2, bre3, oce, kri, sam, ste, sov, zam FROM t4 where nom = " + data + ";";
            myCommand = new MySqlCommand(CommandText, myConnection);
            myDataReader = myCommand.ExecuteReader();
            at4 = 0;
            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) at4 += ad[1];
                if (asd == 1) at4 += ad[2];
                if (asd == 2) at4 += ad[3];
                if (asd == 3) at4 += ad[4];

                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 0) at4 += ad[6];
                if (asd == 1) at4 += ad[7];
                if (asd == 2) at4 += ad[8];
                if (asd == 3) at4 += ad[9];

                asd = Convert.ToInt32(myDataReader[2].ToString());
                if (asd == 0) at4 += ad[11];
                if (asd == 1) at4 += ad[12];
                if (asd == 2) at4 += ad[13];

                asd = Convert.ToInt32(myDataReader[3].ToString());
                if (asd == 0) at4 += ad[29];
                if (asd == 1) at4 += ad[30];
                if (asd == 2) at4 += ad[31];
                if (asd == 3) at4 += ad[32];

                asd = Convert.ToInt32(myDataReader[4].ToString());
                if (asd == 0) at4 += ad[34];
                if (asd == 1) at4 += ad[35];
                if (asd == 2) at4 += ad[36];

                asd = Convert.ToInt32(myDataReader[5].ToString());
                if (asd == 0) at4 += ad[11];
                if (asd == 1) at4 += ad[12];
                if (asd == 2) at4 += ad[13];

                asd = Convert.ToInt32(myDataReader[6].ToString());
                if (asd == 0) at4 += ad[38];
                if (asd == 1) at4 += ad[39];
                if (asd == 2) at4 += ad[40];

                asd = Convert.ToInt32(myDataReader[10].ToString());
                if (asd == 0) at4 += ad[46];
                if (asd == 1) at4 += ad[47];
                if (asd == 2) at4 += ad[48];

                asd = Convert.ToInt32(myDataReader[11].ToString());
                if (asd == 0) at4 += ad[22];
                if (asd == 1) at4 += ad[23];

                asd = Convert.ToInt32(myDataReader[12].ToString());
                if (asd == 0) at4 += ad[26];
                if (asd == 1) at4 += ad[27];

                asd = Convert.ToInt32(myDataReader[13].ToString());
                if (asd == 0) at4 += ad[19];
                if (asd == 1) at4 += ad[20];

                asd = Convert.ToInt32(myDataReader[15].ToString());
                if (asd == 0) at4 += ad[51];
                if (asd == 1) at4 += ad[52];
                if (asd == 2) at4 += ad[53];
                if (asd == 3) at4 += ad[54];

                at4 += Convert.ToInt32(myDataReader[7].ToString()) * ad[42];
                at4 += Convert.ToInt32(myDataReader[8].ToString()) * ad[43];
                at4 += Convert.ToInt32(myDataReader[9].ToString()) * ad[44];
                at4 += Convert.ToInt32(myDataReader[14].ToString()) * ad[50];
            }
            myConnection.Close();  
        }

        private void z5(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);

            myConnection.Open();
            string CommandText = "select t5 from admin";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
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


            myConnection.Open();

            CommandText = "SELECT pra, pras, nav, navs, pat, vla, ych  FROM t5 where nom = " + data + ";";
            myCommand = new MySqlCommand(CommandText, myConnection);
            myDataReader = myCommand.ExecuteReader();
            at5 = 0;
            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) at5 += ad[1];
                if (asd == 1) at5 += ad[2];
                if (asd == 2) at5 += ad[3];
                if (asd == 3) at5 += ad[4];

                asd = Convert.ToInt32(myDataReader[2].ToString());
                if (asd == 0) at5 += ad[6];
                if (asd == 1) at5 += ad[7];
                if (asd == 2) at5 += ad[8];
                if (asd == 3) at5 += ad[9];

                asd = Convert.ToInt32(myDataReader[4].ToString());
                if (asd == 0) at5 += ad[11];
                if (asd == 1) at5 += ad[12];

                asd = Convert.ToInt32(myDataReader[5].ToString());
                if (asd == 0) at5 += ad[14];
                if (asd == 1) at5 += ad[15];

                asd = Convert.ToInt32(myDataReader[6].ToString());
                if (asd == 0) at5 += ad[17];
                if (asd == 1) at5 += ad[18];
                if (asd == 2) at5 += ad[19];

            }
            myConnection.Close();
        }

        private void z6(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);
            myConnection.Open();
            string CommandText = "select t6 from admin";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
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

            myConnection.Open();

            CommandText = "SELECT a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, b1, b2, b3, b4, b5, b6, c1, c2, c3, c4, d  FROM t6 where nom = " + data + ";";
            myCommand = new MySqlCommand(CommandText, myConnection);
            myDataReader = myCommand.ExecuteReader();
            at6 = 0;
            while (myDataReader.Read())
            {
                at6 += Convert.ToInt32(myDataReader[0].ToString()) * ad[10];
                at6 += Convert.ToInt32(myDataReader[1].ToString()) * ad[11];
                at6 += Convert.ToInt32(myDataReader[2].ToString()) * ad[12];
                at6 += Convert.ToInt32(myDataReader[3].ToString()) * ad[13];

                at6 += Convert.ToInt32(myDataReader[4].ToString()) * ad[15];

                at6 += Convert.ToInt32(myDataReader[5].ToString()) * ad[17];
                at6 += Convert.ToInt32(myDataReader[6].ToString()) * ad[18];
                at6 += Convert.ToInt32(myDataReader[7].ToString()) * ad[19];

                at6 += Convert.ToInt32(myDataReader[8].ToString()) * ad[21];

                at6 += Convert.ToInt32(myDataReader[9].ToString()) * ad[23];
                at6 += Convert.ToInt32(myDataReader[10].ToString()) * ad[25];
                at6 += Convert.ToInt32(myDataReader[11].ToString()) * ad[26];

                at6 += Convert.ToInt32(myDataReader[12].ToString()) * ad[45];

                asd = Convert.ToInt32(myDataReader[13].ToString());
                if (asd == 1) at6 += ad[33];

                asd = Convert.ToInt32(myDataReader[14].ToString());
                if (asd == 1) at6 += ad[34];

                asd = Convert.ToInt32(myDataReader[15].ToString());
                if (asd == 1) at6 += ad[35];

                asd = Convert.ToInt32(myDataReader[16].ToString());
                if (asd == 1) at6 += ad[36];

                asd = Convert.ToInt32(myDataReader[17].ToString());
                if (asd == 1) at6 += ad[37];

                asd = Convert.ToInt32(myDataReader[18].ToString());
                if (asd == 1) at6 += ad[38];

                asd = Convert.ToInt32(myDataReader[19].ToString());
                if (asd == 0) at6 += ad[4];
                if (asd == 1) at6 += ad[5];
                if (asd == 2) at6 += ad[6];
                if (asd == 3) at6 += ad[7];
                if (asd == 4) at6 += ad[8];

                asd = Convert.ToInt32(myDataReader[20].ToString());
                if (asd == 0) at6 += ad[40];
                if (asd == 1) at6 += ad[41];
                if (asd == 2) at6 += ad[42];
                if (asd == 3) at6 += ad[43];

                asd = Convert.ToInt32(myDataReader[21].ToString());
                if (asd == 0) at6 += ad[28];
                if (asd == 1) at6 += ad[29];
                if (asd == 2) at6 += ad[30];
                if (asd == 3) at6 += ad[31];

                asd = Convert.ToInt32(myDataReader[22].ToString());
                if (asd == 0) at6 += ad[1];
                if (asd == 1) at6 += ad[2];

                textBox50.Text = myDataReader[23].ToString();

            }
            myConnection.Close();
        }

        private void z7(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);

            myConnection.Open();
            string CommandText = "select t7 from admin";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
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


            myConnection.Open();

            CommandText = "SELECT a1, a2, a3, a4, a5, a6, a7, d1, d2 FROM t7 where nom = " + data + ";";
            myCommand = new MySqlCommand(CommandText, myConnection);
            myDataReader = myCommand.ExecuteReader();
            at7 = 0;
            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) at7 += ad[1];
                if (asd == 1) at7 += ad[2];
                if (asd == 2) at7 += ad[3];
                if (asd == 3) at7 += ad[4];

                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 0) at7 += ad[6];
                if (asd == 1) at7 += ad[7];
                if (asd == 2) at7 += ad[8];

                asd = Convert.ToInt32(myDataReader[2].ToString());
                if (asd == 0) at7 += ad[17];
                if (asd == 1) at7 += ad[18];
                if (asd == 2) at7 += ad[19];
                if (asd == 3) at7 += ad[20];

                asd = Convert.ToInt32(myDataReader[3].ToString());
                if (asd == 0) at7 += ad[10];
                if (asd == 1) at7 += ad[11];
                if (asd == 2) at7 += ad[12];
                if (asd == 3) at7 += ad[13];
                if (asd == 4) at7 += ad[14];
                if (asd == 5) at7 += ad[15];

                asd = Convert.ToInt32(myDataReader[4].ToString());
                if (asd == 0) at7 += ad[22];
                if (asd == 1) at7 += ad[23];
                if (asd == 2) at7 += ad[24];

                asd = Convert.ToInt32(myDataReader[5].ToString());
                if (asd == 0) at7 += ad[26];
                if (asd == 1) at7 += ad[27];
                if (asd == 2) at7 += ad[28];

                asd = Convert.ToInt32(myDataReader[6].ToString());
                if (asd == 0) at7 += ad[30];
                if (asd == 1) at7 += ad[31];
                if (asd == 2) at7 += ad[32];
            }
            myConnection.Close();
        }

        private void z8(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);

            myConnection.Open();
            string CommandText = "select t8 from admin";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
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


            myConnection.Open();

            CommandText = "SELECT a1, a2, d FROM t8 where nom = " + data + ";";
            myCommand = new MySqlCommand(CommandText, myConnection);
            myDataReader = myCommand.ExecuteReader();
            at8 = 0;
            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) at8 += ad[3];
                if (asd == 1) at8 += ad[4];
                if (asd == 2) at8 += ad[5];

                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 0) at8 += ad[7];
                if (asd == 1) at8 += ad[8];
                if (asd == 2) at8 += ad[9];
                if (asd == 3) at8 += ad[10];

                at8 += Convert.ToInt32(myDataReader[2].ToString()) * ad[1];
            }
            myConnection.Close();
        }

        private void z9(int data)
        {
            int asd;
            MySqlConnection myConnection = new MySqlConnection(connStr);

            myConnection.Open();
            string CommandText = "select t9 from admin";
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
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


            myConnection.Open();

            CommandText = "SELECT a1, a2, a3, a4, a5, a6, a7, a8, a9 FROM t9 where nom = " + data + ";";
            myCommand = new MySqlCommand(CommandText, myConnection);
            myDataReader = myCommand.ExecuteReader();
            at9 = 0;
            while (myDataReader.Read())
            {
                asd = Convert.ToInt32(myDataReader[0].ToString());
                if (asd == 0) at9 += ad[1];
                if (asd == 1) at9 += ad[2];

                asd = Convert.ToInt32(myDataReader[1].ToString());
                if (asd == 0) at9 += ad[25];
                if (asd == 1) at9 += ad[26];

                asd = Convert.ToInt32(myDataReader[2].ToString());
                if (asd == 0) at9 += ad[4];
                if (asd == 1) at9 += ad[5];

                asd = Convert.ToInt32(myDataReader[3].ToString());
                if (asd == 0) at9 += ad[7];
                if (asd == 1) at9 += ad[8];

                asd = Convert.ToInt32(myDataReader[4].ToString());
                if (asd == 0) at9 += ad[10];
                if (asd == 1) at9 += ad[11];

                asd = Convert.ToInt32(myDataReader[5].ToString());
                if (asd == 0) at9 += ad[13];
                if (asd == 1) at9 += ad[14];

                asd = Convert.ToInt32(myDataReader[6].ToString());
                if (asd == 0) at9 += ad[16];
                if (asd == 1) at9 += ad[17];

                asd = Convert.ToInt32(myDataReader[7].ToString());
                if (asd == 0) at9 += ad[19];
                if (asd == 1) at9 += ad[20];

                asd = Convert.ToInt32(myDataReader[8].ToString());
                if (asd == 0) at9 += ad[22];
                if (asd == 1) at9 += ad[23];
            }
            myConnection.Close();
        }
    }
}
