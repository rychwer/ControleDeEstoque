using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using Modelo;
using BLL;

namespace GUI
{
    public partial class frmCadastroSubCategoria : GUI.frmModeloDeCadastro
    {
        public frmCadastroSubCategoria()
        {
            InitializeComponent();
        }

        private void frmCadastroSubCategoria_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCategoria BLLCategoria = new BLLCategoria(cx);
            cbCatCod.DataSource = BLLCategoria.Localizar("");
            cbCatCod.DisplayMember = "cat_nome";
            cbCatCod.ValueMember = "cat_cod";
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(2);
            this.operacao = "inserir";
        }
    }
}
