using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleMensal.Model;
using ControleMensal.Controller;
using MySql.Data.MySqlClient;


namespace ControleMensal
{
    public partial class Form1 : Form
    {
        Dados operacao = new Dados(); // define a classe
        DadosDAO db = new DadosDAO(); // define a classe 


        public Form1()
        {
            InitializeComponent();
        }  // padrão form
       
        private void Form1_Load(object sender, EventArgs e)
        {
            atualiza();

        }  // carregamento do form1 

        private void button1_Click(object sender, EventArgs e)
        {
            double op =0;
            if (comboBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Erro, campos não prenchidos");
            }

            else
            {
                
                textBox2.Text = Convert.ToString(operacao.Conta(Convert.ToDouble(textBox1.Text), comboBox1.Text));
                op = operacao.Conta(Convert.ToDouble(textBox1.Text), comboBox1.Text);
                textBox4.Text = Convert.ToString(db.dbvalor(comboBox2.Text, op, comboBox1.Text,textBox3.Text));
                atualiza();

            }
            // **** Limpa formulário ****
            comboBox1.Text = "";
            textBox1.Text = "";
            comboBox2.Text = "";
            textBox3.Text = "";
            // **** =============== ****

           



        }  // adc no banco de dados
        public void atualiza()
        {
            double op1, op2;
            string op = "SELECT sum(valor) as valor FROM conta group by METODO;";
            data.DataSource = db.lancamentos();
            valor.DataSource = db.lancamentos(op); // polimorfismo : sobrecarga de métodos
            label4.Text = "R$ " + Convert.ToString(valor[0, 1].Value);
            label9.Text = "R$ " + Convert.ToString(valor[0, 0].Value);
            op1 = Convert.ToDouble(valor[0, 1].Value);
            op2 = Convert.ToDouble(valor[0, 0].Value);
            op1 = op1 - (-1* op2); // positivo pq o valor de op2 já eh negativo
            label10.Text = "R$ " + Convert.ToString(op1); // retorna valor na label já calculado
            
           
            if (op1 < 0)  // se o valor for menor que 0 - vermelho / maior = azul
            {
                label10.ForeColor = System.Drawing.Color.Red; // define cor vermelha
                pictureBox1.Image = ControleMensal.Properties.Resources.Grinmacing_Face_Emoji;

            }
            else
            {
                label10.ForeColor = System.Drawing.Color.Blue; // define cor azul
                pictureBox1.Image = ControleMensal.Properties.Resources.Money_Face_Emoji;
            }
        }   //Att datagrid


        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // Declara o form2
            form2.Show(); // Exibe form2
        }  // abre form2

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Não realizada nenhuma operação para ser desfeita !", "Erro!!");
            }
            else
            {
                string del = "DELETE FROM conta WHERE ID = (" + textBox4.Text + ")";
                db.deletar(del);
                atualiza();
            }
        }   // refazer



        private void Del_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Valor do ID não preenchido","ERRO !!");
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Os dados serão deletados permanentemente do banco de dados!! \nA Ação não poderá ser desfeita \nDeseja Continuar?", "Cuidado!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (confirm.ToString().ToUpper() == "YES")
                {
                    string del = "DELETE FROM conta WHERE ID = (" + textBox5.Text + ")";
                    db.deletar(del);
                    atualiza();
                    textBox5.Text = "";
                }
                else
                {
                    MessageBox.Show(" Nenhum dado foi alterado !! ", "UFFAA");
                }
            }
            
        }   // Deletar ID

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://bri.ifsp.edu.br/portal2/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/filipjfelipe/");
        }
    }
}
