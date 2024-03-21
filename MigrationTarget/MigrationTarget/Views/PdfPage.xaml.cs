namespace MigrationTarget.Views;

public partial class PdfPage : ContentPage
{
	public PdfPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await SetPdfDocumentStreamAsync("https://www.syncfusion.com/downloads/support/directtrac/general/pd/PDF_Succinctly1928776572");
    }

    private async Task SetPdfDocumentStreamAsync(string URL)
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(URL);

        PdfViewer.DocumentSource = await response.Content.ReadAsStreamAsync();
    }
}