using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App02.Master;
using App02.Pages;
using App02.Classes;

namespace App02.Master
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : MasterDetailPage //alterar pra master
	{
        public List<MenuDAL> menuList { get; set; }
        public Menu()
        {
            InitializeComponent();
            menuList = new List<MenuDAL>();
            // incluindo items de menu e definindo : title ,page and icon
            menuList.Add(new MenuDAL()
            {
                Title = "Pagina Inicial",
                Icon = "home.png",
                TargetType = typeof(Perfil1)
            });
            menuList.Add(new MenuDAL()
            {
                Title = "Catalogo",
                Icon = "settings.png",
                TargetType =typeof(Catalogo)
            });
            menuList.Add(new MenuDAL()
            {
                Title = "Ajuda",
                Icon = "help.png",
                TargetType =
typeof(Login)
            });
            menuList.Add(new MenuDAL()
            {
                Title = "Rota",
                Icon = "logout.png",
                TargetType =
typeof(Rotas)
            });

            // Configurando o ItemSource fpara o ListView na MainPage.xaml
            paginaMestreList.ItemsSource = menuList;
            // navegação inicial
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Perfil1)));
        }
        // Evento para a seleção de item no menu
        // trata a seleção do usuário no ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MenuDAL)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}