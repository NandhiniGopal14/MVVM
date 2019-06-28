using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.Viewmodel
{
    class AddContatViewModel: INotifyPropertyChanged
    {
        public AddContatViewModel()
        {

        }

        string name = "Nandini";

        string website = "google.com";

        bool bestFriend;

        bool isBusy = false;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name="")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
             


        public bool BestFriend
        {
            get { return bestFriend; }
            set { bestFriend = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
           

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
         public string WebSite
        {
            get { return website; }
            set { website = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }

        }
        public string DisplayMessage
        {
            get { return $"Your new friend is named {Name} and " +
                    $"{(bestFriend ? "is" : "is not")} your best friend."; }
        }

        public bool IsBusy
        {
            get
            { return IsBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }

        }

        void LaunchWebsite()

        {
            try
            {
                Device.OpenUri(new Uri(website));
            }
            catch
            {

            }
        }

        async Task SaveContact()
        {
            IsBusy = true;
            await Task.Delay(4000);
            IsBusy = false;
            await Application.Current.MainPage.DisplayAlert("Save", "Contact has been saved", "OK");
     
        }
    }
}
