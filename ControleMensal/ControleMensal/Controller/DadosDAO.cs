using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

// coloca os dados na db ou busca eles
namespace ControleMensal.Controller
{
    class DadosDAO
    {
        Conexao CC = new Conexao();
        MySqlConnection con = null;
        public int dbvalor(string nome, double valor, string metodo,string obs)
        {
            try
            {
                String sql = "INSERT INTO conta (nome,valor,metodo,obs) VALUES (@nome,@valor,@metodo,@obs)";
                con = new MySqlConnection(CC.sql());
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@metodo", metodo);
                cmd.Parameters.AddWithValue("@obs",obs);
               
                con.Open();
                cmd.ExecuteNonQuery();


                // Verifica se existe um ultimo id inserido e adiciona um
                // parametro para tratá-lo
                if (cmd.LastInsertedId != 0)
                    cmd.Parameters.Add(new MySqlParameter("ultimoId", cmd.LastInsertedId));

                // Retorna o id do novo rgistro e convert de Int64 para Int32 (int).
                return Convert.ToInt32(cmd.Parameters["@ultimoId"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                con.Close();
            }
        }
        public DataTable lancamentos()
        {
            try
            {
                String sql = "SELECT * FROM conta";
                con = new MySqlConnection(CC.sql());
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       public DataTable lancamentos(string sql)
        {
            try
            {
                
                con = new MySqlConnection(CC.sql());
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex; //delete from conta SELECT MAX(ID) from conta
            }

        }
        public void deletar(string sql)
        {
            try
            {
                
                
                
                con = new MySqlConnection(CC.sql());
                MySqlCommand cmd = new MySqlCommand(sql, con);
                
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                con.Close();
            }
        }
    }
}
