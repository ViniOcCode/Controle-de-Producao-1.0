using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleProdForms.Models
{
    public interface IProdutosRepo
    {
        IEnumerable<ProdutosModel> GetAll();
        IEnumerable<ProdutosModel> GetByValue(string valor);
        void AddProduto(ProdutosModel produto);
        void EditProduto(ProdutosModel produto);
        void DesProduto(int codigo);
        void DelProduto(int codigo);
    }
}
