using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjectAudioTap.Classes;
using ProjectAudioTap.Views;
using ProjectAudioTap.Managers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectAudioTap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpinView : ContentPage
    {
        Button spinButton;
        Label playlistWinnerLabel;
        Task wheelSpinTask;
        CancellationTokenSource tokenSource;
        CancellationToken ct;


        //new Task(async() => await Button_wheelSpin());
        public SpinView()
        {

            InitializeComponent();
            wheelSpin.Source = ImageResourceExtension.GetImageSource("ProjectAudioTap.Assets.wheel.png");
            SpinChooser.Source = ImageResourceExtension.GetImageSource("ProjectAudioTap.Assets.chooser.png");
            tokenSource = new CancellationTokenSource();
            ct = tokenSource.Token;
           // wheelSpinTask = new Task(Button_wheelSpin, tokenSource.Token); // .ContinueWith( wheelSpinTask => { if (!wheelSpinTask.IsCanceled && wheelSpinTask.IsFaulted) { } });
            playlistWinnerLabel = this.FindByName<Label>("playlistWinner");
            spinButton = this.FindByName<Button>("mfSpinButton");

        }

        private async void SpinWheel()
        {
            var buttonSpinStuff = (ImageButton)wheelSpin;

            while (!ct.IsCancellationRequested)
            {

                //for (int i = 1; i < 9; i++)
                //{
                   // if (buttonSpinStuff.Rotation >= 360f) buttonSpinStuff.Rotation = 0;
                    await buttonSpinStuff.RotateTo( (360 * 2), 2000, Easing.SinInOut);
                //}

            }

        }


        //start and stop
        private void Button_StartSpin(object sender, EventArgs e)
        {
                SpinHandlerAsync();
          
        }



        private async void Button_ToPlaylist(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlaylistView());
        }



        private async void Button_ToGuide(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuideView1());
        }



        private async void WheelSpinChooser()
        {
            var buttonSpinStuff = (ImageButton)SpinChooser;

        }



        private async Task SpinHandlerAsync()
        {
            ToggleSpinButton();
            Task.Run(() => SpinWheel(), ct);
            await Task.Run(() => Task.Delay(4500));

            string selectedPlaylistTitle = SelectRandomPlaylist();
            UpdateLabel(selectedPlaylistTitle);

            ToggleSpinButton();
            tokenSource.Cancel();
        }



        private void UpdateLabel(string selectedPlaylistTitle)
        {
            playlistWinnerLabel.Text = selectedPlaylistTitle;
        }



        private string SelectRandomPlaylist()
        {
            return "Winner-name";
        }



        private void ToggleSpinButton()
        {
            spinButton.IsEnabled = !spinButton.IsEnabled;

        }
    }
}





