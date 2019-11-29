using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace App02.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Rotas : ContentPage
	{
		public Rotas ()
		{
			InitializeComponent ();
		}
        public async void btn_clicked(object sender, System.EventArgs e)
        {
            try
            {
                var location = new Location(Convert.ToDouble(entryLatitude.Text), 
                    //captura a latitude
                 Convert.ToDouble(entryLongitude.Text));
                //captura a longitude
                var options = new MapLaunchOptions
                {
                    //aqui será coloca a latitude e a lognetude
                    Name = entryNome.Text
                };
                //avre o maps
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                // Não foi possivel acessar o mapa
                await DisplayAlert("Erro : ", ex.Message, "Ok");
            }
        }
    }
}
