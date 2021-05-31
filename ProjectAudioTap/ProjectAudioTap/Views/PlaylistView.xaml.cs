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
    public partial class PlaylistView : ContentPage
    {
        public PlaylistView()
        {
            InitializeComponent();
        }

        //private async void NavigateButton_ToSpin(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new SpinView());
        //}
    }
}