using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectAudioTap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
            public LoginView()
            {
                InitializeComponent();
            }
            private async void NavigateButton_OnClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
    }  