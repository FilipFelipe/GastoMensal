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
using ControleMensal.Model;
using ControleMensal.Controller;

namespace ControleMensal
{
    public partial class Form2 : Form
    {
      
        Conexao CC = new Conexao();
        DadosDAO db = new DadosDAO();
     
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string op = "SELECT sum(valor) as valor FROM conta group by METODO;";

            double op1, op2;
            dataGridView1.DataSource = db.lancamentos(op);
            op1 = Convert.ToDouble(dataGridView1[0, 1].Value);
            op2 = Convert.ToDouble(dataGridView1[0, 0].Value);
            op2 = op2 * -1;
            grafico(op1,op2);




        }
        private void ManterCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27)) //ESC
            {
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grafico(double op1,double op2)
        {
             
            chart1.Series["Gastos"].Points.AddXY("Recebimento", op1);
            chart1.Series["Gastos"].Points.AddXY("Pagamento", op2);

            
            chart1.Titles.Add("Relátorio");
            label1.Text = Convert.ToString(op1);
            label2.Text = Convert.ToString(op2);
        }
    }
}
