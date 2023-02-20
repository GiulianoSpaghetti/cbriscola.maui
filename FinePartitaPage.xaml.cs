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
            s = "La partita è patta";
        else
        {
            if (g.GetPunteggio() > cpu.GetPunteggio())
                s = "Hai vinto";
            else
                s = "Hai perso";
            s = $"{s} per {Math.Abs(g.GetPunteggio() - cpu.GetPunteggio())} punti";
        }
        Risultato.Text = $"La partita è finita. {s}. Vuoi giocarne un'altra?";

    }
    private async void OnShare_Click(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync(new Uri($"https://twitter.com/intent/tweet?text=Con%20Cbriscola%202.0%20il%20match%20{g.GetNome()}%20contro%20{cpu.GetNome()}%20è%20finito%20{g.GetPunteggio()}%20a%20{cpu.GetPunteggio()}%20su%20piattaforma%20Windows%20NT%203.51%20con%20mazzo%20Napoletano&url=https%3A%2F%2Fgithub.com%2Fnumerunix%2Fcbriscola.maui"));
        Condividi.IsEnabled = false;
    }

    private void OnCancel_Click(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}