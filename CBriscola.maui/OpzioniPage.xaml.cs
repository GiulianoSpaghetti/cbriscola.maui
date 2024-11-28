/*
 *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 2.0
 *
 *  Created by numerone on 28/01/23.
 *  Copyright 2023 Some rights reserved.
 *
 */
using Microsoft.Toolkit.Uwp.Notifications;

namespace CBriscola.maui;

public partial class OpzioniPage : ContentPage
{
	public OpzioniPage()
	{
		InitializeComponent();
        txtNomeUtente.Text = Preferences.Get("nomeUtente", "numerone");
        txtCpu.Text = Preferences.Get("nomeCpu", "numerona");
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
            new ToastContentBuilder().AddArgument("Invalid rvalue").AddText("Invalid rvalue").AddAudio(new Uri("ms-winsoundevent:Notification.Reminder")).Show();
            return;
        }
        catch (OverflowException ex)
        {
            secondi = (UInt16) Preferences.Get("secondi", 5);
            txtSecondi.Text = secondi.ToString();
            new ToastContentBuilder().AddArgument("Invalid rvalue").AddText("Invalid rvalue").AddAudio(new Uri("ms-winsoundevent:Notification.Reminder")).Show();
            return;
        }
        if (secondi<1)
        {
            secondi = (UInt16)Preferences.Get("secondi", 5);
            txtSecondi.Text = secondi.ToString();
            new ToastContentBuilder().AddArgument("Invalid rvalue").AddText("Invalid rvalue").AddAudio(new Uri("ms-winsoundevent:Notification.Reminder")).Show();
            return;
        }
        Preferences.Set("secondi", secondi);
        CBriscola.maui.AppShell.aggiorna = true;
        Shell.Current.GoToAsync("//Main");
    }
}