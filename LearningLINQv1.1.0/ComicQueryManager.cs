using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Imaging;

namespace LearningLINQv1._1._0
{
    class ComicQueryManager
    {
        public ObservableCollection<ComicQuery> AvaiableQueries { get; private set; }
        public ObservableCollection<object> CurrentQueryResults { get; private set; }

        public string Title { get; set; }

        public ComicQueryManager()
        {
            UpdateAvaiableQueries();
            CurrentQueryResults = new ObservableCollection<object>();
        }

        public void UpdateAvaiableQueries()
        {
            AvaiableQueries = new ObservableCollection<ComicQuery>
            {
                new ComicQuery("LINQ ułatwia zapytania", "Proste zapytanie",
                    "Pokażmy Jankowi jak elastyczna jest technologia LINQ",
                    CreateImageFromAssets("purple_250x250.jpg")),

                new ComicQuery("Drogie komiksy", "Komiksy powyżej 500zł,",
                    "Komiksy o wartości przekraczającej 500 zł." +
                    "Janek, może użyć tych danych do wybrania najbardziej" + "pożądanych komiksów.",
                    CreateImageFromAssets("captain_amaizing_250x250.jpg")),

            };
        }

        private static BitmapImage CreateImageFromAssets(string imageFilename)
        {
            return new BitmapImage(new Uri("ms-appx:///Assets/" + imageFilename));
        }

        public void UpdateQueryResults(ComicQuery query)
        {
            Title = query.Title;
            switch (query.Title)
            {
                case "LINQ ułatwia zapytania": LinqMakesQueriesEasy();
                    break;
                case "Drogie komiksy": ExpensiveComics();
                    break;
            }
        }
        public static IEnumerable<Comic> BuildCatalog() //static method which create our Catalog
        {
            return new List<Comic>
            {
                new Comic() {Name = "Johny Amercia vs. the Pinko", Issue = 6},
                new Comic() {Name = "Rock and Roll(edycja limitowana)", Issue = 19},
                new Comic() {Name = "Woman's Work", Issue = 36},
                new Comic() {Name = "Hippie Madness(źle wydrukowany)", Issue = 57},
                new Comic() {Name = "Revenge of the New Wave Freak (uszkodzony)", Issue = 68},
                new Comic() {Name = "Black Monday", Issue = 74},
                new Comic() {Name = "Tribal Tattoo Madness", Issue = 83},
                new Comic() {Name = "The Death of an Object", Issue = 97}
            };
        }

        public static Dictionary<int, decimal> GetPrices() // connecting issues number and price
        {
            return new Dictionary<int, decimal>
            {
                {6, 3600M},
                {19, 500M},
                {36, 650M},
                {57, 13525M},
                {68, 250M},
                {74, 75M},
                {83, 25.75M},
                {97, 35.25M},
            };
        }

        private void LinqMakesQueriesEasy()
        {
            int[] values = new int[] {0, 12, 44, 36, 92, 54, 13, 8};
            var result = from v in values
                where v < 37
                orderby v
                select v;

            foreach (int i in result)
            {
                CurrentQueryResults.Add(
                    new
                    {
                        Title = i.ToString(),
                        Image = CreateImageFromAssets("purple_250x250.jpg"),
                    }
                    );
            }
        }
    }
}
