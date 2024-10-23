using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleProdForms.Models
{
    public class MatModel
    {
        private string codigo;
        private string nome;
        private string estoque;

        //Propriedades - Validação
        [DisplayName("Código")]
        [Required(ErrorMessage = "O campo Código é obrigatório.")]
        public string Codigo { get => codigo; set => codigo = value; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Nome { get => nome; set => nome = value; }

        [DisplayName("Estoque")]
        [Required(ErrorMessage = "O campo Estoque é obrigatório.")]
        public string Estoque { get => estoque; set => estoque = value; }
    }
}
