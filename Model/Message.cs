using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIKitTutorials.Model
{
    public class Message
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Acl
        {
            public bool can_change_info { get; set; }
            public bool can_change_invite_link { get; set; }
            public bool can_change_pin { get; set; }
            public bool can_invite { get; set; }
            public bool can_promote_users { get; set; }
            public bool can_see_invite_link { get; set; }
            public bool can_moderate { get; set; }
            public bool can_copy_chat { get; set; }
            public bool can_call { get; set; }
            public bool can_use_mass_mentions { get; set; }
            public bool can_change_style { get; set; }
           
        }

        public class Action
        {
            public string type { get; set; }
            public int member_id { get; set; }
        }

        public class Article
        {
            public string access_key { get; set; }
            public int id { get; set; }
            public bool is_favorite { get; set; }
            public int owner_id { get; set; }
            public string owner_name { get; set; }
            public string owner_photo { get; set; }
            public int published_date { get; set; }
            public string state { get; set; }
            public string subtitle { get; set; }
            public string title { get; set; }
            public string url { get; set; }
            public string view_url { get; set; }
            public int views { get; set; }
            public int shares { get; set; }
            public bool can_report { get; set; }
            public bool no_footer { get; set; }
        }

        public class Attachment
        {
            public string type { get; set; }
            public Article article { get; set; }
            public Photo photo { get; set; }
            public Doc doc { get; set; }
            public Link link { get; set; }
            public Sticker sticker { get; set; }
            public AudioPlaylist audio_playlist { get; set; }
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

        public class CanWrite
        {
            public bool allowed { get; set; }
            public int? reason { get; set; }
        }

        public class ChatSettings
        {
            public string title { get; set; }
            public int members_count { get; set; }
            public int friends_count { get; set; }
            public int owner_id { get; set; }
            public PinnedMessage pinned_message { get; set; }
            public string state { get; set; }
            public Photo photo { get; set; }
            public List<int> active_ids { get; set; }
            public bool is_group_channel { get; set; }
            public Acl acl { get; set; }
            public bool is_disappearing { get; set; }
            public bool is_service { get; set; }
            public List<int> admin_ids { get; set; }
        }

        public class Conversation
        {
            public Peer peer { get; set; }
            public int last_message_id { get; set; }
            public int in_read { get; set; }
            public int out_read { get; set; }
            public SortId sort_id { get; set; }
            public int last_conversation_message_id { get; set; }
            public int in_read_cmid { get; set; }
            public int out_read_cmid { get; set; }
            public int unread_count { get; set; }
            public bool is_marked_unread { get; set; }
            public bool important { get; set; }
            public PushSettings push_settings { get; set; }
            public CanWrite can_write { get; set; }
            public bool can_send_money { get; set; }
            public bool can_receive_money { get; set; }
            public ChatSettings chat_settings { get; set; }
            public bool is_new { get; set; }
            public CurrentKeyboard current_keyboard { get; set; }
            public string style { get; set; }
            public ConversationBar conversation_bar { get; set; }
            public List<int> mentions { get; set; }
            public List<int> mention_cmids { get; set; }
            public List<object> expire_messages { get; set; }
            public List<object> expire_cmids { get; set; }
            

        }

        public class ConversationBar
        {
            public string name { get; set; }
            public string text { get; set; }
            public List<object> buttons { get; set; }
            public string icon { get; set; }
        }

        public class CurrentKeyboard
        {
            public bool one_time { get; set; }
            public int author_id { get; set; }
            public bool inline { get; set; }
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

        public class FwdMessage
        {
            public int date { get; set; }
            public int from_id { get; set; }
            public string text { get; set; }
            public List<Attachment> attachments { get; set; }
            public int conversation_message_id { get; set; }
            public int id { get; set; }
            public int peer_id { get; set; }
            public List<FwdMessage> fwd_messages { get; set; }
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
            public Conversation conversation { get; set; }
            public LastMessage last_message { get; set; }

            public override string ToString()
            {
                return $"{conversation.peer.id} {conversation.peer.type} {conversation.peer.local_id} {last_message.date} {last_message.text} {last_message.attachments}";
            }
        }

        public class LastMessage
        {
            public int date { get; set; }
            public int from_id { get; set; }
            public int id { get; set; }
            public int @out { get; set; }
            public List<Attachment> attachments { get; set; }
            public int conversation_message_id { get; set; }
            public List<FwdMessage> fwd_messages { get; set; }
            public bool important { get; set; }
            public bool is_hidden { get; set; }
            public int peer_id { get; set; }
            public int random_id { get; set; }
            public string text { get; set; }
            public Action action { get; set; }
        }

        public class Link
        {
            public string url { get; set; }
            public string title { get; set; }
            public string caption { get; set; }
            public string description { get; set; }
            public string target { get; set; }
            public bool is_favorite { get; set; }
            public Photo photo { get; set; }
        }

        public class Peer
        {
            public int id { get; set; }
            public string type { get; set; }
            public int local_id { get; set; }
            
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
            public string access_key { get; set; }
            public List<Size> sizes { get; set; }
            public string text { get; set; }
            public bool has_tags { get; set; }
            public string photo_50 { get; set; }
            public string photo_100 { get; set; }
            public string photo_200 { get; set; }
            public bool is_default_photo { get; set; }
            public bool is_default_call_photo { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string photo_34 { get; set; }
            public string photo_68 { get; set; }
            public string photo_135 { get; set; }
            public string photo_270 { get; set; }
            public string photo_300 { get; set; }
            public string photo_600 { get; set; }
            public string photo_1200 { get; set; }
            public int user_id { get; set; }
        }

        public class PinnedMessage
        {
            public int id { get; set; }
            public int date { get; set; }
            public int from_id { get; set; }
            public List<Attachment> attachments { get; set; }
            public int conversation_message_id { get; set; }
            public int peer_id { get; set; }
            public string text { get; set; }
            public List<FwdMessage> fwd_messages { get; set; }
        }

        public class PushSettings
        {
            public bool disabled_forever { get; set; }
            public bool no_sound { get; set; }
            public bool disabled_mentions { get; set; }
            public bool disabled_mass_mentions { get; set; }
        }

        public class Response
        {
            public int count { get; set; }
            public List<Item> items { get; set; }
            public int unread_count { get; set; }
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

        public class SortId
        {
            public int major_id { get; set; }
            public int minor_id { get; set; }
        }

        public class Sticker
        {
            public int sticker_id { get; set; }
            public int product_id { get; set; }
            public List<Image> images { get; set; }
            public List<ImagesWithBackground> images_with_background { get; set; }
            public string animation_url { get; set; }
            public bool is_allowed { get; set; }
        }


    }
}
