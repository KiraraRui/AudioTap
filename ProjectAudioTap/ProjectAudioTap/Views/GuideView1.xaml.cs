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
    public partial class GuideView1 : ContentPage
    {
        public GuideView1()
        {
            InitializeComponent();
        }

        private async void Button_ToNext(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuideView2());
        }

        private async void Button_ToSkip(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SpinView());
        }
    }
}