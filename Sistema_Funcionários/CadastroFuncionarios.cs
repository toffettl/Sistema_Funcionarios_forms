using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Funcionários
{
    internal class CadastroFuncionarios
    {
        private int id;
        private string nome;
        private string email;
        private string cpf;
        private string endereco;

        public int Id
        {
            get { return id; }
            set { id = value; } 
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        //cadastrar funcionario no banco
        public bool cadastrarFuncionarios()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string insert = $" insert into funcionarios (nome,email,cpf,endereco) values ('{Nome}','{Email}','{Cpf}','{Endereco}')";

                MySqlCommand comandSql = MysqlConexaoBanco.CreateCommand();
                comandSql.CommandText = insert;
                
                comandSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Erro no banco de dados - método cadastrarFuncionarios" + ex.Message);
                return false;
            }
        }

        public MySqlDataReader localizarFuncionario()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string select = $"select id, nome, email, cpf, endereco from funcionarios where cpf = '{Cpf}';";

                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = select;

                MySqlDataReader reader = comandoSql.ExecuteReader();
                return reader;
            }catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método localizarFuncionario: " + ex.Message);
                return null;
            }
        }
    }
}
