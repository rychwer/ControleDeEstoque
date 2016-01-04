using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Modelo;
using System.Data;

namespace BLL
{
    class BLLSubCategoria
    {
        private DALConexao conexao;

        public BLLSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloSubCategoria subcategoria)
        {
            if (subcategoria.ScatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da Subcategoria deve ser preenchido.");
            }

            if (subcategoria.CatCod <= 0)
            {
                throw new Exception("O código da categoria deve ser informado.");
            }

            subcategoria.ScatNome = subcategoria.ScatNome.ToUpper();

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Incluir(subcategoria);
        }

        public void Alterar(ModeloSubCategoria subcategoria)
        {
            if (subcategoria.ScatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da Subcategoria deve ser preenchido.");
            }

            if (subcategoria.CatCod <= 0)
            {
                throw new Exception("O código da categoria deve ser informado.");
            }

            if (subcategoria.ScatCod <= 0)
            {
                throw new Exception("O código da subcategoria deve ser informado.");
            }

            subcategoria.ScatNome = subcategoria.ScatNome.ToUpper();

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Alterar(subcategoria);
        }

        public void Excluir(int codigo)
        {

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(String valor)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.Localizar(valor);
        }

        public ModeloSubCategoria carregaSubCategoria(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.carregaSubCategoria(codigo);
        }
    }
}
