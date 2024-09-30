using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = null;
        private string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Data Source=DESKTOP-OJ8JR8I";
        private string strSql = string.Empty;



        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            strSql = "insert into Funcionarios (Id, Nome, Endereco, CEP, Bairro, Cidade, UF, Telefone) values (@Id, @Nome, @Endereco, @CEP, @Bairro, @Cidade, @UF, @Telefone)";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@Id", SqlDbType.Int).Value = txtId.Text;
            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = mskCEP.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = txtUF.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = mskTelefone.Text;
            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void tsbPesquisa_Click(object sender, EventArgs e)
        {
            strSql = "select * from Funcionarios where Id=@Id";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@Id", SqlDbType.Int).Value = tstIdBuscar.Text;

            try
            {
                if (tstIdBuscar.Text == string.Empty)
                {
                    throw new Exception("Você precisa executar um Id! ");
                }

                sqlCon.Open();

                SqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows == false)
                {
                    throw new Exception("Id não cadastrado! ");
                }

                dr.Read();

                txtId.Text = Convert.ToString(dr["Id"]);
                txtNome.Text = Convert.ToString(dr["Nome"]);
                txtEndereco.Text = Convert.ToString(dr["Endereco"]);
                mskCEP.Text = Convert.ToString(dr["CEP"]);
                txtBairro.Text = Convert.ToString(dr["Bairro"]);
                txtCidade.Text = Convert.ToString(dr["Cidade"]);
                txtUF.Text = Convert.ToString(dr["UF"]);
                mskTelefone.Text = Convert.ToString(dr["Telefone"]);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void tsbAlterar_Click(object sender, EventArgs e)
        {

            strSql = "update Funcionarios set Id = @Id, Nome = @Nome, Endereco = @Endereco, CEP = @CEP, Bairro = @Bairro, Cidade = @Cidade, UF = @UF, Telefone = @Telefone where Id = @IdBuscar";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@IdBuscar", SqlDbType.Int).Value = tstIdBuscar.Text;

            comando.Parameters.Add("@Id", SqlDbType.Int).Value = txtId.Text;
            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = mskCEP.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = txtUF.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = mskTelefone.Text;

            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro atualizado com sucesso! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                sqlCon.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

       
    }
}
