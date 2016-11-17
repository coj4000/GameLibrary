using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Documents;

namespace GameLibrary.Model
{
    class Game
    {
        public string title { get; set; }

        public DateTime date { get; set; }
        public double price { get; set; }
        public string comment { get; set; }

        public override string ToString()
        {
            return title + ", spillet er udgivet " + date + " og det koster " + price + "kr. kommentar: " + comment;

        }
    }
}
