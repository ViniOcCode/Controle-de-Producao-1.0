using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleProdForms.View
{
    public interface IProdutosView
    {
        //Propriedades - Fields
        string ProdCodigo { get; set; }
        string ProdNome { get; set; }
        string ProdPalete { get; set; }
        string ProdEstoque { get; set; }

        string Pesquisa { get; set; }
        string Mensagem { get; set; }
        bool Editado { get; set; }
        bool MensagemSucesso { get; set; }

        //Eventos
        event EventHandler PesquisaEvento;
        event EventHandler AdicionarEvento;
        event EventHandler EditarEvento;
        event EventHandler DeletarEvento;
        event EventHandler SalvoEvento;
        event EventHandler CancelarEvento;

        //Métodos
        void SetGridProdutos(BindingSource prodLista);
        void Show();
    }
}
