using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIKitTutorials.Model
{
    public class Users
    {
        public class User
        {
            public int id { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public bool can_access_closed { get; set; }
            public bool is_closed { get; set; }
            public string photo_100 { get; set; }
            public string owner_id { get; set; }
            public string domain { get; set; }
            public string sex { get; set; }
            public string title { get; set; }
            public string online { get; set; } 

            public override string ToString()
            {
                return $"{first_name} {last_name} {id} {photo_100} {sex} {domain} {online} {is_closed} {id}";
            }
        }
        public class Response
        {
            public int count { get; set; }
            public List<User> items { get; set; }
        }

        public class Root
        {
            public Response response { get; set; }
        }
        public class Items
        {
            public List<User> users { get; set; }
        }
    }
}
