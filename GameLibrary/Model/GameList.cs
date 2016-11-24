using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace GameLibrary.Model
{
    class GameList : ObservableCollection<Game>
    {
        public GameList() : base()
        {
            this.Add(new Game() {title = "Counter Strike", price = 85.0, date = "21/08-2012", comment = "Fast pased game 'competetive' 3/5"});
            this.Add(new Game() {title = "The Witcher 3", price = 189.0, date = "19/05-2015", comment = "Fun moster hunting RPG 5/5"});
            this.Add(new Game() {title = "Fallout 4", price = 349.0, date = "10/11-2015", comment = "Open world post apocalyptic RPG 4.5/5"});
        }

        /// <summary>
        /// Giver dig jsonformat for GameList object
        /// </summary>
        /// <returns></returns>
        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }
    }
}
