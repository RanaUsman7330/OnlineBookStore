using OnlineBookStore.StartPage.DB_Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineBookStore.StartPage.ADMIN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersList : ContentPage
    {
        UserData item = new UserData();

        public UsersList()
        {
            InitializeComponent();
            var db = new SQLiteConnection(App.dbPath);
            DataList.ItemsSource = db.Table<UserData>().ToList();
        }
        private async void MenuItem_ClickedView(object sender, EventArgs e)
        {
            MenuItem menu = sender as MenuItem;
            var item = menu.CommandParameter as UserData;
            await DisplayAlert("Details",
                "Name : " + item.Name + "\n" +
                "Email : " + item.Email + "\n" +
                "Password : " + item.Password + "\n" +
                "Phone : " + item.Phone + "\n"

                , "OK");
        }




        private void MenuItem_ClickedEdit(object sender, EventArgs e)
        {
            MenuItem menu = sender as MenuItem;
            item = menu.CommandParameter as UserData;
            txtEmail.IsVisible = true;
            txtName.IsVisible = true;
            txtPass.IsVisible = true;
            txtPhone.IsVisible = true;
            txtEmail.IsVisible = true;

            BtnUpdate.IsVisible = true;

            txtEmail.Text = item.Email;
            txtName.Text = item.Name;
            txtPass.Text = item.Password;
            txtPhone.Text = item.Phone;




        }
        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            item.Email = txtEmail.Text;
            item.Password = txtPass.Text;
            item.Name = txtName.Text;
            item.Phone = txtPhone.Text;

            txtEmail.IsVisible = false;
            txtName.IsVisible = false;
            txtPass.IsVisible = false;
            txtPhone.IsVisible = false;
            txtEmail.IsVisible = false;

            BtnUpdate.IsVisible = false;

            var db = new SQLiteConnection(App.dbPath);
            db.Update(item);

            DataList.ItemsSource = db.Table<UserData>().ToList();


            await DisplayAlert("Update", "Data Updated", "OK");


        }



        private async void MenuItem_ClickedDelete(object sender, EventArgs e)
        {
            MenuItem menu = sender as MenuItem;
            var item = menu.CommandParameter as UserData;
            var q = await DisplayAlert("Caution", "Are You sure you want to delete this Entry" + item.Name + "?", "Yes", "No");
            if (q)
            {
                var db = new SQLiteConnection(App.dbPath);
                db.Delete(item);


                DataList.ItemsSource = db.Table<UserData>().ToList();
                await DisplayAlert("Message", item.Email + "Entry Delete Successfully", "OK");
            }

        }


    }
}