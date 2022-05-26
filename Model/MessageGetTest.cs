using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIKitTutorials.Model
{
    public class MessageGetTest
    {

        public class Ads
        {
            public string content_id { get; set; }
            public string duration { get; set; }
            public string account_age_type { get; set; }
            public string puid1 { get; set; }
            public string puid22 { get; set; }
        }

        public class Album
        {
            public int id { get; set; }
            public string title { get; set; }
            public int owner_id { get; set; }
            public string access_key { get; set; }
            public Thumb thumb { get; set; }
        }

        public class Attachment
        {
            public string type { get; set; }
            public Doc doc { get; set; }
            public Audio audio { get; set; }
            public Photo photo { get; set; }
            public Sticker sticker { get; set; }
            public AudioPlaylist audio_playlist { get; set; }
        }

        public class Audio
        {
            public string artist { get; set; }
            public int id { get; set; }
            public int owner_id { get; set; }
            public string title { get; set; }
            public int duration { get; set; }
            public string access_key { get; set; }
            public Ads ads { get; set; }
            public bool is_explicit { get; set; }
            public bool is_focus_track { get; set; }
            public bool is_licensed { get; set; }
            public string track_code { get; set; }
            public string url { get; set; }
            public int date { get; set; }
            public Album album { get; set; }
            public List<MainArtist> main_artists { get; set; }
            public bool short_videos_allowed { get; set; }
            public bool stories_allowed { get; set; }
            public bool stories_cover_allowed { get; set; }
        }

        public class AudioPlaylist
        {
            public int id { get; set; }
            public int owner_id { get; set; }
            public int type { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public int count { get; set; }
            public int followers { get; set; }
            public int plays { get; set; }
            public int create_time { get; set; }
            public int update_time { get; set; }
            public List<object> genres { get; set; }
            public bool is_following { get; set; }
            public Followed followed { get; set; }
            public Photo photo { get; set; }
            public Permissions permissions { get; set; }
            public bool subtitle_badge { get; set; }
            public bool play_button { get; set; }
            public string access_key { get; set; }
            public string album_type { get; set; }
        }

        public class Doc
        {
            public int id { get; set; }
            public int owner_id { get; set; }
            public string title { get; set; }
            public int size { get; set; }
            public string ext { get; set; }
            public int date { get; set; }
            public int type { get; set; }
            public string url { get; set; }
            public int is_licensed { get; set; }
            public string access_key { get; set; }
        }

        public class Followed
        {
            public int playlist_id { get; set; }
            public int owner_id { get; set; }
        }

        public class Image
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class ImagesWithBackground
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Item
        {
            public int date { get; set; }
            public int from_id { get; set; }
            public int id { get; set; }
            public int @out { get; set; }
            public List<Attachment> attachments { get; set; }
            public int conversation_message_id { get; set; }
            public List<object> fwd_messages { get; set; }
            public bool important { get; set; }
            public bool is_hidden { get; set; }
            public int peer_id { get; set; }
            public int random_id { get; set; }
            public string text { get; set; }
        }

        public class MainArtist
        {
            public string name { get; set; }
            public string domain { get; set; }
            public string id { get; set; }
        }

        public class Permissions
        {
            public bool play { get; set; }
            public bool share { get; set; }
            public bool edit { get; set; }
            public bool follow { get; set; }
            public bool delete { get; set; }
            public bool boom_download { get; set; }
        }

        public class Photo
        {
            public int album_id { get; set; }
            public int date { get; set; }
            public int id { get; set; }
            public int owner_id { get; set; }
            public List<Size> sizes { get; set; }
            public string text { get; set; }
            public bool has_tags { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string photo_34 { get; set; }
            public string photo_68 { get; set; }
            public string photo_135 { get; set; }
            public string photo_270 { get; set; }
            public string photo_300 { get; set; }
            public string photo_600 { get; set; }
            public string photo_1200 { get; set; }
        }

        public class Response
        {
            public int count { get; set; }
            public List<Item> items { get; set; }
        }

        public class Root
        {
            public Response response { get; set; }
        }

        public class Size
        {
            public int height { get; set; }
            public string url { get; set; }
            public string type { get; set; }
            public int width { get; set; }
        }

        public class Sticker
        {
            public int sticker_id { get; set; }
            public int product_id { get; set; }
            public List<Image> images { get; set; }
            public List<ImagesWithBackground> images_with_background { get; set; }
            public bool is_allowed { get; set; }
        }

        public class Thumb
        {
            public int width { get; set; }
            public int height { get; set; }
            public string photo_34 { get; set; }
            public string photo_68 { get; set; }
            public string photo_135 { get; set; }
            public string photo_270 { get; set; }
            public string photo_300 { get; set; }
            public string photo_600 { get; set; }
            public string photo_1200 { get; set; }
        }
    }
}
