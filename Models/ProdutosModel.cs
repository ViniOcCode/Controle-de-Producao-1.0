using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ControleProdForms.Models
{
    public class ProdutosModel
    {
        //Fields
        private string codigo;
        private string nome;
        private string un_palete;
        private string estoque;
        private string ativo;

        //Propriedades - Validação
        [DisplayName("Código")]
        [Required(ErrorMessage = "O campo Código é obrigatório.")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "O código deve ter no mínimo 5 digitos")] //exemplo: 10140 e não 1140
        [RegularExpression("([0-9]+)", ErrorMessage = "Coloque um número válido")]
        public string Codigo { get => codigo; set => codigo = value; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Nome { get => nome; set => nome = value; }

        [DisplayName("Palete")]
        [Required(ErrorMessage = "O campo Palete é obrigatório.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Coloque um número válido")]
        public string Un_Palete { get => un_palete; set => un_palete = value; }
        [DisplayName("Estoque")]
        [Required(ErrorMessage = "O campo Estoque é obrigatório.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Coloque um número válido")]
        public string Estoque { get => estoque; set => estoque = value; }
    }
}
