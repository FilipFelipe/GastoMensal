using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using ControleMensal.Controller;



namespace ControleMensal.Model
{

    public class Dados
    {
        private double resultado;  // Encapsulamento
        public double Conta(double valor1, string parametro)
        {
           
            if (parametro == "pagamento") //pagamento funcionarios
            {
                resultado = valor1 * -1;
                return resultado;
            }
            else
            {
                // resultado = valor1 - (valor1 * (0.25)); // 0.25 de imposto por transacao
                resultado = valor1;
                return resultado;
            }

        }
        public string paramentros()
        {
            string op = "SELECT sum(valor) as valor FROM conta group by METODO;";
            return op;
        }


    }
}
