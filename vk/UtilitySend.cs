using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKitTutorials.Properties;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace UIKitTutorials.vk
{
    public class UtilitySend
    {
        public void SendMessage(string message, string id, string token)
        {

            VkApi api = new VkApi();
            
            api.Authorize(new ApiAuthParams()
            {
                Login = "79303809036",
                Password = "root228toor",
                ApplicationId = 8165811,
                Settings = Settings.All

            });

            api.Messages.Send(new MessagesSendParams()
            {
                UserId = 79303809036,
                PeerId = 688844772,
                Message = "Test",
                RandomId = new Random().Next()
            });




        }


    }
}
