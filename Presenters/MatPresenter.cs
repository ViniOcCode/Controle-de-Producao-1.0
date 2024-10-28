using ControleProdForms.Models;
using ControleProdForms.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ControleProdForms.Presenters
{
    public class MatPresenter
    {
        private IMatView view;
        private IMatRepo repo;
        private BindingSource gridMat;
        private IEnumerable<MatModel> matLista;

        public MatPresenter(IMatView view, IMatRepo repo)
        {
            this.view = view;
            this.repo = repo;
            this.gridMat = new BindingSource();

            //Eventos
            this.view.PesquisaEvento += PesquisaMat;
            this.view.AdicionarEvento += AdicionarMat;
            this.view.EditarEvento += EditarMat;
            this.view.DeletarEvento += DeletarMat;
            this.view.SalvoEvento += SalvarMat;
            this.view.CancelarEvento += CancelarMat;

            //Carregar Produtos
            this.view.SetGridMat(gridMat);

            AllMat();

            this.view.Show();


        }

        private void AllMat()
        {
            matLista = repo.GetAll();
            gridMat.DataSource = matLista;
        }

        private void CancelarMat(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void SalvarMat(object sender, EventArgs e)
        {
            var modelo = new MatModel();
            modelo.Codigo = view.MatCodigo;
            modelo.Nome = view.MatNome;
            modelo.Estoque = view.MatEstoque;
            try
            {
                new Common.ModelDataValidation().Validate(modelo);
                if (view.Editado)
                {
                    repo.AddMateriaLog(modelo);
                    repo.EditMateria(modelo);
                    view.Mensagem = "Materia Prima Atualizada com Sucesso!";
                }
                else
                {
                    repo.AddMateriaLog(modelo);
                    repo.AddMateria(modelo);
                    view.Mensagem = "Materia Prima Adicionada com Sucesso!";

                }
                view.MensagemSucesso = true;
                AllMat();
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
            view.MatCodigo = "0";
            view.MatNome = string.Empty;
            view.MatEstoque = "0";
        }

        private void DeletarMat(object sender, EventArgs e)
        {
            try
            {
                var materia = (MatModel)gridMat.Current;
                repo.DelMateria(Convert.ToInt32(materia.Codigo));
                view.MensagemSucesso = true;
                view.Mensagem = "Matéria Prima Deletada com Sucesso!";
                AllMat();
            }
            catch (Exception ex)
            {
                view.MensagemSucesso = false;
                view.Mensagem = "Não foi possível deletar a Matéria Prima";
            }
        }

        private void EditarMat(object sender, EventArgs e)
        {
            var materia = (MatModel)gridMat.Current;
            view.MatCodigo = materia.Codigo.ToString();
            view.MatNome = materia.Nome;
            view.MatEstoque = materia.Estoque.ToString();
            view.Editado = true;
        }

        private void AdicionarMat(object sender, EventArgs e)
        {
            LimpaCampos();
            view.Editado = false;
        }

        private void PesquisaMat(object sender, EventArgs e)
        {
            bool vazio = string.IsNullOrEmpty(this.view.Pesquisa);
            if (vazio == false)
                matLista = repo.GetByValue(this.view.Pesquisa);
            else matLista = repo.GetAll();
            gridMat.DataSource = matLista;
        }
    }
}
