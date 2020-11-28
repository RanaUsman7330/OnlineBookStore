using OnlineBookStore.StartPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnlineBookStore
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());

        }

        [Obsolete]
        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
            switch (action)
            {
                case "Email":
                    Device.OpenUri(new Uri("https://www.google.com/gmail/"));
                    break;
                case "Twitter":
                    Device.OpenUri(new Uri("https://twitter.com/login"));
                    break;
                case "Facebook":
                    Device.OpenUri(new Uri("https://www.facebook.com/login/"));
                    break;
                default:
                    break;
            }
        }
    }
}
