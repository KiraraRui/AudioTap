using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAudioTap.Classes
{
    class YoutubePlaylist
    {
            public string VideoId { get; set; }

            public string Title { get; set; }

            public string DefaultThumbnailUrl { get; set; }

            public string MediumThumbnailUrl { get; set; }

            public string HighThumbnailUrl { get; set; }

            public string StandardThumbnailUrl { get; set; }

            public string MaxResThumbnailUrl { get; set; }

            public DateTime PublishedAt { get; set; }

            public int? ViewCount { get; set; }

    }
}
