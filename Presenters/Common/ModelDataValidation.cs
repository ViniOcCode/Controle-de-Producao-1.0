using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ControleProdForms.Presenters.Common
{
    public class ModelDataValidation
    {
        public void Validate(object model)
        {
            string MensagemErro = "";
            List<ValidationResult> resultados = new List<ValidationResult>();
            ValidationContext contexto = new ValidationContext(model);
            bool valido = Validator.TryValidateObject(model, contexto, resultados, true);
            if (!valido)
            {
                foreach (var item in resultados)
                {
                    MensagemErro += "- " + item.ErrorMessage + "\n";
                    throw new Exception(MensagemErro);
                }
            }
        }
    }
}
