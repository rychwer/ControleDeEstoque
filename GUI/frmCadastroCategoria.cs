using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelo;
using DAL;
using BLL;

namespace GUI
{
    public partial class frmCadastroCategoria : GUI.frmModeloDeCadastro
    {
        public frmCadastroCategoria()
        {
            InitializeComponent();
        }

        public void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }

        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaTela();
            this.alteraBotoes(1);

        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try {
                ModeloCategoria categoria = new ModeloCategoria();
                categoria.CatNome = txtNome.Text;
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLCategoria bll = new BLLCategoria(cx);

                if (this.operacao.Equals("inserir"))
                {
                    bll.Incluir(categoria);
                    MessageBox.Show("Cadastro efetuado com sucesso. Codigo: "+categoria.CatCod.ToString());
                } else
                {
                    categoria.CatCod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(categoria);
                    MessageBox.Show("Alteração efetuada com sucesso.");
                }
                this.LimpaTela();
                this.alteraBotoes(1);
            } catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "Alterar";
            this.alteraBotoes(2);
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja realmente excluir o registro?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLCategoria bll = new BLLCategoria(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.LimpaTela();
                    this.alteraBotoes(1);
                }
            } catch
            {
                MessageBox.Show("Não foi possível realizar a exclusão do registro. \n O registro está sendo utilizado.");
                this.alteraBotoes(3);
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaCategoria ConsultaCategoria = new frmConsultaCategoria();
            ConsultaCategoria.ShowDialog();

            if (ConsultaCategoria.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLCategoria bll = new BLLCategoria(cx);
                ModeloCategoria categoria = bll.carregaCategoria(ConsultaCategoria.codigo);
                txtCodigo.Text = categoria.CatCod.ToString();
                txtNome.Text = categoria.CatNome;
                alteraBotoes(3);
            } else
            {
                this.LimpaTela();
                this.alteraBotoes(1);
            }
            ConsultaCategoria.Dispose();
        }
    }
}
