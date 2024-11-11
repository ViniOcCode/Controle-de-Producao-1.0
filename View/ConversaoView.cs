using ControleProdForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleProdForms.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigurarComboBox();
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
           
            double valorEntrada;
            if (!double.TryParse(txtConversaoEntrada.Text, out valorEntrada))
            {
                MessageBox.Show("Insira um valor numérico válido.");
                return;
            }

            int unidadeSelecionada = (int)cbUnidadeEntrada.SelectedValue;

            double resultado = 0;

            switch (unidadeSelecionada)
            {
                case 1:
                    resultado = ConversaoModel.BarraParaKg(valorEntrada); 
                    break;

                case 2:
                    resultado = ConversaoModel.SacoCimentoParaKg(valorEntrada);
                    break;

                case 3:
                    resultado = ConversaoModel.SacoCimentoRapidoParaKg(valorEntrada); 
                    break;

                default:
                    MessageBox.Show("Selecione uma opção válida.");
                    break;
            }

            txtConversaoSaida.Text = resultado.ToString();
        }
         
        private void ConfigurarComboBox()
        {

            var UnitEntry = new List<KeyValuePair<int, string>>
        {
            new KeyValuePair<int, string>(1, "1. Barras"),
            new KeyValuePair<int, string>(2, "2. Saco Cimento"),
            new KeyValuePair<int, string>(3, "3. Saco Cimento Rap.")
        };

            cbUnidadeEntrada.DataSource = UnitEntry;
            cbUnidadeEntrada.DisplayMember = "Value";
            cbUnidadeEntrada.ValueMember = "Key";
        }
    }

}
