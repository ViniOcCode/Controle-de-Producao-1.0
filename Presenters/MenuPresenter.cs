using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleProdForms.View;
using ControleProdForms.Models;
using ControleProdForms._Repos;
using System.Data;
using System.Windows.Forms;

namespace ControleProdForms.Presenters
{
    public class MenuPresenter
    {
        private IMenuView menuView;
        private readonly string sqlConnectionString;

        public MenuPresenter(IMenuView menuView, string sqlConnectionString)
        {
            this.menuView = menuView;
            this.sqlConnectionString = sqlConnectionString;
            this.menuView.MostraProduto += MostraProduto;
            this.menuView.MostraMateria += MostraMateria;
            this.menuView.MostraProducao += MostraProducao;
            this.menuView.MostraCapa += MostraCapa;
        }

        private void MostraProduto(object sender, EventArgs e)
        {
            IProdutosView view = ProdutosView.Instancia((MenuView)menuView);
            IProdutosRepo repo = new ProdutosRepo(sqlConnectionString);
            new ProdutosPresenter(view, repo);
        }

        private void MostraMateria(object sender, EventArgs e)
        {
            IMatView view = MatView.Instancia((MenuView)menuView);
            IMatRepo repo = new MatRepo(sqlConnectionString);
            new MatPresenter(view, repo);
        }
        private void MostraProducao(object sender, EventArgs e)
        {
            IProducaoView view = ProducaoView.Instancia((MenuView)menuView);
            IProducaoRepo repo = new ProducaoRepo(sqlConnectionString);
            new ProducaoPresenter(view, repo);
        }
        private void MostraCapa(object sender, EventArgs e)
        {
            CapaView view = CapaView.Instancia((Form)menuView, sqlConnectionString);
            view.Show();
        }
    }
}
