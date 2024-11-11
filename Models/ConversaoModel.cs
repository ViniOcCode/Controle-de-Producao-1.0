using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleProdForms.Models
{
    public class ConversaoModel
    {
        public static double SacoCimentoParaKg(double saco)
        {
            return saco * 50.0;
        }

        public static double SacoCimentoRapidoParaKg(double saco)
        {
            return saco * 40.0;
        }

        public static double BarraParaKg(double barra)
        {
            return barra * 20.0;
        }
    }
}
