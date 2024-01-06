using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GobangGameWcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class GobangService : IGobangService
    {
        private MyDBEntities dbEntity = new MyDBEntities();
        public GobangService()
        {
            if (Users.userList == null)
                Users.userList = new List<User>();
        }
        public void Login(string userName, string password)
        {
            OperationContext context = OperationContext.Current;
            IGobangServiceCallback callback = context.GetCallbackChannel<IGobangServiceCallback>();
            User newUser = new User(GetUserID(userName),userName, callback);

            if (CheckPassword(userName, password))
            {
                // 检查重名
                if (LoginCheck(newUser))
                {
                    Users.userList.Add(newUser);
                    newUser.callback.LoginCallBack(true, "登录成功",GetUserID(userName));
                }
            }
            else
            {
                newUser.callback.LoginCallBack(false, "密码错误",0);
            }

        }

        // 检查是否重名
        public bool LoginCheck(User user)
        {
            bool isSameName = false;
            foreach (var users in Users.userList)
            {
                if (users.userName == user.userName)
                {
                    isSameName = true;
                }
            }

            if (isSameName)
            {
                // 调用登录失败方法
                user.callback.LoginCallBack(false, "重复登录，登录失败,可能是上次未退出导致",0);
                return false;
            }
            else
            {
                return true;
            }

        }

        // 检查用户名和密码是否正确
        public bool CheckPassword(string username, string password)
        {
            var query = from u in dbEntity.userInfo
                        where u.username == username && u.password == password
                        select u;
            if (query.Count() > 0)
            {
                var q = query.First();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Logout(string userName)
        {
            User user1 = null;
            foreach (var user in Users.userList)
            {
                if (user.userName == userName)
                {
                   user1 = user;
                }
            }

            if(user1!=null)
            {
                Users.userList.Remove(user1);
            }
        }

        public void GetAllPosts(int UserID)
        {
            var query = from p in dbEntity.postInfo
                        orderby p.postTime descending
                        select p;

            List<Post> Posts = new List<Post>();
            foreach (var post in query)
            {
                int posterID = 0;
                if (post.posterID != null)
                {
                    posterID = (int)post.posterID;
                }

                System.DateTime postTime = DateTime.Now;
                if (post.postTime != null)
                {
                    postTime = (System.DateTime)post.postTime;
                }

                Post NewPost = new Post(post.Id, GetUserByID(posterID).userName, post.title, post.content, postTime);
                Posts.Add(NewPost);
            }

            GetUserByID(UserID).callback.GetAllPostsCallBack(Posts);
        }

        public void CreateNewPost(int posterID,string title,string content)
        {
            postInfo NewPost = new postInfo();
            NewPost.posterID = posterID;
            NewPost.title = title;
            NewPost.content = content;
            NewPost.postTime = DateTime.Now;
            dbEntity.postInfo.Add(NewPost);
            dbEntity.SaveChanges();

            // 提示所有主机刷新帖子列表
            foreach(var u in Users.userList)
            {
                u.callback.RefreshPostList();
            }
        }

        public void CreateNewComment()
        {
            throw new NotImplementedException();
        }

        // 获取用户ID
        public int GetUserID(string username)
        {
            var query = from u in dbEntity.userInfo
                        where u.username == username
                        select u;
            if (query.Count() > 0)
            {
                var q = query.First();
                return q.Id;
            }
            else
            {
                return 0;
            }
        }

        public User GetUserByID(int UserID)
        {
            User user = new User();
            foreach(var u in Users.userList) {
                if(u.id == UserID)
                {
                    user = u;
                }
            }

            return user;
        }
    }
}
