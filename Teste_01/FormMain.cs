using System;
using System.Windows.Forms;

namespace Teste_01 {
	public partial class FormMain : Form {

		const int quantidadeTotal = 20;
		int qtdNext = 0; int qtdReturn = 0; int posicaoJogador = 0;
		bool trocaJogador = false;
		int jogadorAtual = 1; int posicaoJogador1 = 0; int qtdCasaAndou = 0;
		int posicaoJogador2 = 0; int resposta = 0;

		public FormMain() /// construtor
		{
			InitializeComponent();
			lblJogador.Text = "Jogador " + jogadorAtual;
			HabilitaPergunta(false);
		}

		public void HabilitaPergunta(bool habilitar)
		{
			txtResposta.Visible = habilitar;
			lblPergunta.Visible = habilitar;
			btnValidate.Visible = habilitar;
			txtResposta.Text = lblPergunta.Text = "";
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (qtdReturn <= 0 && qtdNext == 0) return;

			if (posicaoJogador == 19)
				qtdNext = 1;

			if (jogadorAtual == 1)
				ValidaJogador01();
			else
				ValidaJogador02();
		}

		public void LimparJogador01()
		{
			play_1_1.BackgroundImage = null; play_1_2.BackgroundImage = null; play_1_3.BackgroundImage = null;
			play_1_4.BackgroundImage = null; play_1_5.BackgroundImage = null; play_1_6.BackgroundImage = null;
			play_1_7.BackgroundImage = null; play_1_8.BackgroundImage = null; play_1_9.BackgroundImage = null;
			play_1_10.BackgroundImage = null; play_1_11.BackgroundImage = null; play_1_12.BackgroundImage = null;
			play_1_13.BackgroundImage = null; play_1_14.BackgroundImage = null; play_1_15.BackgroundImage = null;
			play_1_16.BackgroundImage = null; play_1_17.BackgroundImage = null; play_1_18.BackgroundImage = null;
			play_1_19.BackgroundImage = null; play_1_20.BackgroundImage = null;
		}

		public void LimparJogador02()
		{
			play_2_1.BackgroundImage = null; play_2_2.BackgroundImage = null; play_2_3.BackgroundImage = null;
			play_2_4.BackgroundImage = null; play_2_5.BackgroundImage = null; play_2_6.BackgroundImage = null;
			play_2_7.BackgroundImage = null; play_2_8.BackgroundImage = null; play_2_9.BackgroundImage = null;
			play_2_10.BackgroundImage = null; play_2_11.BackgroundImage = null; play_2_12.BackgroundImage = null;
			play_2_13.BackgroundImage = null; play_2_14.BackgroundImage = null; play_2_15.BackgroundImage = null;
			play_2_16.BackgroundImage = null; play_2_17.BackgroundImage = null; play_2_18.BackgroundImage = null;
			play_2_19.BackgroundImage = null; play_2_20.BackgroundImage = null;
		}

		private void MudaImagem(Panel anterior, Panel proxima)
		{
			if (qtdNext != 0 && proxima != null)
			{
				proxima.BackgroundImage = jogadorAtual == 1 ?
												Teste_01.Properties.Resources.People01 : Teste_01.Properties.Resources.People02;
			}
			else if (qtdReturn != 0 && anterior != null)
			{
				anterior.BackgroundImage = jogadorAtual == 1 ? 
												Teste_01.Properties.Resources.People01 : Teste_01.Properties.Resources.People02;
			}
		}

		public void ValidaJogador01()
		{
			LimparJogador01();

			switch (posicaoJogador1)
			{
				case 0: MudaImagem(null, play_1_1); break;
				case 1: MudaImagem(null, play_1_2); break;
				case 2: MudaImagem(play_1_1, play_1_3); break;
				case 3: MudaImagem(play_1_2, play_1_4); break;
				case 4: MudaImagem(play_1_3, play_1_5); break;
				case 5: MudaImagem(play_1_4, play_1_6); break;
				case 6: MudaImagem(play_1_5, play_1_7); break;
				case 7: MudaImagem(play_1_6, play_1_8); break;
				case 8: MudaImagem(play_1_7, play_1_9); break;
				case 9: MudaImagem(play_1_8, play_1_10); break;
				case 10: MudaImagem(play_1_9, play_1_11); break;
				case 11: MudaImagem(play_1_10, play_1_12); break;
				case 12: MudaImagem(play_1_11, play_1_13); break;
				case 13: MudaImagem(play_1_12, play_1_14); break;
				case 14: MudaImagem(play_1_13, play_1_15); break;
				case 15: MudaImagem(play_1_14, play_1_16); break;
				case 16: MudaImagem(play_1_15, play_1_17); break;
				case 17: MudaImagem(play_1_16, play_1_18); break;
				case 18: MudaImagem(play_1_17, play_1_19); break;
				case 19: MudaImagem(play_1_18, play_1_20); break;
			}

			if (qtdNext > 0)
			{
				posicaoJogador1++;
				qtdCasaAndou++;
				if (qtdCasaAndou != qtdNext)
				{
					//btnNext.Enabled = true;
				}
				else
				{
					posicaoJogador = posicaoJogador1;
					VerificarPosicao();
					qtdCasaAndou = 0;
				}
			}
			else if (qtdReturn < 0)
			{
				posicaoJogador1--;
				qtdCasaAndou--;

				if (qtdCasaAndou != qtdReturn)
				{
					if(posicaoJogador1 == 0)
					{
						qtdCasaAndou = 0;
						qtdReturn = 0;
					}
					//btnNext.Enabled = true;
				}
				else
				{
					posicaoJogador = posicaoJogador1;

					if(posicaoJogador1 != 5 && posicaoJogador1 != 12 && posicaoJogador1 != 18)
						qtdReturn = 0;

					VerificarPosicao();
					qtdCasaAndou = 0;
					HabilitarBotoes(true);
				}
			}

			if (posicaoJogador == 0)
				HabilitaPergunta(false);

			if (trocaJogador)
			{
				if (jogadorAtual == 1)
				{
					posicaoJogador = posicaoJogador2;
					jogadorAtual = 2;
				}
				else
				{
					posicaoJogador = posicaoJogador1;
					jogadorAtual = 1;
				}

				lblJogador.Text = "Jogador " + jogadorAtual;

				MessageBox.Show("Trocou de Jogador, GIRE A ROLETA.");
				lblCasas.Text = "";
				HabilitaPergunta(false);

				trocaJogador = false;
			}
		}

		public void ValidaJogador02()
		{
			LimparJogador02();

			switch (posicaoJogador2)
			{
				case 0: MudaImagem(null, play_2_1); break;
				case 1: MudaImagem(null, play_2_2); break;
				case 2: MudaImagem(play_2_1, play_2_3); break;
				case 3: MudaImagem(play_2_2, play_2_4); break;
				case 4: MudaImagem(play_2_3, play_2_5); break;
				case 5: MudaImagem(play_2_4, play_2_6); break;
				case 6: MudaImagem(play_2_5, play_2_7); break;
				case 7: MudaImagem(play_2_6, play_2_8); break;
				case 8: MudaImagem(play_2_7, play_2_9); break;
				case 9: MudaImagem(play_2_8, play_2_10); break;
				case 10: MudaImagem(play_2_9, play_2_11); break;
				case 11: MudaImagem(play_2_10, play_2_12); break;
				case 12: MudaImagem(play_2_11, play_2_13); break;
				case 13: MudaImagem(play_2_12, play_2_14); break;
				case 14: MudaImagem(play_2_13, play_2_15); break;
				case 15: MudaImagem(play_2_14, play_2_16); break;
				case 16: MudaImagem(play_2_15, play_2_17); break;
				case 17: MudaImagem(play_2_16, play_2_18); break;
				case 18: MudaImagem(play_2_17, play_2_19); break;
				case 19: MudaImagem(play_2_18, play_2_20); break;
			}
		
			if (qtdNext > 0)
			{
				posicaoJogador2++;
				qtdCasaAndou++;
				if (qtdCasaAndou != qtdNext)
				{
					//btnNext.Enabled = true;
				}
				else
				{
					posicaoJogador = posicaoJogador2;
					VerificarPosicao();
					qtdCasaAndou = 0;
				}
			}
			else if (qtdReturn < 0)
			{
				posicaoJogador2--;
				qtdCasaAndou--;

				if (qtdCasaAndou != qtdReturn)
				{
					if (posicaoJogador2 == 0)
					{
						qtdCasaAndou = 0;
						qtdReturn = 0;
					}
				}
				else
				{
					posicaoJogador = posicaoJogador2;
					if (posicaoJogador2 != 5 && posicaoJogador2 != 12 && posicaoJogador2 != 18)
						qtdReturn = 0;

					VerificarPosicao();
					qtdCasaAndou = 0;
					HabilitarBotoes(true);
				}
			}

			if (posicaoJogador == 0)
				HabilitaPergunta(false);

			if (trocaJogador)
			{
				if (jogadorAtual == 1)
				{
					posicaoJogador = posicaoJogador2;
					jogadorAtual = 2;
				}
				else
				{
					posicaoJogador = posicaoJogador1;
					jogadorAtual = 1;
				}

				lblJogador.Text = "Jogador " + jogadorAtual;
				MessageBox.Show("Trocou de Jogador");
				lblCasas.Text = "";

				HabilitaPergunta(false);
				trocaJogador = false;
			}
		}

		private void DesabilitaResposta(bool resp)
		{
			txtResposta.Visible = resp;
			btnValidate.Visible = resp;
		}

		public void VerificarPosicao()
		{
			if (posicaoJogador < 0) return;
			HabilitarBotoes(false);
			HabilitaPergunta(true);

			switch (posicaoJogador)
			{
				case 1: lblPergunta.Text = "(9+2) - (1+6)"; break;
				case 2: lblPergunta.Text = "Tem 88 patos na lagoa, sai 30 patos da lagoa. Quantos sobra?"; break; //lbl label2
				case 3: lblPergunta.Text = "10 + 3"; break;
				case 4: lblPergunta.Text = "Tenho 12 bananas tiro 6 bananas. Quantas bananas sobram?"; break;
				case 6: lblPergunta.Text = "10 + 12 – 6 + 7"; break;
				case 8: lblPergunta.Text = "12 - 2"; break;
				case 9: lblPergunta.Text = "50 - # - 30 = 11. Qual o valor de #?"; break;
				case 11: lblPergunta.Text = "Quantas bananas  você vai ter se comprar 12 bananas mais 6 bananas?"; break;
				case 13: lblPergunta.Text = "13 - 2"; break;
				case 15: lblPergunta.Text = "76 + 81 * 3 – 39"; break;
				case 16: lblPergunta.Text = "18 - 3 = ?"; break;
				case 17: lblPergunta.Text = "4 + # + 10 + 5 = 22. Qual o valor de #?"; break;
				case 19: lblPergunta.Text = "15 + 5"; break;
				case 20: lblPergunta.Text = "Tenho 10 balas quero dividir para 2 crianças. Quantas balas cada criança terá?"; break;
				default:
					break;
			}

			if (posicaoJogador == 5)
			{
				qtdNext = 0;
				qtdReturn = -3;
				lblPergunta.Text = "Volte 3 casas";

				DesabilitaResposta(false);
				HabilitarBotoes(true);
			}

			if (posicaoJogador == 7)
			{
				qtdNext = 0;
				qtdReturn = 0;

				trocaJogador = true;

				lblPergunta.Text = "Perca uma jogada.";
				DesabilitaResposta(false);
				HabilitarBotoes(true);
			}

			if (posicaoJogador == 10)
			{
				lblPergunta.Text = "Pule uma casa";

				DesabilitaResposta(false);
				qtdNext = 1;
				qtdReturn = 0;
				HabilitarBotoes(true);
			}

			if (posicaoJogador == 12)
			{
				DesabilitaResposta(false);
				lblPergunta.Text = "Volte aonde estava";

				if (qtdNext > 0)
				{
					qtdReturn -= qtdNext;
					qtdNext = 0;
				}
				else
				{
					qtdNext = 1 * qtdReturn;
					qtdReturn = 0;
				}
				HabilitarBotoes(true);
			}
			
			if (posicaoJogador == 14)
			{
				lblPergunta.Text = "Pule 2 casas";

				DesabilitaResposta(false);
				qtdNext = 2;
				qtdReturn = 0;
				HabilitarBotoes(true);
			}
			
			if (posicaoJogador == 18)
			{
				lblPergunta.Text = "Volte 5 casas";

				DesabilitaResposta(false);
				qtdReturn = -5;
				qtdNext = 0;
				HabilitarBotoes(true);
			}
		}

		private void btnValidate_Click(object sender, EventArgs e)
		{
			ValidarResposta();
			HabilitarBotoes(true);
		}

		public void ValidarResposta()
		{
			switch (posicaoJogador)
			{
				case 1: case 2: case 3: case 4: case 6: case 8:  case 9: case 11:
				case 13: case 15: case 16: case 17: case 19: case 20:
					if (!string.IsNullOrWhiteSpace(txtResposta.Text)) int.TryParse(txtResposta.Text.Trim(), out resposta);
					break;
			}

			switch (posicaoJogador)
			{
				case 1: if (resposta == 4) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;
				case 2: if (resposta == 58) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;
				case 3: if (resposta == 13) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;
				case 4: if (resposta == 6) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;
				case 6: if (resposta == 23) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;
				case 8: if (resposta == 10) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;
				 case 9: if (resposta == 9) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;
				//case 9: if (!string.IsNullOrWhiteSpace(txtResposta.Text) 
					//			&& txtResposta.Text.Trim().ToUpper().Contains("PAR")) 
						//VerificaSucessoErro(true); else VerificaSucessoErro(false); break;

				case 11: if (resposta == 18) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;
				case 13: if (resposta == 11) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;
				case 15: if (resposta == 280) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;
				case 16: if (resposta == 15) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;
				case 17: if (resposta == 3) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;
				//case 17: if (!string.IsNullOrWhiteSpace(txtResposta.Text)
					//				&& (txtResposta.Text.Trim().ToUpper().Contains("22") || txtResposta.Text.Trim().ToUpper().Contains("ÍMPAR")))
						//				VerificaSucessoErro(true); else VerificaSucessoErro(false); break;

				case 19: if (resposta == 20) VerificaSucessoErro(true); else VerificaSucessoErro(false); break;

				case 20:
					if (!string.IsNullOrWhiteSpace(txtResposta.Text)
							&& txtResposta.Text.Trim().ToUpper().Contains("5")) {
						
						MessageBox.Show($"Parabéns jogador { jogadorAtual } VENCEU! ", "Sucesso", 
							MessageBoxButtons.OK, MessageBoxIcon.None);

						LimparJogador01();
						LimparJogador02();
						HabilitaPergunta(false);
						posicaoJogador = 0;
						posicaoJogador1 = 0;
						posicaoJogador2 = 0;
						qtdNext = 0;
						qtdReturn = 0;
					}
					else VerificaSucessoErro(false); break;

				default: break;
			}
			qtdCasaAndou = 0;
		}

		private void HabilitarBotoes(bool enable)
		{
			btnNext.Enabled = enable;
			btnReturn.Enabled = enable;
		}

		private void VerificaSucessoErro(bool result)
		{
			if (result)
			{
				lblPergunta.Text = "Parabéns. Gire a roleta novamente";
				qtdNext = 0;
				qtdReturn = 0;
			}
			else
			{
				lblPergunta.Text = "ERROU. Volte uma casa";
				qtdNext = 0;
				qtdReturn = -1;
				trocaJogador = true;
			}
			DesabilitaResposta(false);
		}

		private void btnReturn_Click(object sender, EventArgs e)
		{
			if ((qtdNext == 0 && qtdReturn == 0 )
				|| posicaoJogador == 0 )
				return;

			if (qtdReturn == 0)
				return;

			if (jogadorAtual == 1)
				ValidaJogador01();
			else
				ValidaJogador02();
		}

		private void Randomic()
		{
			qtdNext = 0;
			qtdReturn = 0;
			string[] datas = new string[] { "-1", "-2", "1", "2", "3", "4" };

			Random r = new Random();

			for (int i = 0; i < 50; i++)
			{
				lblCasas.Text = datas[r.Next(datas.Length)];
				panelRefresh.Refresh();
			}

			int casas = int.Parse(lblCasas.Text);

			if (casas > 0)
				qtdNext = casas;
			else
				qtdReturn = casas;

			if (posicaoJogador <= 0 && casas < 0)
				Randomic();

			if((posicaoJogador + casas) > 20)
				Randomic();
		}

		private void btnRoleta_Click(object sender, EventArgs e)
		{
			Randomic();
			//HabilitaRoleta(false);
		}

        private void panel49_Paint(object sender, PaintEventArgs e)
        {

        }

        private void play_1_1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}