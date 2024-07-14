using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml.Serialization;
using System.IO;

namespace Stud
{
    public partial class teatovaua : Form
    {
        Props props = new Props(); //экземпляр класса с настройками///////////////////////////////////////

        
        public teatovaua()
        {
            InitializeComponent();
        }

        private void teatovaua_Load(object sender, EventArgs e)
        {
            props.ReadXml();
            textBox1.Text = props.Fields.serverName;
            textBox2.Text = props.Fields.userName;
            textBox3.Text = props.Fields.dbName;
            textBox4.Text = props.Fields.port;
            textBox5.Text = props.Fields.password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            props.Fields.serverName = textBox1.Text;
            props.Fields.userName = textBox2.Text;
            props.Fields.dbName = textBox3.Text;
            props.Fields.port = textBox4.Text;
            props.Fields.password = textBox5.Text;
            props.WriteXml();
            this.Close();
        }

        private void teatovaua_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
