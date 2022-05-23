using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIKitTutorials.vk
{
    public class VKChatResponce
    {
        public String type { get; set; }
        public String title { get; set; }
        public int admin_id { get; set; }
        public int members_count { get; set; }
        public int id { get; set; }
        public List<int> users { get; set; }
        public PushSettings push_settings { get; set; }
        public String photo_50 { get; set; }
        public String photo_100 { get; set; }
        public String photo_200 { get; set; }
        public bool is_default_photo { get; set; }
        public override string ToString()
        {
            return $"{photo_100} {title} {members_count} {admin_id} {photo_200} {photo_50}";
        }
    }
    public class PushSettings
    {
        public int sound { get; set; }
        public int disabled_until { get; set; }
    }

}
