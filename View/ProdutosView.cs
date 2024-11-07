using ControleProdForms.View;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ControleProdForms.View
{
    public partial class ProdutosView : Form, IProdutosView
    {
        // Campos
        private string mensagem;    
        private bool sucesso;
        private bool editado;

        //Construtor
        public ProdutosView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabCadastro);
            btnSair.Click += delegate { this.Close();};
            ConfigurarComboBox();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnPesquisa.Click += delegate { PesquisaEvento?.Invoke(this, EventArgs.Empty); };
            txtPesquisa.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    PesquisaEvento?.Invoke(this, EventArgs.Empty);
            };
            btnAdd.Click += delegate
            {
                AdicionarEvento?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabMenu);
                tabControl1.TabPages.Add(tabCadastro);
                tabCadastro.Text = "Adicionar Novo Produto";
            };
            btnEdit.Click += delegate
            {
                txtCodigo.Enabled = false;
                btnNew.Enabled = false;
                EditarEvento?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabMenu);
                tabControl1.TabPages.Add(tabCadastro);
                tabCadastro.Text = "Editar Produto";
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

        //Propriedades
        public string ProdCodigo
        {
            get { return txtCodigo.Text; }
            set { txtCodigo.Text = value; }
        }
        public string ProdNome
        {
            get { return txtNome.Text; }
            set { txtNome.Text = value; }
        }
        public string ProdPalete
        {
            get { return txtPalete.Text; }
            set { txtPalete.Text = value; }
        }
        public string ProdEstoque
        {
            get { return txtEstoque.Text; }
            set { txtEstoque.Text = value; }
        }
        public int ProdCategoria
        {
            get { return (int)cbCategoria1.SelectedValue  ; }
            set { cbCategoria1.SelectedValue = value; }
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

        public event EventHandler PesquisaEvento;
        public event EventHandler AdicionarEvento;
        public event EventHandler EditarEvento;
        public event EventHandler DeletarEvento;
        public event EventHandler SalvoEvento;
        public event EventHandler CancelarEvento;

        public void SetGridProdutos(BindingSource prodLista)
        {
            dgLista.DataSource = prodLista;
        }

        private static ProdutosView instance;
        public static ProdutosView Instancia(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ProdutosView();
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

        private void ConfigurarComboBox()
        {
            // Lista de itens com chave e valor
            var itens = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(1, "1. Blocos"),
                new KeyValuePair<int, string>(2, "2. Mourão"),
                new KeyValuePair<int, string>(3, "3. Pilar")
            };

            cbCategoria1.DataSource = itens;
            cbCategoria1.DisplayMember = "Value"; 
            cbCategoria1.ValueMember = "Key";

            cbCategoria.DataSource = itens;
            cbCategoria.DisplayMember = "Value";
            cbCategoria.ValueMember = "Key";

        }
        private void ProdutosView_Load(object sender, EventArgs e)
        {
            ConfigurarComboBox();
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCategoria1.SelectedIndex = cbCategoria.SelectedIndex;
        }
    }
}
