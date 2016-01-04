﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroCategoria CadastroCategoria = new frmCadastroCategoria();
            CadastroCategoria.ShowDialog();
            CadastroCategoria.Dispose();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaCategoria ConsultaCategoria = new frmConsultaCategoria();
            ConsultaCategoria.ShowDialog();
            ConsultaCategoria.Dispose();
        }

        private void subcategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroSubCategoria SubCategoria = new frmCadastroSubCategoria();
            SubCategoria.ShowDialog();
            SubCategoria.Dispose();
        }
    }
}
