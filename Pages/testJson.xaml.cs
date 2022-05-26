using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIKitTutorials.vk;
using System.Collections;
using System.Collections.ObjectModel;
using UIKitTutorials.Model;
using xNet;
using Leaf.xNet.Services;
using Leaf.xNet;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Enums.Filters;

namespace UIKitTutorials.Pages
{
    /// <summary>
    /// Логика взаимодействия для test.xaml
    /// </summary>
    public partial class test : Page
    {
        
        String token = APIKEY.USER_TOKEN;
        public test()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VkApi api = new VkApi();
            api.Authorize(new ApiAuthParams()
            {
                AccessToken = APIKEY.USER_TOKEN,
                ApplicationId = 8165811,
                Settings = Settings.All
            });


            api.Messages.Send(new MessagesSendParams()
            {
                UserId = 688844772,
                PeerId = 688844772,
                Message = "Test",
                RandomId = new Random().Next()
            });
        }
    }
}
