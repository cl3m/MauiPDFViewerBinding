#if ANDROID
using Binding = Com.Maui.Binding.Binding;
using MauiDemoApp.Platforms.Android;
#elif IOS || MACCATALYST
using iOS.Binding;
#endif

namespace MauiDemoApp;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
	}

    private void OnOpenPDFClicked(object sender, EventArgs e)
    {
        var title = "Sample PDF";
        var url = "https://dagrs.berkeley.edu/sites/default/files/2020-01/sample.pdf";
#if ANDROID
        new Binding().OpenPDF(MainActivity.instance, title, url);
#elif IOS || MACCATALYST
        new iOS.Binding.Binding().OpenPDFWithTitle(title, url);
#endif
    }

    void OnAsyncClicked(System.Object sender, System.EventArgs e)
    {
        asyncButton.IsVisible = false;
        asyncLabel.IsVisible = true;
        var parameters = new[] { "Hello", "world!" };
        
#if ANDROID
        new Binding().Async(MainActivity.instance, parameters.ToList(), new StringResultImpl() { callback = OnAsyncResult });
#elif IOS || MACCATALYST
        new iOS.Binding.Binding().AsyncWithParameters(parameters, OnAsyncResult);
#endif
    }

    private void OnAsyncResult(string result)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            asyncLabel.Text = result;
        });        
    }
}


