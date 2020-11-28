using OnlineBookStore.StartPage.DB_Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineBookStore.StartPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (txtEmail.Text == null || txtPass.Text == null || txtRePass.Text == null || txtName.Text == null || txtPhone.Text == null)
            {
                await DisplayAlert("Caution", "Oye fill karo fta fat", "OK");
                return;

            }
            if (txtPass.Text != txtRePass.Text)
            {
                await DisplayAlert("Caution", "Passwords same likho", "OK");
                return;



            }
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Universe.db3");

            var db = new SQLiteConnection(dbPath);

            db.CreateTable<UserData>();

            UserData u = new UserData()
            {
                Email = txtEmail.Text,
                Name = txtName.Text,
                Password = txtPass.Text,
                Phone = txtPhone.Text,
            };

            db.Insert(u);

            var selection = await DisplayAlert("Polices", "Do you Agree with our Polices", "Agree", "Disagree");
            if(selection)
            {
                await DisplayAlert("Done", "Your Data is Inserted", "OK");
            }
            else         
            {
                await DisplayAlert("Caution", "Sorry you don't Create Account", "OK");
                return;

            }


            await Navigation.PushAsync(new Login());

        }
    }
}