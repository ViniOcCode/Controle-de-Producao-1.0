using ControleProdForms.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleProdForms.View
{
    public partial class ProducaoView : Form, IProducaoView
    {
        private string mensagem;
        private bool editado;
        private bool sucesso;

        public ProducaoView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabCadastro);
            btnSair.Click += delegate { this.Close(); };
            this.Shown += ProducaoView_Shown;
            DataGrid.DataBindingComplete += (s, e) => DataGrid.ClearSelection();

        }
        private void ProducaoView_Shown(object sender, EventArgs e)
        {
            FormatGridView(); // Chame o método aqui após o formulário ser exibido
        }


        private void AssociateAndRaiseViewEvents()
        {
            DataGrid.CellValueChanged += (s, e) => FormatGridView();
            DataGrid.RowsAdded += (s, e) => FormatGridView();
            DataGrid.RowsRemoved += (s, e) => FormatGridView();
            DataGrid.DataBindingComplete += (s, e) => FormatGridView();

            btnPesquisa.Click += delegate { PesquisaEvento?.Invoke(this, EventArgs.Empty); };
            txtPesquisa.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    PesquisaEvento?.Invoke(this, EventArgs.Empty);
            };

            txtCodigo.TextChanged += delegate { PegaNome?.Invoke(this, EventArgs.Empty); };

            btnAdd.Click += delegate
            {
                AdicionarEvento?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabMenu);
                tabControl1.TabPages.Add(tabCadastro);
                lblData.Text = dtpData.Text;
                tabCadastro.Text = "Adicionar Nova Produção";
            };
            btnEdit.Click += delegate
            {
                txtCodigo.Enabled = false;
                btnNew.Enabled = false;
                EditarEvento?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabMenu);
                tabControl1.TabPages.Add(tabCadastro);
                lblData.Text = dtpData.Text;
                tabCadastro.Text = "Editar Produção";
            };
            btnSave.Click += delegate
            {
                SalvoEvento?.Invoke(this, EventArgs.Empty);
                if (sucesso)
                {
                    tabControl1.TabPages.Remove(tabCadastro);
                    tabControl1.TabPages.Add(tabMenu);
                    txtCodigo.Enabled = true;
                    btnNew.Enabled = true;
                }
                MessageBox.Show(mensagem);
            };
            btnDel.Click += delegate
            {
                var result = MessageBox.Show("Você tem certeza que quer deletar o produto?", "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeletarEvento?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(mensagem);
                }
            };
            btnNew.Click += delegate
            {
                CancelarEvento?.Invoke(this, EventArgs.Empty);
            };

            btnCancel.Click += delegate
            {
                CancelarEvento?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabCadastro);
                tabControl1.TabPages.Add(tabMenu);
                txtCodigo.Enabled = true;
                btnNew.Enabled = true;
            };
        }

        public string PdCodigo
        {
            get { return txtCodigo.Text; }
            set { txtCodigo.Text = value; }
        }
        public string PdNome
        {
            get { return txtNome.Text; }
            set { txtNome.Text = value; }
        }
        public string PdData
        {
            get { return dtpData.Text; }
            set { dtpData.Text = value; }
        }
        public string PdQuantidade
        {
            get { return txtQuantidade.Text; }
            set { txtQuantidade.Text = value; }
        }
        public string Pesquisa
        {
            get { return txtPesquisa.Text; }
            set { txtPesquisa.Text = value; }
        }
        public string Mensagem
        {
            get { return mensagem; }
            set { mensagem = value; }
        }
        public bool Editado
        {
            get { return editado; }
            set { editado = value; }
        }
        public bool MensagemSucesso
        {
            get { return sucesso; }
            set { sucesso = value; }
        }

        public DataGridView DataGrid
        {
            get { return dgLista; }
        }

        public DataGridView DataGridMp
        {
            get { return mpLista; }
            set { mpLista = value;}
        }

        public event EventHandler PesquisaEvento;
        public event EventHandler AdicionarEvento;
        public event EventHandler EditarEvento;
        public event EventHandler DeletarEvento;
        public event EventHandler SalvoEvento;
        public event EventHandler CancelarEvento;
        public event EventHandler PegaNome;


        public void SetGridProducao(BindingSource pdLista)
        {
            DataGrid.DataSource = pdLista;
            DataGrid.ClearSelection();
        }

        public void SetGridMatProd(BindingSource matProdLista)
        {
            DataGridMp.DataSource = matProdLista;
        }

        private void FormatGridView()
        {
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                var cellValue = row.Cells["Data"].Value;
                if (cellValue != null && DateTime.TryParse(cellValue.ToString(), out DateTime data))
                {
                    if (data.Date != DateTime.Today)
                    {
                        row.DefaultCellStyle.BackColor = Color.Orange;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        if (data < DateTime.Today.AddDays(-2))
                        {
                            row.DefaultCellStyle.BackColor = Color.Crimson;
                            row.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                        }
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.SpringGreen;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
            DataGrid.Refresh();
        }

        private static ProducaoView instance;
        public static ProducaoView Instancia(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ProducaoView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private void lblData_Click(object sender, EventArgs e)
        {
            dtpData.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void ProducaoView_Load(object sender, EventArgs e)
        {
            lblData.Text = dtpData.Text;
            DataGridMp.Refresh();
        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            lblData.Text = dtpData.Text;
        }

        private void dgLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Enabled = true;
        }
    }
}
