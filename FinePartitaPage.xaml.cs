/*
 *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 2.0
 *
 *  Created by numerone on 28/01/23.
 *  Copyright 2023 Some rights reserved.
 *
 */

using org.altervista.numerone.framework;

namespace TrumpSuitGame;

public partial class FinePartitaPage : ContentPage
{
    private Giocatore g, cpu;
	public FinePartitaPage(Giocatore g, Giocatore cpu)
	{
        string s;
        this.g=g; this.cpu=cpu;
		InitializeComponent();
        if (g.GetPunteggio() == cpu.GetPunteggio())
            s = "Gam is drown";
        else
        {
            if (g.GetPunteggio() > cpu.GetPunteggio())
                s = "You win";
            else
                s = "You loose";
            s = $"{s} for {Math.Abs(g.GetPunteggio() - cpu.GetPunteggio())} points";
        }
        Risultato.Text = $"The game is over. {s}. Do you want to play again?";

    }
    private async void OnShare_Click(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync(new Uri($"https://twitter.com/intent/tweet?text=With%20the%20Trump%20Suit%20Game%20the%20match%20{g.GetNome()}%20versus%20{cpu.GetNome()}%20is%20finishd%20{g.GetPunteggio()}%20at%20{cpu.GetPunteggio()}%20on%20platorm%20Windows%20NT%20with%20Neapolitan%20Deck&url=https%3A%2F%2Fgithub.com%2Fnumerunix%2Fcbriscola.maui"));
        Condividi.IsEnabled = false;
    }

    private void OnCancel_Click(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}