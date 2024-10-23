using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleProdForms.Models;
using ControleProdForms.View;

namespace ControleProdForms.Presenters
{
    public class ProdutosPresenter
    {
        //Campos
        private IProdutosView view;
        private IProdutosRepo repo;
        private BindingSource gridProdutos;
        private IEnumerable<ProdutosModel> prodLista;

        public ProdutosPresenter(IProdutosView view, IProdutosRepo repo)
        {
            this.view = view;
            this.repo = repo;
            this.gridProdutos = new BindingSource();

            //Eventos
            this.view.PesquisaEvento += PesquisaProduto;
            this.view.AdicionarEvento += AdicionarProduto;
            this.view.EditarEvento += EditarProduto;
            this.view.DeletarEvento += DeletarProduto;
            this.view.SalvoEvento += SalvarProduto;
            this.view.CancelarEvento += CancelarEdicao;

            //Carregar Produtos
            this.view.SetGridProdutos(gridProdutos);

            TodosProdutos();

            this.view.Show();


        }

        //Metódos
        public void TodosProdutos()
        {
            prodLista = repo.GetAll();
            gridProdutos.DataSource = prodLista;
        }

        public void CancelarEdicao(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        public void SalvarProduto(object sender, EventArgs e)
        {
            var modelo = new ProdutosModel();
            modelo.Codigo = view.ProdCodigo;
            modelo.Nome = view.ProdNome;
            modelo.Un_Palete = view.ProdPalete;
            modelo.Estoque = view.ProdEstoque;
            try
            {
                new Common.ModelDataValidation().Validate(modelo);
                if (view.Editado)
                {

                    repo.EditProduto(modelo);
                    view.Mensagem = "Produto Atualizado com Sucesso!";
                }
                else
                {
                    repo.AddProduto(modelo);
                    view.Mensagem = "Produto Adicionado com Sucesso!";

                }
                view.MensagemSucesso = true;
                TodosProdutos();
                LimpaCampos();
            }
            catch (Exception ex)
            {
                view.MensagemSucesso = false;
                view.Mensagem = ex.Message;
            }

        }

        public void LimpaCampos()
        {
            view.ProdCodigo = "0";
            view.ProdNome = string.Empty;
            view.ProdPalete = "0";
            view.ProdEstoque = "0";
        }

        public void DeletarProduto(object sender, EventArgs e)
        {
            try
            {
                var produto = (ProdutosModel)gridProdutos.Current;
                repo.DesProduto(Convert.ToInt32(produto.Codigo));
                view.MensagemSucesso = true;
                view.Mensagem = "Produto Deletado com Sucesso!";
                TodosProdutos();
            }
            catch (Exception ex)
            {
                view.MensagemSucesso = false;
                view.Mensagem = "Não foi possível deletar o produto";
            }
        }

        public void EditarProduto(object sender, EventArgs e)
        {
            var produto = (ProdutosModel)gridProdutos.Current;
            view.ProdCodigo = produto.Codigo.ToString();
            view.ProdNome = produto.Nome;
            view.ProdPalete = produto.Un_Palete.ToString();
            view.ProdEstoque = produto.Estoque.ToString();
            view.Editado = true;
        }

        public void AdicionarProduto(object sender, EventArgs e)
        {
            LimpaCampos();
            view.Editado = false;
        }

        public void PesquisaProduto(object sender, EventArgs e)
        {
            bool vazio = string.IsNullOrEmpty(this.view.Pesquisa);
            if (vazio == false)
                prodLista = repo.GetByValue(this.view.Pesquisa);
            else prodLista = repo.GetAll();
            gridProdutos.DataSource = prodLista;
        }
    }
}
