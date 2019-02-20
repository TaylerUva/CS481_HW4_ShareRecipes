using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareRecipes {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            PopulateListView();
        }

        private void PopulateListView() {
            var pokedex = new ObservableCollection<Pokemon>();

            var dex001 = new Pokemon {
                Name = "Bulbasuar",
                DexNum = "001",
                RoutesSeen = "None"
            };
            pokedex.Add(dex001);
            ToCatchList.ItemsSource = pokedex;
        }
    }
}
