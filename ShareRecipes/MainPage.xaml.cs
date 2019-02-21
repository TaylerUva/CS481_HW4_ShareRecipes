using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareRecipes {
    public partial class MainPage : ContentPage {


        ObservableCollection<Pokemon> pokedex = new ObservableCollection<Pokemon>();

        public MainPage() {
            InitializeComponent();
            PopulatePokedex();
        }

        // Type
        const string TYPE_FIRE = "#FA7C00";
        const string TYPE_GRASS = "#32CD32";
        const string TYPE_WATER = "#6890F0";
        const string TYPE_BUG = "#A8B820";

        // Locations
        const string ELV = "Evolving";
        const string LAB = "Oak's Lab";

        int amountCaught = -1;
        int dexEntry = 1;

        private string getIcon(string name) {
            return "https://img.pokemondb.net/sprites/sun-moon/icon/" + name.ToLower() + ".png";
        }

        private void PopulatePokedex() {

            amountCaught = -1;
            dexEntry = 1;

            addPokemon("Bulbasaur", dexEntry++, LAB, TYPE_GRASS);
            addPokemon("Ivysaur", dexEntry++, ELV, TYPE_GRASS);
            addPokemon("Venusaur", dexEntry++, ELV, TYPE_GRASS);

            addPokemon("Charmander", dexEntry++, LAB, TYPE_FIRE);
            addPokemon("Charmeleon", dexEntry++, ELV, TYPE_FIRE);
            addPokemon("Charizard", dexEntry++, ELV, TYPE_FIRE);

            addPokemon("Squirtle", dexEntry++, LAB, TYPE_WATER);
            addPokemon("Wartortle", dexEntry++, ELV, TYPE_WATER);
            addPokemon("Blastoise", dexEntry++, ELV, TYPE_WATER);

            addPokemon("Caterpie", dexEntry++, "Route 2, Viridian Forest", TYPE_BUG);
            addPokemon("Metapod", dexEntry++, "Viridian Forest", TYPE_BUG);
            addPokemon("Butterfree", dexEntry++, "Viridian Forest", TYPE_BUG);

            updateCaughtText();

            ToCatchList.ItemsSource = pokedex;
        }

        void addPokemon(string name, int dexNum, string obtained, string type) {
            Pokemon newMon = new Pokemon {
                Name = name,
                DexNum = dexNum.ToString("D3"),
                Obtained = obtained,
                Sprite = getIcon(name),
                Type = type
            };
            pokedex.Add(newMon);
        }

        void updateCaughtText() {
            Caught.Text = "Caught: " + ++amountCaught + " of " + (dexEntry - 1);
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e) {
            var tapped = sender as ListView;
            var tappedPokemon = tapped.SelectedItem as Pokemon;
            pokedex.Remove(tappedPokemon);
            updateCaughtText();
        }

        void Handle_Refreshing(object sender, System.EventArgs e) {
            pokedex.Clear();
            PopulatePokedex();

            // Remember you have to set IsRefreshing False
            ToCatchList.IsRefreshing = false;
        }
    }
}
