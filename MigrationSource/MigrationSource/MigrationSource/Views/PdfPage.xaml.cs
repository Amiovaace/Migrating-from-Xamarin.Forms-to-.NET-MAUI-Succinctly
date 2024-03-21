using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigrationSource.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PdfPage : ContentPage
    {
        public PdfPage()
        {
            InitializeComponent();
        }

        private async Task SetPdfDocumentStreamAsync(string URL)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(URL);

            var doc = await response.Content.ReadAsStreamAsync();
            PdfViewer.LoadDocument(doc);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await SetPdfDocumentStreamAsync("https://www.syncfusion.com/downloads/support/directtrac/general/pd/PDF_Succinctly1928776572");
        }
    }
}