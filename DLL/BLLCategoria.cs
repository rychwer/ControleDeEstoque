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
    public class BLLCategoria
    {
        private DALConexao conexao;

        public BLLCategoria (DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloCategoria categoria)
        {
            if (categoria.CatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria deve ser preenchido.");
            }

            categoria.CatNome = categoria.CatNome.ToUpper();

            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Incluir(categoria);
        }

        public void Alterar(ModeloCategoria categoria)
        {
            if (categoria.CatCod <= 0)
            {
                throw new Exception("Um codigo deve ser informado");
            }

            if (categoria.CatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria deve ser preenchido.");
            }

            categoria.CatNome = categoria.CatNome.ToUpper();

            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Alterar(categoria);
        }

        public void Excluir(int codigo)
        {

            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(String valor)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
           return DALobj.Localizar(valor);
        }

        public ModeloCategoria carregaCategoria(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.carregaCategoria(codigo);
        }
    }
}
