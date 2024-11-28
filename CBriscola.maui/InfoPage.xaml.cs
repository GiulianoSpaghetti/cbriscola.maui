/*
 *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 2.0
 *
 *  Created by numerone on 28/01/23.
 *  Copyright 2023 Some rights reserved.
 *
 */
namespace CBriscola.maui;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();
	}
    private async void OnSito_Click(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync(new Uri("https://github.com/numerunix/cbriscola.maui"));
    }
}