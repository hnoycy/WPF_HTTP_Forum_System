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
using System.Windows.Forms;
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
        private bool LoginStatus = false;
        private string LoginName = "";
        private int LoginID = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        // 获得所有帖子的回调
        public void GetAllPostsCallBack(Post[] postsList)
        {
            postStackPanel.Children.Clear();

            // 动态创建帖子显示控件并添加到 StackPanel 中
            foreach (var post in postsList)
            {
                var postControl = new PostControl(post);
                postStackPanel.Children.Add(postControl);
            }
        }

        public void LoginCallBack(bool status, string message, int userID)
        {
            if (status)
            {
                LoginName = UsernameText.Text;
                System.Windows.MessageBox.Show(message);
                LoginStatus = true;
                LoginButton.Content = "登出";

                LoginID = userID;
                // 登录后获得所有帖子
                client.GetAllPosts(LoginID);
            }
            else
            {
                System.Windows.MessageBox.Show(message);
            }
        }

        // 刷新帖子列表
        public void RefreshPostList()
        {
            if(LoginStatus)
            {
                client.GetAllPosts(LoginID);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginStatus == false)
            {
                // 登录
                string UserName = UsernameText.Text;
                string Password = PasswordText.Text;
                InstanceContext context = new InstanceContext(this);
                client = new GobangServiceClient(context);

                client.Login(UserName, Password);
            }
            else
            {
                // 登出
                client.Logout(LoginName);
                LoginStatus = false;
                LoginButton.Content = "登录";

                // 登出后清空所有帖子
                postStackPanel.Children.Clear();
            }
        }

        private void PublishButton_Click(object sender, RoutedEventArgs e)
        {
            // 发布新的帖子
            if(LoginStatus == false)
            {
                System.Windows.MessageBox.Show("您未登录,请先登录");
            }
            else
            {
                client.CreateNewPost(LoginID, NewPostTitleTextBox.Text.ToString(), NewPostContentTextBox.Text.ToString());
                NewPostTitleTextBox.Text = "输入帖子标题";
                NewPostContentTextBox.Text = "输入帖子内容";
            }
        }

        // 重写 Show 方法
        public new void Show(string userName,string password)
        {
            UsernameText.Text = userName;
            PasswordText.Text = password;
            base.Show();
        }
    }
}
