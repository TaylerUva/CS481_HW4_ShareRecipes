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

        const string TYPE_FIRE = "#FA7C00";
        const string TYPE_GRASS = "#32CD32";

        private string getIcon(string name) {
            return "https://img.pokemondb.net/sprites/sun-moon/icon/" + name + ".png";
        }

        private void PopulateListView() {
            var pokedex = new ObservableCollection<Pokemon>();

            var dex001 = new Pokemon {
                Name = "Bulbasuar",
                DexNum = "001",
                RoutesSeen = "Oak's Lab",
                Sprite = getIcon("bulbasaur"),
                Type = TYPE_GRASS
            };

            var dex002 = new Pokemon {
                Name = "Ivysaur",
                DexNum = "002",
                RoutesSeen = "Oak's Lab",
                Sprite = getIcon("ivysaur"),
                Type = TYPE_GRASS
            };

            var dex003 = new Pokemon {
                Name = "Venusaur",
                DexNum = "003",
                RoutesSeen = "Oak's Lab",
                Sprite = getIcon("venusaur"),
                Type = TYPE_GRASS
            };

            var dex004 = new Pokemon {
                Name = "Charmander",
                DexNum = "004",
                RoutesSeen = "Oak's Lab",
                Sprite = getIcon("charmander"),
                Type = TYPE_FIRE
            };

            var dex005 = new Pokemon {
                Name = "Charmeleon",
                DexNum = "005",
                RoutesSeen = "Oak's Lab",
                Sprite = getIcon("charmeleon"),
                Type = TYPE_FIRE
            };

            var dex006 = new Pokemon {
                Name = "Charizard",
                DexNum = "006",
                RoutesSeen = "Oak's Lab",
                Sprite = getIcon("charizard"),
                Type = TYPE_FIRE
            };

            pokedex.Add(dex001);
            pokedex.Add(dex002);
            pokedex.Add(dex003);
            pokedex.Add(dex004);
            pokedex.Add(dex005);
            pokedex.Add(dex006);
            ToCatchList.ItemsSource = pokedex;
        }
    }
}
