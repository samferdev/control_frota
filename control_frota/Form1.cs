using System;
using System.Drawing;
using System.Windows.Forms;

namespace control_frota
{
    public partial class Form1 : Form
    {
        ListBox lstCarros;
        ListBox lstCaminhao;

        TextBox txtModelo;
        TextBox txtPlaca;
        TextBox txtKM;
        TextBox txtEixos;

        Label lblEixos;

        GroupBox grpCaminhoes;

        string tipoSelecionado = "carro"; // valor padrão

        public Form1()
        {
            InicializarLayout();
        }

        public void InicializarLayout()
        {
            this.Text = "Controle de frota";
            this.Size = new Size(800, 600);

            // Botões
            Button btnCarro = new Button { Text = "", Location = new Point(100, 30), Size = new Size(100, 40) };
            btnCarro.Image = Image.FromFile("assets/carro.jpg").GetThumbnailImage(32, 32, null, IntPtr.Zero);

            Button btnCaminhao = new Button { Text = "", Location = new Point(210, 30), Size = new Size(100, 40) };
            btnCaminhao.Image = Image.FromFile("assets/caminhao.png").GetThumbnailImage(32, 32, null, IntPtr.Zero);

            Button btnSalvar = new Button { Text = "", Location = new Point(320, 30), Size = new Size(100, 40) };
            btnSalvar.Image = Image.FromFile("assets/salvar.png").GetThumbnailImage(32, 32, null, IntPtr.Zero);

            // Labels e TextBoxes
            Label lblModelo = new Label { Text = "Modelo:", Location = new Point(100, 90), AutoSize = true };
            txtModelo = new TextBox { Location = new Point(160, 87), Width = 200 };

            Label lblPlaca = new Label { Text = "Placa:", Location = new Point(100, 120), AutoSize = true };
            txtPlaca = new TextBox { Location = new Point(160, 117), Width = 200 };

            Label lblKM = new Label { Text = "Km:", Location = new Point(100, 150), AutoSize = true };
            txtKM = new TextBox { Location = new Point(160, 147), Width = 200 };

            lblEixos = new Label { Text = "Eixos:", Location = new Point(100, 180), AutoSize = true };
            txtEixos = new TextBox { Location = new Point(160, 177), Width = 200 };

            // Esconde inicialmente
            lblEixos.Visible = false;
            txtEixos.Visible = false;

            // GroupBoxes
            GroupBox grpCarros = new GroupBox
            {
                Text = "Carros",
                Location = new Point(100, 220),
                Size = new Size(250, 200)
            };

            grpCaminhoes = new GroupBox
            {
                Text = "Caminhões",
                Location = new Point(400, 220),
                Size = new Size(250, 200)
            };

            // Eventos dos botões
            btnCarro.Click += (s, e) => {
                tipoSelecionado = "carro";
                EsconderEixo(false);
            };

            btnCaminhao.Click += (s, e) => {
                tipoSelecionado = "caminhao";
                EsconderEixo(true);
            };

            // Adiciona controles ao formulário
            this.Controls.Add(btnCarro);
            this.Controls.Add(btnCaminhao);
            this.Controls.Add(btnSalvar);
            this.Controls.Add(lblModelo);
            this.Controls.Add(txtModelo);
            this.Controls.Add(lblPlaca);
            this.Controls.Add(txtPlaca);
            this.Controls.Add(lblKM);
            this.Controls.Add(txtKM);
            this.Controls.Add(lblEixos);
            this.Controls.Add(txtEixos);
            this.Controls.Add(grpCarros);
            this.Controls.Add(grpCaminhoes);

            btnSalvar.Click += BtnSalvar_Click;

            // ListBoxes
            lstCarros = new ListBox
            {
                Location = new Point(10, 20),
                Size = new Size(230, 160)
            };
            grpCarros.Controls.Add(lstCarros);

            lstCaminhao = new ListBox
            {
                Location = new Point(10, 20),
                Size = new Size(230, 160)
            };
            grpCaminhoes.Controls.Add(lstCaminhao); //control caminhão corrigido
        }

        private void BtnSalvar_Click(object sender, EventArgs e)//Função salvar corrigida
        {
            if (!int.TryParse(txtKM.Text, out int km))
            {
                MessageBox.Show("O campo KM deve conter apenas números.", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Veiculo novoVeiculo = new Veiculo
            {
                Modelo = txtModelo.Text,
                Placa = txtPlaca.Text,
                KM = km.ToString(),
                Eixos = txtEixos.Text
            };

            string texto = $"Modelo: {novoVeiculo.Modelo}\nPlaca: {novoVeiculo.Placa}\nKM: {novoVeiculo.KM}";

            if (tipoSelecionado == "carro")
            {
                lstCarros.Items.Add(texto);
            }
            else if (tipoSelecionado == "caminhao")
            {
                texto += $"\nEixos: {novoVeiculo.Eixos}";
                lstCaminhao.Items.Add(texto);
            }
        }

        public void EsconderEixo(bool mostrar)//adicionado função escondereixos
        {
            txtEixos.Visible = mostrar;
            lblEixos.Visible = mostrar;
        }

        public class Veiculo
        {
            public string Modelo { get; set; }
            public string Placa { get; set; }
            public string KM { get; set; }
            public string? Eixos { get; set; }
        }
    }
}
