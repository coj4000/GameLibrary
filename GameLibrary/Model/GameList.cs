using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Model
{
    class GameList : ObservableCollection<Game>
    {
        public GameList() : base()
        {
            this.Add(new Game() {title = "Counter Strike", price = 85.0, date = new DateTime(2012,8,21), comment = "Fast pased game 'competetive' 3/5"});
            this.Add(new Game() {title = "The Witcher 3", price = 189.0, date = new DateTime(2015,5,19), comment = "Fun moster hunting RPG 5/5"});
            this.Add(new Game() {title = "Fallout 4", price = 349.0, date = new DateTime(2015,11,10), comment = "Open world post apocalyptic RPG 4.5/5"});
        }
    }
}
