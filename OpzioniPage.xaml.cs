/*
 *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 2.0
 *
 *  Created by numerone on 28/01/23.
 *  Copyright 2023 Some rights reserved.
 *
 */namespace cbriscola;

public partial class OpzioniPage : ContentPage
{
	public OpzioniPage()
	{
		InitializeComponent();
        txtNomeUtente.Text = Preferences.Get("nomeUtente", "Giulio");
        txtCpu.Text = Preferences.Get("nomeCpu", "Cpu");
        txtSecondi.Text = $"{(UInt16)Preferences.Get("secondi", 5)}";
        cbCartaBriscola.IsChecked = Preferences.Get("briscolaDaPunti", false);
        cbAvvisaTallone.IsChecked = Preferences.Get("avvisaTalloneFinito", true);
    }

    public void OnOk_Click(Object source, EventArgs evt)
    {
        bool briscolaDaPunti, avvisaTalloneFinito;
        UInt16 secondi;
        Preferences.Set("nomeUtente", txtNomeUtente.Text);
        Preferences.Set("nomeCpu", txtCpu.Text);
        if (cbCartaBriscola.IsChecked == false)
            briscolaDaPunti = false;
        else
            briscolaDaPunti = true;
        Preferences.Set("briscolaDaPunti", briscolaDaPunti);
        if (cbAvvisaTallone.IsChecked == false)
            avvisaTalloneFinito = false;
        else
            avvisaTalloneFinito = true;
        Preferences.Set("avvisaTalloneFinito", avvisaTalloneFinito);

        try
        {
            secondi = UInt16.Parse(txtSecondi.Text);
        }
        catch (FormatException ex)
        {
            txtSecondi.Text = "Invalid rvalue";
            return;
        }
        Preferences.Set("secondi", secondi);
        CBriscola2._0.AppShell.aggiorna = true;
        Navigation.PopAsync();
    }
}