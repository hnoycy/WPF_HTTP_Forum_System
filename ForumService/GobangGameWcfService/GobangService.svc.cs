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
            User newUser = new User(userName, callback);

            if (CheckPassword(userName, password))
            {
                // 检查重名
                if (LoginCheck(newUser))
                {
                    Users.userList.Add(newUser);
                    newUser.callback.LoginCallBack(true, "登录成功");
                }
            }
            else
            {
                newUser.callback.LoginCallBack(false, "密码错误");
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
                user.callback.LoginCallBack(false, "重复登录，登录失败,可能是上次未退出导致");
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
    }
}
