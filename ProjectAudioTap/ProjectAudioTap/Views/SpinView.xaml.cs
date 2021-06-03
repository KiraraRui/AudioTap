using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjectAudioTap.Classes;
using ProjectAudioTap.Managers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectAudioTap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpinView : ContentPage
    {
        Task wheelSpinTask;
        CancellationTokenSource tokenSource;
        CancellationToken ct;

        //new Task(async() => await Button_wheelSpin());
        public SpinView()
        {
            InitializeComponent();

            wheelSpin.Source = ImageResourceExtension.GetImageSource("ProjectAudioTap.Assets.wheel.png");
            tokenSource = new CancellationTokenSource();
            ct = tokenSource.Token;
            wheelSpinTask = new Task(Button_wheelSpin, tokenSource.Token); // .ContinueWith( wheelSpinTask => { if (!wheelSpinTask.IsCanceled && wheelSpinTask.IsFaulted) { } });

        }

        private async void Button_wheelSpin()
        {
            var buttonSpinStuff = (ImageButton)wheelSpin;

            // if already stopped before started we are telling it to do NOTHING here just the way we like it ah ha ah ha

                // Poll on this property if you have to do
                // other cleanup before throwing.
                if (ct.IsCancellationRequested)
                {
                // Clean up here, then...
                ct.ThrowIfCancellationRequested();
                }

                // run that bitch
            while (true)
            {

                for (int i = 1; i < 7; i++)
                {

                        if (ct.IsCancellationRequested)
                        {
                            ct.ThrowIfCancellationRequested();
                        }

                        //ITS ALIVE......ITS Alliiiveeeee #IT-SPINS
                   if (buttonSpinStuff.Rotation >= 360f) buttonSpinStuff.Rotation = 0;
                    await buttonSpinStuff.RotateTo(i * (360 / 6), 1000, Easing.Linear);

                }
            }
        }

      
         //start and stop
        private async void Button_StartSpin(object sender, EventArgs e)
        {
            if (wheelSpinTask.Status == TaskStatus.Created)
            {

            //Button_wheelSpin();
            wheelSpinTask.Start();

            }


            //(wheelSpinTask.Status == TaskStatus.Running)
            else
            {

                // Just continue on this thread, or await with try-catch:
                try
                {
                   tokenSource.Cancel();
                    await wheelSpinTask;
                }
                catch (OperationCanceledException)
                {
                   
                }
                finally
                {
                    tokenSource.Dispose();
                }

            }

        }

        private async void Button_ToPlaylist(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlaylistView());
        }

    }
}





