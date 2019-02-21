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

        // Type
        const string TYPE_FIRE = "#FA7C00";
        const string TYPE_GRASS = "#32CD32";
        const string TYPE_WATER = "#6890F0";

        // Locations
        const string ELV = "Evolving";
        const string LAB = "Oak's Lab";

        private string getIcon(string name) {
            return "https://img.pokemondb.net/sprites/sun-moon/icon/" + name + ".png";
        }

        private void PopulateListView() {
            var pokedex = new ObservableCollection<Pokemon>();

            var dex001 = new Pokemon {
                Name = "Bulbasuar",
                DexNum = "001",
                Obtained = LAB,
                Sprite = getIcon("bulbasaur"),
                Type = TYPE_GRASS
            }; pokedex.Add(dex001);

            var dex002 = new Pokemon {
                Name = "Ivysaur",
                DexNum = "002",
                Obtained = ELV,
                Sprite = getIcon("ivysaur"),
                Type = TYPE_GRASS
            }; pokedex.Add(dex002);

            var dex003 = new Pokemon {
                Name = "Venusaur",
                DexNum = "003",
                Obtained = ELV,
                Sprite = getIcon("venusaur"),
                Type = TYPE_GRASS
            }; pokedex.Add(dex003);

            var dex004 = new Pokemon {
                Name = "Charmander",
                DexNum = "004",
                Obtained = LAB,
                Sprite = getIcon("charmander"),
                Type = TYPE_FIRE
            }; pokedex.Add(dex004);

            var dex005 = new Pokemon {
                Name = "Charmeleon",
                DexNum = "005",
                Obtained = ELV,
                Sprite = getIcon("charmeleon"),
                Type = TYPE_FIRE
            }; pokedex.Add(dex005);

            var dex006 = new Pokemon {
                Name = "Charizard",
                DexNum = "006",
                Obtained = ELV,
                Sprite = getIcon("charizard"),
                Type = TYPE_FIRE
            }; pokedex.Add(dex006);


            var dex007 = new Pokemon {
                Name = "Squirtle",
                DexNum = "007",
                Obtained = LAB,
                Sprite = getIcon("squirtle"),
                Type = TYPE_WATER
            }; pokedex.Add(dex007);

            var dex008 = new Pokemon {
                Name = "Wartortle",
                DexNum = "008",
                Obtained = ELV,
                Sprite = getIcon("wartortle"),
                Type = TYPE_WATER
            }; pokedex.Add(dex008);

            var dex009 = new Pokemon {
                Name = "Blastoise",
                DexNum = "009",
                Obtained = ELV,
                Sprite = getIcon("blastoise"),
                Type = TYPE_WATER
            }; pokedex.Add(dex009);

            ToCatchList.ItemsSource = pokedex;
        }
    }
}
