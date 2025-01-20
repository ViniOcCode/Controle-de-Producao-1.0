using ControleProdForms.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControleProdForms.View
{
    public partial class ConversaoView : Form
    {
        public ConversaoView()
        {
            InitializeComponent();
            ConfigurarComboBox();
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            var densidades = new Dictionary<int, double>
            {
                { 6, 1600 },  
                { 7, 1550 },
                { 8, 1650 }, 
                { 9, 1400 },  
                { 10, 1450 },
                { 11, 1500 } 
            };

            // Validar a entrada do usuário
            if (double.TryParse(txtValor.Text, out double valor))
            {
                int unidadeOrigem = (int)cbUnidadeEntrada.SelectedValue;
                int unidadeDestino = (int)cbUnidadeSaida.SelectedValue;


                string unidadeResultado = cbUnidadeSaida.Text;
                string unidadeNome = cbUnidadeEntrada.Text;

                double resultado = Converter(valor, unidadeOrigem, unidadeDestino, densidades);


                lblResultado.Text = $"{valor} {unidadeNome} = {resultado} {unidadeResultado}";
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor numérico válido.", "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarComboBox()
        {
            // Configurar as opções de entrada e saída sem duplicações de chave
            var UnitEntry = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(1, "KGs"),
                new KeyValuePair<int, string>(2, "M³"),
                new KeyValuePair<int, string>(3, "Barras"),
                new KeyValuePair<int, string>(4, "Saco Cimento"),
                new KeyValuePair<int, string>(5, "Saco Cimento Rap."),
                new KeyValuePair<int, string>(6, "Areia Grossa"),
                new KeyValuePair<int, string>(7, "Areia Lavada"),
                new KeyValuePair<int, string>(8, "Granilha"),
                new KeyValuePair<int, string>(9, "Pó de Pedra"),
                new KeyValuePair<int, string>(10, "Pedrisco"),
                new KeyValuePair<int, string>(11, "Pedra"),
                new KeyValuePair<int, string>(12, "Tábua"),
            };

            var UnitOut = new List<KeyValuePair<int, string>>(UnitEntry);
            cbUnidadeEntrada.DataSource = UnitEntry;
            cbUnidadeEntrada.DisplayMember = "Value";
            cbUnidadeEntrada.ValueMember = "Key";

            cbUnidadeSaida.DataSource = UnitOut;
            cbUnidadeSaida.DisplayMember = "Value";
            cbUnidadeSaida.ValueMember = "Key";
        }

        private double Converter(double valor, int unidadeOrigem, int unidadeDestino, Dictionary<int, double> densidades)
        {
            switch (unidadeOrigem)
            {
                case 1:
                    break;
                case 2: 
                    break;
                case 3: 
                    valor *= 20; 
                    break;
                case 4: 
                    valor /= 50;
                    break;
                case 5: 
                    valor /= 40; 
                    break;
                case 6: 
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    
                    if (densidades.ContainsKey(unidadeOrigem))
                    {
                        valor /= densidades[unidadeOrigem]; 
                    }
                    break;
            }


            switch (unidadeDestino)
            {
                case 1: 
                    if (densidades.ContainsKey(unidadeOrigem))
                    {
                        valor *= densidades[unidadeOrigem];
                    }
                    break;
                case 2:
                    break;
                case 3:
                    valor /= 20;
                    break;
                case 4:
                    valor *= 50;
                    break;
                case 5:
                    valor *= 40;
                    break;
                case 6: 
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    if (densidades.ContainsKey(unidadeDestino))
                    {
                        valor *= densidades[unidadeDestino];
                    }
                    break;
            }

            return valor;
        }

    }
}
