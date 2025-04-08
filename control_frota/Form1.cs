using System;
using System.Drawing.Text;
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

        string tipoSelecionado = "carro"; // valor padrão


        public Form1()
        {
            //InitializeComponent();
            InicializarLayout();
        }

        private void InicializarLayout()
        {
            this.Text = "Controle de frota";
            this.Size = new System.Drawing.Size(800, 600);

            // Botões
            Button btnCarro = new Button { Text = "",Location = new System.Drawing.Point(100, 30), Size = new System.Drawing.Size(100, 40) };
            btnCarro.Image = Image.FromFile("assets/carro.jpg").GetThumbnailImage(32, 32, null, IntPtr.Zero); // largura, altura

            
            Button btnCaminhao = new Button { Text = "", Location = new System.Drawing.Point(210, 30), Size = new System.Drawing.Size(100, 40) };
            btnCaminhao.Image = Image.FromFile("assets/caminhao.png").GetThumbnailImage(32, 32, null, IntPtr.Zero);

                        
            Button btnSalvar = new Button { Text = "", Location = new System.Drawing.Point(320, 30), Size = new System.Drawing.Size(100, 40) };
            btnSalvar.Image = Image.FromFile("assets/salvar.png").GetThumbnailImage(32, 32, null, IntPtr.Zero);

            // Labels e TextBoxes
            Label lblModelo = new Label { Text = "Modelo:", Location = new System.Drawing.Point(100, 90), AutoSize = true };
            txtModelo = new TextBox { Location = new System.Drawing.Point(160, 87), Width = 200 };

            Label lblPlaca = new Label { Text = "Placa:", Location = new System.Drawing.Point(100, 120), AutoSize = true };
            txtPlaca = new TextBox { Location = new System.Drawing.Point(160, 117), Width = 200 };

            Label lblKM = new Label { Text = "Km:", Location = new System.Drawing.Point(100, 150), AutoSize = true };
            txtKM = new TextBox { Location = new System.Drawing.Point(160, 147), Width = 200 };

            Label lblEixos = new Label { Text = "Eixos:", Location = new System.Drawing.Point(100, 180), AutoSize = true };
            txtEixos = new TextBox { Location = new System.Drawing.Point(160, 177), Width = 200 };

            // Áreas para visualização (como placeholders)
            GroupBox grpCarros = new GroupBox
            {
                Text = "Carros",
                Location = new System.Drawing.Point(100, 220),
                Size = new System.Drawing.Size(250, 200),

                
            };

            GroupBox grpCaminhoes = new GroupBox
            {
                Text = "Caminhões",
                Location = new System.Drawing.Point(400, 220),
                Size = new System.Drawing.Size(250, 200)
            };

            btnCarro.Click += (s, e) => tipoSelecionado = "carro";
            btnCaminhao.Click += (s, e) => tipoSelecionado = "caminhao";


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

            lstCarros = new ListBox{
                Location = new System.Drawing.Point(10, 20),
                Size = new System.Drawing.Size(230, 160)
            };

            grpCarros.Controls.Add(lstCarros);

            lstCaminhao = new ListBox{
                Location = new System.Drawing.Point(10, 20),
                Size = new System.Drawing.Size(230, 160)
            };

            grpCarros.Controls.Add(lstCaminhao);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            Veiculo novoVeiculo = new Veiculo{
                Modelo = txtModelo.Text,
                Placa = txtPlaca.Text,
                KM = txtKM.Text,
                Eixos = txtEixos.Text
            };

            string texto = $"Modelo: {novoVeiculo.Modelo}, Placa: {novoVeiculo.Placa}, KM: {novoVeiculo.KM}";

            if(tipoSelecionado == "carro"){
                lstCarros.Items.Add(texto);
            } else if (tipoSelecionado == "caminhão"){
                lstCaminhao.Items.Add(texto);
            }

           
        }

        public class Veiculo{
            public string Modelo{get; set; }
            public string Placa{get; set; }
            public string KM{get; set; }
            public string Eixos{get; set; }

        }

    }
}
