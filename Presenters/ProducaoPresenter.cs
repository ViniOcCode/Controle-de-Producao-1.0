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
        private BindingSource gridMatProd;
        private BindingSource gridProducao;
        private IEnumerable<ProducaoModel> pdLista;
        private IEnumerable<MatProdModel> matProdLista;

        public ProducaoPresenter(IProducaoView view, IProducaoRepo repo)
        {
            this.view = view;
            this.repo = repo;
            this.gridProducao = new BindingSource();
            this.gridMatProd = new BindingSource();

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
            this.view.SetGridMatProd(gridMatProd);

            AllProducao();
            AllMatProd();
            this.view.Show();

        }

        private void AllMatProd()
        {
            matProdLista = repo.GetAllMatProd();
            gridMatProd.DataSource = matProdLista;
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
            var producoes = new List<MatProdModel>();
            var modelo = new ProducaoModel();

            foreach (DataGridViewRow row in view.DataGridMp.Rows)
            {
                if (row.IsNewRow) continue;

                var matProd = new MatProdModel
                {
                    CodigoPd = Convert.ToInt32(view.PdCodigo),
                    CodigoMp = Convert.ToInt32(row.Cells["CodigoMp"].Value),
                    QuantidadeMp = Convert.ToDouble(row.Cells["QuantidadeMp"].Value)
                };

                producoes.Add(matProd);
            }

            modelo.Codigo = view.PdCodigo;
            modelo.Data = view.PdData;
            modelo.Quantidade = view.PdQuantidade;
            try
            {
                new Common.ModelDataValidation().Validate(modelo);
                if (view.Editado)
                {
                    repo.EditMatProd(producoes);
                    repo.EditProducao(modelo);
                    repo.AddProducaoLog(modelo);
                    view.Mensagem = "Produto Atualizado com Sucesso!";
                }
                else
                {
                    repo.AddMatProd(producoes);
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

            foreach (DataGridViewRow row in view.DataGridMp.Rows)
            {
                row.Cells["QuantidadeMp"].Value = "0";
            }
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

            var matProdLista = repo.GetMatProd(Convert.ToInt32(producao.Id));

            view.PdCodigo = producao.Codigo.ToString();
            view.PdData = producao.Data;
            view.PdQuantidade = producao.Quantidade.ToString();
            view.Editado = true;

            foreach (DataGridViewRow row in view.DataGridMp.Rows)
            {
                if (row.IsNewRow) continue;

                var codigoMp = Convert.ToInt32(row.Cells["CodigoMp"].Value);
                var matProd = matProdLista.FirstOrDefault(mp => mp.CodigoMp == codigoMp);

                if (matProd != null)
                {
                    row.Cells["QuantidadeMp"].Value = matProd.QuantidadeMp;
                }
            }
        }

        private void AdicionarProducao(object sender, EventArgs e)
        {
            view.Editado = false;
            LimpaCampos();
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
