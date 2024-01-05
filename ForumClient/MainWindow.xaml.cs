using ForumClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ForumClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window , IGobangServiceCallback
    {

        private GobangServiceClient client;  //客户端实例
        public MainWindow()
        {
            InitializeComponent();
        }

        public void LoginCallBack(bool status, string message)
        {
            if (status)
            {
                MessageBox.Show(message);
                LoginButton.Content = "登出";
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginButton.Content.ToString() == "登录")
            {
                string UserName = UsernameText.Text;
                string Password = PasswordText.Text;
                InstanceContext context = new InstanceContext(this);
                client = new GobangServiceClient(context);

                client.Login(UserName, Password);
            }
        }
    }
}
