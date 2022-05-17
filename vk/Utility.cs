using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Text.Json;

namespace UIKitTutorials.vk
{
    public class Responce<T>
    {
        public String rawContent { get; set; }
        public T responce { get; set; }

    }
    public class ResponceUser<T>
    {
        public String Content { get; set; }
        public T responceUser { get; set; }

    }
    public class Utility
    {
        private static HttpClient client = new HttpClient();

        public static Task<HttpResponseMessage> VKGet(String method, Dictionary<String, String> param)
        {
            var builder = new UriBuilder($"https://api.vk.com/method/{method}");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["access_token"] = APIKEY.ACCES_TOKEN;
            query["v"] = APIKEY.Version;
            foreach (var key in param.Keys)
            {
                query[key] = param[key];
            }
            builder.Query = query.ToString();
            String url = builder.ToString();
            return client.GetAsync(url);

        }
        public static string PrettyJson(string unPrettyJson)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJson);
            return JsonSerializer.Serialize(jsonElement, options);
        }
        public static async Task<Responce<VKDictResponce<VKItemsResponse<VKGroupMember>>>> FetchMembersInfo(String groupId, string count)
        {
            HttpResponseMessage response = await VKGet("groups.getMembers", new Dictionary<string, string>
            {
                ["group_id"] = groupId,
                ["fields"] = "title , exports",
                ["count"] = count,
                ["lang"] = "ru"
                //bdate - дата рождения
                //last_seen - ласт посещение
                //can_write_private_message - закрытое лс
                //domain - ник
                //online - сидит ли сейчас online_mobile
                //sex - пол, да был)
                //personal - жизненая позиция 
                //photo_100
                // 
            });

            var content = await response.Content.ReadAsStringAsync();
            var itemsResponce = JsonSerializer.Deserialize<VKDictResponce<VKItemsResponse<VKGroupMember>>>(content);
            return new Responce<VKDictResponce<VKItemsResponse<VKGroupMember>>>
            {
                responce = itemsResponce,
                rawContent = content
            };
        }

        public static async Task<ResponceUser<VKUserResponce<VKGroupMember>>> FetchUserInfo(String userId)
        {
            HttpResponseMessage response = await VKGet("users.get", new Dictionary<string, string>
            {
                ["user_id"] = userId,
                ["fields"] = "lists , "
                //is_no_index Индексируется ли профиль поисковыми сайтами
                //followers_count подписчиков
                //counters - Количество различных объектов у пользователя
                //can_be_invited_group , 
                //has_photo
                //wall_default
            });

            var content = await response.Content.ReadAsStringAsync();
            var itemsResponce = JsonSerializer.Deserialize<ResponceUser<VKUserResponce<VKGroupMember>>>(content);
            return new ResponceUser<VKUserResponce<VKGroupMember>>
            {

                Content = content
            };

        }
    }
}
