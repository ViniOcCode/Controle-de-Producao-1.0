using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleProdForms.Models
{
    public interface IMatRepo
    {
        IEnumerable<MatModel> GetAll();
        IEnumerable<MatModel> GetByValue(string valor);
        void AddMateria(MatModel materia);
        void AddMateriaLog(MatModel materia);
        void EditMateria(MatModel materia);
        void DelMateria(int codigo);
    }
}
