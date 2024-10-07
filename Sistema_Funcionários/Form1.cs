using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Funcionários
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtNome.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtCpf.Text.Equals(""))
                {
                    CadastroFuncionarios cadFuncinarios = new CadastroFuncionarios();
                    cadFuncinarios.Nome = txtNome.Text;
                    cadFuncinarios.Email = txtEmail.Text;
                    cadFuncinarios.Cpf = txtCpf.Text;
                    cadFuncinarios.Endereco = txtEndereco.Text;

                    if (cadFuncinarios.cadastrarFuncionarios())
                    {
                        MessageBox.Show($"O funcionário {cadFuncinarios.Nome} foi cadastrado com sucesso!");
                        txtNome.Clear();
                        txtEndereco.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        txtNome.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel cadastrar");
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher todos os campos corretamente!");
                    txtNome.Clear();
                    txtEndereco.Clear();
                    txtEmail.Clear();  
                    txtCpf.Clear();
                    txtNome.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionário!" + ex.Message);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals(""))
                {
                    CadastroFuncionarios cadFuncionarios = new CadastroFuncionarios();
                    cadFuncionarios.Cpf = txtCpf.Text;

                    MySqlDataReader reader = cadFuncionarios.localizarFuncionario();

                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            label6.Text = reader["id"].ToString();
                            txtNome.Text = reader["nome"].ToString();
                            txtEndereco.Text = reader["endereco"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("Funcionário não encontrado!");
                        txtNome.Clear();
                        txtEndereco.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        txtNome.Focus();
                        label6.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher o campo CPF para realizar a pesquisa!");
                    txtNome.Clear();
                    txtEndereco.Clear();
                    txtEmail.Clear();
                    txtCpf.Clear();
                    txtNome.Focus();
                    label6.Text = "";
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Erro ao encontrar funcionário: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtEndereco.Clear();
            txtEmail.Clear();
            txtCpf.Clear();
            txtNome.Focus();
            label6.Text = "";
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtNome.Text.Equals(""))
                {
                    CadastroFuncionarios cadFuncionarios = new CadastroFuncionarios();
                    cadFuncionarios.Id = int.Parse(label6.Text);
                    cadFuncionarios.Email = txtEmail.Text;
                    cadFuncionarios.Endereco = txtEndereco.Text;

                    if (cadFuncionarios.atualizarFuncionario())
                    {
                        MessageBox.Show(" os dados do funcionário foram atualizadas com sucesso!");
                        txtNome.Clear();
                        txtEndereco.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        label6.Text = "";
                        txtCpf.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel atualizar as informações do funcionário");
                        txtNome.Clear();
                        txtEndereco.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        label6.Text = "";
                        txtCpf.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Favor localizar funcionário para atualizar informações");
                    txtNome.Clear();
                    txtEndereco.Clear();
                    txtEmail.Clear();
                    txtCpf.Clear();
                    label6.Text = "";
                    txtCpf.Focus();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Erro ao atualizar dados do funcionário: " + ex.Message);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCpf.Text.Equals("") && !txtEmail.Text.Equals("") && !txtEndereco.Text.Equals("") && !txtNome.Text.Equals(""))
                {
                    CadastroFuncionarios cadFuncionarios = new CadastroFuncionarios();
                    cadFuncionarios.Id = int.Parse(label6.Text);
                    if (cadFuncionarios.deletarFuncionario())
                    {
                        MessageBox.Show("Funcionário deletado com sucesso!");
                        txtNome.Clear();
                        txtEndereco.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        label6.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel deletar funcionários");
                        txtNome.Clear();
                        txtEndereco.Clear();
                        txtEmail.Clear();
                        txtCpf.Clear();
                        label6.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Favor pesquisar qual funcionário deseja deletar");
                    txtNome.Clear();
                    txtEndereco.Clear();
                    txtEmail.Clear();
                    txtCpf.Clear();
                    label6.Text = "";
                    txtCpf.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao deletar funcionário");
            }
        }
    } 
}
