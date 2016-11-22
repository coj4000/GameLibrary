﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.ViewModel
{
    class GameViewModel : INotifyPropertyChanged
    {
        public Model.GameList GameListe { get; set; }

        private Model.Game selectedGame;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Model.Game SelectedGame
        {
            get { return selectedGame; }
            set
            {
                selectedGame = value; 
                OnPropertyChanged(nameof(SelectedGame));
            }
        }

        public GameViewModel()
        {
            GameListe = new Model.GameList();
            //AddGameCommand = new RelayCommand(AddNewGame, null);
            AddGameCommand = new AddGameCommand(AddNewGame);
            NewGame = new Model.Game();
            DeleteGameCommand = new DeleteGameCommand(DeleteGame);
            

        }

        public AddGameCommand AddGameCommand {get; set;}
        public DeleteGameCommand DeleteGameCommand { get; set; }
        public Model.Game NewGame { get; set; }
            //public RelayCommand AddGameCommand { get; set; }

            public void AddNewGame()
            {
                GameListe.Add(NewGame);
            }

        public void DeleteGame()
        {
            GameListe.Remove(selectedGame);
        }
    }
}
