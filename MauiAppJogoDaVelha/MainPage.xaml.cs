using System;

namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        //Contador de jogadas para sabermos se deu velha (máximo de 9 cliques)
        int jogadas = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.IsEnabled = false;

            if (vez == "X")
            {
                btn.Text = "X";
                vez = "O";
            }
            else
            {
                btn.Text = "O";
                vez = "X";
            }

            //Toda vez que um botão for clicado, somamos 1 ao total de jogadas
            jogadas++;

            if (VerificarVencedor("X"))
            {
                DisplayAlert("Parabéns!", "O X ganhou!", "OK");
                Zerar();
            }
            else if (VerificarVencedor("O"))
            {
                DisplayAlert("Parabéns!", "O O ganhou!", "OK");
                Zerar();
            }
            else if (jogadas == 9)
            {
                //9 cliques e nenhum "if" acima deu verdadeiro, deu Velha!
                DisplayAlert("Deu Velha!", "Ninguém ganhou essa rodada.", "OK");
                Zerar();
            }

        } // Fecha método do clique

        /* Juiz do Jogo checa as 8 combinações possíveis.
           Retorna 'true' se o jogador enviado (X ou O) preencheu uma trinca.*/
        bool VerificarVencedor(string jogador)
        {
            //Verificação das Linhas Horizontais
            if (btn10.Text == jogador && btn11.Text == jogador && btn12.Text == jogador) return true;
            if (btn20.Text == jogador && btn21.Text == jogador && btn22.Text == jogador) return true;
            if (btn30.Text == jogador && btn31.Text == jogador && btn32.Text == jogador) return true;

            //Verificação das Linhas Verticais
            if (btn10.Text == jogador && btn20.Text == jogador && btn30.Text == jogador) return true;
            if (btn11.Text == jogador && btn21.Text == jogador && btn31.Text == jogador) return true;
            if (btn12.Text == jogador && btn22.Text == jogador && btn32.Text == jogador) return true;

            //Verificação das Diagonais
            if (btn10.Text == jogador && btn21.Text == jogador && btn32.Text == jogador) return true;
            if (btn12.Text == jogador && btn21.Text == jogador && btn30.Text == jogador) return true;

            //Se o código chegou até aqui, significa que esse jogador não fechou nenhuma trinca
            return false;
        }

        void Zerar()
        {
            // Limpa o texto de todos os 9 Objetos botões
            btn10.Text = ""; btn11.Text = ""; btn12.Text = "";
            btn20.Text = ""; btn21.Text = ""; btn22.Text = "";
            btn30.Text = ""; btn31.Text = ""; btn32.Text = "";

            // Reativa o Atributo IsEnabled de todos para que possam ser clicados de novo
            btn10.IsEnabled = true; btn11.IsEnabled = true; btn12.IsEnabled = true;
            btn20.IsEnabled = true; btn21.IsEnabled = true; btn22.IsEnabled = true;
            btn30.IsEnabled = true; btn31.IsEnabled = true; btn32.IsEnabled = true;

            // Reseta as variáveis de controle do jogo
            vez = "X";
            jogadas = 0; // NOVO: Zera as jogadas para começar a contar de novo
        }

    } // Fecha Classe
} // Fecha Namespace