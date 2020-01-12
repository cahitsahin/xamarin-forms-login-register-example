using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleLoginRegisterApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();


        }
        async void LoginEvent(object sender, EventArgs e)
        {
            var loginUser = new User
            {

                Email = Email.Text,
                Password = Password.Text
            };

            var templateUser = Preferences.Get("email", "");
            Console.WriteLine("it's email " + templateUser);
            var templatePass = Preferences.Get("password", "");
            Console.WriteLine("it's password " + templatePass);

            var isValid = AreCredentialsCorrect(loginUser);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Alert", "Email or Password invalid ", "OK");
            }
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.Email == Preferences.Get("email", "default") && user.Password == Preferences.Get("password", "default");
        }
    }
}