using System;
using System.Diagnostics;

namespace MyMauiWebView202311;

public partial class MainPage : ContentPage
{
    int count = 0;

	public MainPage()
	{
		InitializeComponent();

        myWebView.Navigating += WebViewNavigating;
        myWebView.Navigated += WebViewNavigated;

        Dispatcher.Dispatch(() =>
        {
            Debug.WriteLine($"[constructor] Change myWebView.Source for the first time");
            myWebView.Source = new HtmlWebViewSource() { Html = "<html><body><h1>#1: In constructor</h1></body></html>" };
        });
    }

    /// <inheritdoc cref="VisualElement.Loaded"/>
    private void WebViewLoaded(object sender, EventArgs e)
    {
        //Debug.WriteLine($"[WebViewLoaded] Change myWebView.Source for the second time");
        // myWebView.Source = new UrlWebViewSource() { Url = "https://github.com/dotnet/maui/" };
        // myWebView.Source = new HtmlWebViewSource() { Html = "<html><body><h1>#2: After loaded</h1></body></html>" };
    }

    /// <inheritdoc cref="EventHandler{WebNavigatingEventArgs}"/>
    private void WebViewNavigating(object? sender, WebNavigatingEventArgs e)
    {
        Debug.WriteLine($"[WebViewNavigating] * e.URL='{e.Url}'");
    }

    /// <inheritdoc cref="EventHandler{WebNavigatedEventArgs}"/>
    private void WebViewNavigated(object? sender, WebNavigatedEventArgs e)
    {
        Debug.WriteLine($"[WebViewNavigated] * e.URL='{e.Url}'");
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

