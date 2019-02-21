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

        enum pkmType {
            NORMAL,
            FIGHTING,
            FLYING,
            POISON,
            GROUND,
            ROCK,
            BUG,
            GHOST,
            STEEL,
            FIRE,
            WATER,
            GRASS,
            ELECTRIC,
            PSYCHIC,
            ICE,
            DRAGON,
            DARK,
            FAIRY
        }

        // Locations
        const string EVOLVE = "Evolving";
        const string LAB = "Oak's Lab";

        int amountCaught = -1;
        int dexEntry = 1;

        private void PopulatePokedex() {

            amountCaught = -1;
            dexEntry = 1;

            addPokemon("Bulbasaur", dexEntry++, LAB, pkmType.GRASS);
            addPokemon("Ivysaur", dexEntry++, EVOLVE, pkmType.GRASS);
            addPokemon("Venusaur", dexEntry++, EVOLVE, pkmType.GRASS);

            addPokemon("Charmander", dexEntry++, LAB, pkmType.FIRE);
            addPokemon("Charmeleon", dexEntry++, EVOLVE, pkmType.FIRE);
            addPokemon("Charizard", dexEntry++, EVOLVE, pkmType.FIRE);

            addPokemon("Squirtle", dexEntry++, LAB, pkmType.WATER);
            addPokemon("Wartortle", dexEntry++, EVOLVE, pkmType.WATER);
            addPokemon("Blastoise", dexEntry++, EVOLVE, pkmType.WATER);

            addPokemon("Caterpie", dexEntry++, "Rt. 2, Viridian Forest", pkmType.BUG);
            addPokemon("Metapod", dexEntry++, "Viridian Forest", pkmType.BUG);
            addPokemon("Butterfree", dexEntry++, "Viridian Forest", pkmType.BUG);

            addPokemon("Weedle", dexEntry++, "Rt. 2, Viridian Forest", pkmType.BUG);
            addPokemon("Kakuna", dexEntry++, "Viridian Forest", pkmType.BUG);
            addPokemon("Beedrill", dexEntry++, "Viridian Forest", pkmType.BUG);

            addPokemon("Pidgey", dexEntry++, "Many", pkmType.FLYING);
            addPokemon("Pidgeotto", dexEntry++, "Many", pkmType.FLYING);
            addPokemon("Pidgeot", dexEntry++, "Many", pkmType.FLYING);

            addPokemon("Rattata", dexEntry++, "Many", pkmType.NORMAL);
            addPokemon("Raticate", dexEntry++, "Many", pkmType.NORMAL);

            addPokemon("Spearow", dexEntry++, "Many", pkmType.FLYING);
            addPokemon("Fearow", dexEntry++, "Many", pkmType.FLYING);

            addPokemon("Ekans", dexEntry++, "Route 3, Route 4", pkmType.POISON);
            addPokemon("Arbok", dexEntry++, EVOLVE, pkmType.POISON);

            addPokemon("Pikachu", dexEntry++, "Viridian Forest", pkmType.ELECTRIC);
            addPokemon("Raichu", dexEntry++, EVOLVE, pkmType.ELECTRIC);

            updateCaughtText();

            ToCatchList.ItemsSource = pokedex;
        }

        void updateCaughtText() {
            Caught.Text = "Caught: " + ++amountCaught + " of " + (dexEntry - 1);
        }

        void addPokemon(string name, int dexNum, string obtained, pkmType type) {
            Pokemon newMon = new Pokemon {
                Name = name,
                DexNum = dexNum.ToString("D3"),
                Obtained = obtained,
                Sprite = getIcon(name),
                Type = getTypeColor(type)
            };
            pokedex.Add(newMon);
        }

        // Get Pokemon Data
        private string getIcon(string name) {
            return "https://img.pokemondb.net/sprites/sun-moon/icon/" + name.ToLower() + ".png";
        }

        private string getTypeColor(pkmType type) {
            switch (type) {
            case pkmType.NORMAL:
                return "#A8A878";
            case pkmType.FIGHTING:
                return "#C03028";
            case pkmType.FLYING:
                return "#A891F0";
            case pkmType.POISON:
                return "#A040A0";
            case pkmType.GROUND:
                return "#E0C068";
            case pkmType.ROCK:
                return "#B8A038";
            case pkmType.BUG:
                return "#A8B820";
            case pkmType.GHOST:
                return "#705898";
            case pkmType.STEEL:
                return "#B8B8D0";
            case pkmType.FIRE:
                return "#FA7C00";
            case pkmType.WATER:
                return "#6890F0";
            case pkmType.GRASS:
                return "#32CD32";
            case pkmType.ELECTRIC:
                return "#FFC631";
            case pkmType.PSYCHIC:
                return "#F85888";
            case pkmType.ICE:
                return "#98D8D8";
            case pkmType.DRAGON:
                return "#7038F8";
            case pkmType.DARK:
                return "#705848";
            case pkmType.FAIRY:
                return "#EE99AC";
            default:
                return "#68A090";
            }
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
