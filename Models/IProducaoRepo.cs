using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleProdForms.Models
{
    public interface IProducaoRepo
    {
        IEnumerable<ProducaoModel> GetAll();
        IEnumerable<ProducaoModel> GetByValue(string valor);
        void AddProducao(ProducaoModel produto);
        void EditProducao(ProducaoModel produto);
        void PegaNome(ProducaoModel produto);
        void AddProducaoLog(ProducaoModel produto);
        void DelProducao(int codigo);
    }
}
