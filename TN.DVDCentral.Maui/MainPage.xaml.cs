using BDF.Utility;
using TN.DVDCentral.BL.Models;

namespace TN.DVDCentral.Maui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            ApiClient apiClient = new ApiClient("wv4sxn03-7051.use.devtunnels.ms/swagger");
            List<Movie> movies = apiClient.GetList<Movie>("Movie");
            CounterBtn.Text = movies.Count + " Movies";
        }
    }

}
