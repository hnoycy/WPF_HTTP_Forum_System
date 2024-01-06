using ForumClient.ServiceReference1;
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

namespace ForumClient
{
    /// <summary>
    /// PostControl.xaml 的交互逻辑
    /// </summary>
    public partial class PostControl : UserControl
    {
        public Post Post { get; set; }

        public PostControl(Post post)
        {
            InitializeComponent();

            this.Post = post;

            InitializePostControl();
        }

        private void InitializePostControl()
        {
            publisherTextBlock.Text = Post.PosterName;
            titleTextBlock.Text = Post.Title;
            contentTextBlock.Text = Post.Content;
            publishTimeTextBlock.Text = "发布时间:" + Post.PostTime.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("该处未完成,显示postID为" + Post.Id);
        }
    }
}
