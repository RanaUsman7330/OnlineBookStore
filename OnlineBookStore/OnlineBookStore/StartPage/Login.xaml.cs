using OnlineBookStore.StartPage.Gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineBookStore.StartPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (txtName.Text == null || txtPass.Text == null)
            {
                await DisplayAlert("Error", "Please Fill the empty Field.", "Ok");
                return;
            }

            await Navigation.PushAsync(new MainGallery());

        }
    }
}