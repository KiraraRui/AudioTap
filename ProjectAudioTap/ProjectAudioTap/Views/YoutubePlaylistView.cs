using ProjectAudioTap.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectAudioTap.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YoutubePlaylistView : ContentPage
    {
        public YoutubePlaylistView()
        {
            Title = "Youtube";
            BackgroundColor = Color.White;

            var youtubeViewModel = new PlaylistView();

            BindingContext = youtubeViewModel;

            var label = new Label
            {
                Text = "Youtube",
                TextColor = Color.Gray,
                FontSize = 24
            };

            var dataTemplate = new DataTemplate(() =>
            {

                var channelTitleLabel = new Label
                {
                    TextColor = Color.Maroon,
                    FontSize = 22
                };
                var titleLabel = new Label
                {
                    TextColor = Color.Black,
                    FontSize = 16
                };
               
                var mediaImage = new Image
                {
                    HeightRequest = 200
                };

                channelTitleLabel.SetBinding(Label.TextProperty, new Binding("ChannelTitle"));
                titleLabel.SetBinding(Label.TextProperty, new Binding("Title"));
                mediaImage.SetBinding(Image.SourceProperty, new Binding("HighThumbnailUrl"));
               
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        Padding = new Thickness(5, 10),
                        Children =
                        {
                            channelTitleLabel,
                            titleLabel,
                            mediaImage,
                        }
                    }
                };
            });

            var listView = new ListView
            {
                HasUnevenRows = true
            };

            listView.SetBinding(ListView.ItemsSourceProperty, "YoutubeItems");

            listView.ItemTemplate = dataTemplate;

            listView.ItemTapped += ListViewOnItemTapped;

            Content = new StackLayout
            {
                Padding = new Thickness(5, 10),
                Children =
                {
                    label,
                    listView
                }
            };
        }

        private void ListViewOnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            var youtubeItem = itemTappedEventArgs.Item as YoutubePlaylist;

        }
    }
}