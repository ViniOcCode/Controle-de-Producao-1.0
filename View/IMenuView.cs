using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleProdForms.View
{
    public interface IMenuView
    {
        event EventHandler MostraProduto;
        event EventHandler MostraMateria;
        event EventHandler MostraProducao;
        event EventHandler MostraCapa;
    }
}
