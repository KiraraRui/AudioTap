using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProjectAudioTap.Views;
using ProjectAudioTap.Classes;
using Xamarin.Essentials;


namespace ProjectAudioTap
{
    public partial class MainPage : ContentPage
    {



        public MainPage()
        {
            InitializeComponent();

        }
        private async void LoginClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuideView());
        }
    }
}