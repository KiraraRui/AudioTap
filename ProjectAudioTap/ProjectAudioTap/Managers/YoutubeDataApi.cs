using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectAudioTap.Classes;
using ProjectAudioTap.Managers;
using ProjectAudioTap.Views;


namespace ProjectAudioTap.Managers
{
    class YoutubeDataApi : INotifyPropertyChanged
    {

        // Our api key
        private const string ApiKey = "AIzaSyBGfGsLOD3mXggd7jsEDnPhm4oPOd_dRE8";

        // youtube account id
        private string apiUrlForChannel = "https://www.googleapis.com/youtube/v3/search?part=id&maxResults=20&channelId="
            + "UCkqW8gF-nOtzRXt2H2GbHfw"
            + "&key="
            + ApiKey;

        //1 specific Playlist
        // doc : https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.playlistItems.list
        private string apiUrlForPlaylist = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=20&playlistId="
            + "PLYYYL0glssTs5tsXQaRXCaK-7EFnVq-EC"
            //+ "Your_PlaylistId"
            + "&key="
            + ApiKey;

        //all videos (TODO remove)
        // doc : https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.search.list
        private string apiUrlForVideosDetails = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id="
            + "{0}"
            + "&key="
            + ApiKey;

        private List<YoutubePlaylist> _youtubeItems;

        public List<YoutubePlaylist> YoutubeItems
        {
            get { return _youtubeItems; }
            set
            {
                _youtubeItems = value;
                OnPropertyChanged();
            }
        }

        public YoutubeDataApi()
        {
            InitDataAsync();
        }

        public async Task InitDataAsync()
        {

            var videoIds = await GetVideoIdsFromChannelAsync();
        }

        private async Task<List<string>> GetVideoIdsFromChannelAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(apiUrlForChannel);

            var videoIds = new List<string>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    videoIds.Add(item.Value<JObject>("id")?.Value<string>("videoId"));
                }

                YoutubeItems = await GetVideosDetailsAsync(videoIds);
            }
            catch (Exception ) // e
            {
            }

            return videoIds;
        }

        private async Task<List<string>> GetVideoIdsFromPlaylistAsync()
        {

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(apiUrlForPlaylist);

            var videoIds = new List<string>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    videoIds.Add(item.Value<JObject>("contentDetails")?.Value<string>("videoId"));
                };

                YoutubeItems = await GetVideosDetailsAsync(videoIds);
            }
            catch (Exception ) //e
            {
            }

            return videoIds;
        }

        private async Task<List<YoutubePlaylist>> GetVideosDetailsAsync(List<string> videoIds)
        {

            var videoIdsString = "";
            foreach (var s in videoIds)
            {
                videoIdsString += s + ",";
            }

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(string.Format(apiUrlForVideosDetails, videoIdsString));

            var youtubeItems = new List<YoutubePlaylist>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    var snippet = item.Value<JObject>("snippet");
                    var statistics = item.Value<JObject>("statistics");

                    var youtubeItem = new YoutubePlaylist
                    {
                        Title = snippet.Value<string>("title"),
                        PublishedAt = snippet.Value<DateTime>("publishedAt"),
                        VideoId = item?.Value<string>("id"),
                        DefaultThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("default")?.Value<string>("url"),
                        MediumThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("medium")?.Value<string>("url"),
                        HighThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("high")?.Value<string>("url"),
                        StandardThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("standard")?.Value<string>("url"),
                        MaxResThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("maxres")?.Value<string>("url"),

                    };

                    youtubeItems.Add(youtubeItem);
                }

                return youtubeItems;
            }
            catch (Exception ) //e
            {
                return youtubeItems;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

