using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectAudioTap.Classes;
using ProjectAudioTap.Managers;
using ProjectAudioTap.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectAudioTap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuideView2 : ContentPage
    {
        public GuideView2()
        {
            InitializeComponent();
        }


        private async void Button_ToSpinView(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SpinView());
        }

        private async void Button_ToGuide1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuideView1());
        }
    }
}