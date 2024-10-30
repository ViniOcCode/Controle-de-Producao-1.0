using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleProdForms.View
{
    public interface IProducaoView
    {        //Propriedades - Fields
        string PdCodigo { get; set; }
        string PdData { get; set; }
        string PdQuantidade { get; set; }
        string PdNome { get; set; }
        DataGridView DataGrid { get; }
        DataGridView DataGridMp { get; set; }
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
        event EventHandler PegaNome;

        //Métodos
        void SetGridMatProd(BindingSource matProdLista);
        void SetGridProducao(BindingSource pdLista);
        void Show();
    }
}
