using ControleProdForms.Models;
using ControleProdForms.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleProdForms.Presenters
{
    public class ProducaoPresenter
    {
        //Campos
        private IProducaoView view;
        private IProducaoRepo repo;
        private BindingSource gridProducao;
        private IEnumerable<ProducaoModel> pdLista;

        public ProducaoPresenter(IProducaoView view, IProducaoRepo repo)
        {
            this.view = view;
            this.repo = repo;
            this.gridProducao = new BindingSource();

            //Eventos
            this.view.PesquisaEvento += PesquisaProducao;
            this.view.AdicionarEvento += AdicionarProducao;
            this.view.EditarEvento += EditarProducao;
            this.view.DeletarEvento += DeletarProducao;
            this.view.SalvoEvento += SalvarProducao;
            this.view.CancelarEvento += CancelarEdicao;
            this.view.PegaNome += pegaNome;

            //Carregar Produtos
            this.view.SetGridProducao(gridProducao);

            AllProducao();

            this.view.Show();

        }


        private void AllProducao()
        {
            pdLista = repo.GetAll();
            gridProducao.DataSource = pdLista;
        }

        private void CancelarEdicao(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void SalvarProducao(object sender, EventArgs e)
        {
            var modelo = new ProducaoModel();
            modelo.Codigo = view.PdCodigo;
            modelo.Data = view.PdData;
            modelo.Quantidade = view.PdQuantidade;
            try
            {
                new Common.ModelDataValidation().Validate(modelo);
                if (view.Editado)
                {

                    repo.EditProducao(modelo);
                    repo.AddProducaoLog(modelo);
                    view.Mensagem = "Produto Atualizado com Sucesso!";
                }
                else
                {
                    repo.AddProducao(modelo);
                    repo.AddProducaoLog(modelo);
                    view.Mensagem = "Produto Adicionado com Sucesso!";

                }
                view.MensagemSucesso = true;
                AllProducao();
                LimpaCampos();
            }
            catch (Exception ex)
            {
                view.MensagemSucesso = false;
                view.Mensagem = ex.Message;
            }
        }

        private void LimpaCampos()
        {
            view.PdCodigo = "0";
            view.PdData = string.Empty;
            view.PdQuantidade = "0";
        }

        private void DeletarProducao(object sender, EventArgs e)
        {
            try
            {
                var producao = (ProducaoModel)gridProducao.Current;
                repo.DelProducao(Convert.ToInt32(producao.Id));
                view.MensagemSucesso = true;
                view.Mensagem = "Produto Deletado com Sucesso!";
                AllProducao();
            }
            catch (Exception ex)
            {
                view.MensagemSucesso = false;
                view.Mensagem = "Não foi possível deletar o produto";
            }
        }

        private void EditarProducao(object sender, EventArgs e)
        {
            var producao = (ProducaoModel)gridProducao.Current;
            view.PdCodigo = producao.Codigo.ToString();
            view.PdData = producao.Data;
            view.PdQuantidade = producao.Quantidade.ToString();
            view.Editado = true;
        }

        private void AdicionarProducao(object sender, EventArgs e)
        {
            LimpaCampos();
            view.Editado = false;
        }

        private void PesquisaProducao(object sender, EventArgs e)
        {
            bool vazio = string.IsNullOrEmpty(this.view.Pesquisa);
            if (vazio == false)
            {
                pdLista = repo.GetByValue(this.view.Pesquisa);
            }
            else pdLista = repo.GetAll();
            gridProducao.DataSource = pdLista;
        }

        private void pegaNome(object sender, EventArgs e)
        {
            var modelo = new ProducaoModel();
            modelo.Codigo = view.PdCodigo;
            repo.PegaNome(modelo);
            view.PdNome = modelo.Nome;
        }
    }
}
