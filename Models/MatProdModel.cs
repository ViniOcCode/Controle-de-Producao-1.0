using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleProdForms.Models
{
    public class MatProdModel
    {
        private int idmp;
        private int codigopd;
        private int codigomp;
        private string nomemp;
        private int estoquemp;
        private double quantidademp;

        [ReadOnly(true)]
        [Editable(false)]
        [Browsable(false)]
        public int CodigoPd { get => codigopd; set => codigopd = value; }

        [DisplayName("Código")]
        [ReadOnly(true)]
        [Editable(false)]
        public int CodigoMp { get => codigomp; set => codigomp = value; }

        [DisplayName("Descrição")]
        [ReadOnly(true)]
        [Editable(false)]

        public string NomeMp { get => nomemp; set => nomemp = value; }

        [DisplayName("Estoque")]
        [ReadOnly(true)]
        [Editable(false)]
        public int EstoqueMp { get => estoquemp; set => estoquemp = value;}

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Coloque um número válido")]
        [Editable(true)]
        public double QuantidadeMp { get => quantidademp; set => quantidademp = value; }

        [Browsable(false)]
        [Editable(false)]
        public int IdMp { get => idmp; set => idmp = value; }
    }
}
