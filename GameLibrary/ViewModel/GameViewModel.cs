using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using GameLibrary.Model;
using Newtonsoft.Json;

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

        //public string GetGameListJson()
        //{
        //    string jsonText = JsonConvert.SerializeObject(GameListe);
        //    return jsonText;
        //}

        private readonly string filnavn = "JsonText.json";

        public GameViewModel()
        {
            GameListe = new Model.GameList();
            //AddGameCommand = new RelayCommand(AddNewGame, null);
            AddGameCommand = new AddGameCommand(AddNewGame);
            NewGame = new Model.Game();
            DeleteGameCommand = new DeleteGameCommand(DeleteGame);
            SaveGameCommand = new SaveGameCommand(GemDataTilDiskAsync);
            HentDataCommand = new HentDataCommand(HentDataFraDiskAsync);



            localFolder = ApplicationData.Current.LocalFolder;
        }

        public async void HentDataFraDiskAsync()
        {
            try
            {
                StorageFile file = await localFolder.GetFileAsync(filnavn);
                string jsonText = await FileIO.ReadTextAsync(file);
                this.GameListe.Clear();
                GameListe.indsætJson(jsonText);
            }
            catch (Exception)
            {

               MessageDialog messageDialog = new MessageDialog("Ændret filnavn eller der er ikke gemt");
                await messageDialog.ShowAsync();
            }
           

            
        }

        public async void GemDataTilDiskAsync()
        {
            string jsonText = this.GameListe.GetJson();
            StorageFile file = await localFolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }
        public AddGameCommand AddGameCommand {get; set;}
        public DeleteGameCommand DeleteGameCommand { get; set; }
        public Model.Game NewGame { get; set; }
        public SaveGameCommand SaveGameCommand { get; set; }
        public HentDataCommand HentDataCommand { get; set; }

        private StorageFolder localFolder = null;
       
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
