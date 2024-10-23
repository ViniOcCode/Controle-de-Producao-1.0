using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleProdForms.Models
{
    public class ProducaoModel
    {
        //Fields
        private string codigo;
        private string data;
        private string quantidade;
        private string nome;

        //Propriedades - Validação
        [DisplayName("Código")]
        [Required(ErrorMessage = "O campo Código é obrigatório.")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "O código deve ter no mínimo 5 digitos")] //exemplo: 10140 e não 1140
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        [DisplayName("Data")]
        [Required(ErrorMessage = "O campo Data é obrigatório.")]
        public string Data { get => data; set => data = value; }

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        public string Quantidade { get => quantidade; set => quantidade = value; }
    }
}
