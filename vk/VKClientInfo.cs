using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIKitTutorials.vk
{
    public class VKClientInfo
    {
        public class Counters
        {
            public int albums { get; set; }
            public int audios { get; set; }
            public int friends { get; set; }
            public int gifts { get; set; }
            public int groups { get; set; }
            public int online_friends { get; set; }
            public int pages { get; set; }
            public int photos { get; set; }
            public int subscriptions { get; set; }
            public int user_photos { get; set; }
            public int videos { get; set; }
            public int new_photo_tags { get; set; }
            public int new_recognition_tags { get; set; }
            public int posts { get; set; }
            public int clips_followers { get; set; }
           
        }

        public class Response
        {
            public int id { get; set; }
            public Counters counters { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public bool can_access_closed { get; set; }
            public bool is_closed { get; set; }
            public string photo_50 { get; set; }
            public string photo_100 { get; set; }
        }

        public class Root
        {
            public List<Response> response { get; set; }
        }
    }
}
