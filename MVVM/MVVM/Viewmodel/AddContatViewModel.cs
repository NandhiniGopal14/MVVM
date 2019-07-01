using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.Viewmodel
{
    class AddContatViewModel : INotifyPropertyChanged
    {
        public AddContatViewModel()
        {
            LaunchWebsiteCommand = new Command(LaunchWebsite);
            SaveContactcommand = new Command(async () => await SaveContact());
        }

        string name = "Nandini";

        string website = "google.com";

        bool bestFriend;

        bool isBusy = false;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }



        public bool BestFriend
        {
            get { return bestFriend; }
            set
            {
                bestFriend = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                IsBusy = name == "nandhinigopal" ? true : false;
               // OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));

            }
        }
        public string WebSite
        {
            get { return website; }
            set
            {
                website = value;
                OnPropertyChanged();
            }

        }
        public string DisplayMessage
        {
            get
            {
                return $"Your new friend is named {Name} and " +
                  $"{(bestFriend ? "is" : "is not")} your best friend.";
            }
        }

        public bool IsBusy
        {
            get
            { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }

        }

        public Command LaunchWebsiteCommand { get; }
        public Command SaveContactcommand { get; }

        void LaunchWebsite()

        {
            try
            {
                Device.OpenUri(new Uri(website));
            }
            catch (Exception ex)
            {

            }
        }

        async Task SaveContact()
        {
            this.PropertyChanged += propertychanging;
            IsBusy = true;
            await Task.Delay(4000);
            IsBusy = false;
            await Application.Current.MainPage.DisplayAlert("Save", "Contact has been saved", "OK");

        }
        private void propertychanging(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName=="Name")
            {

            }
        }
    }
}
