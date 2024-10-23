using ControleProdForms.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleProdForms.View
{
    public partial class MenuView : Form, IMenuView
    {
        public MenuView()
        {
            InitializeComponent();
            btnProdutos.Click += (s, e) => MostraProduto?.Invoke(this, EventArgs.Empty);
            btnMateria.Click += (s, e) => MostraMateria?.Invoke(this, EventArgs.Empty);
            btnProducao.Click += (s, e) => MostraProducao?.Invoke(this, EventArgs.Empty);
            btnCapa.Click += (s, e) => MostraCapa?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler MostraProduto;
        public event EventHandler MostraMateria;
        public event EventHandler MostraProducao;
        public event EventHandler MostraCapa;
    }
}
