using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GobangGameWcfService
{
    public class User
    {
        public userInfo userInfo { get; set; }

        MyDBEntities context = new MyDBEntities();

        /// <summary>登录的用户名</summary>
        public int id;
        public string userName;
        public string password;
        public DateTime loginTime;
        public readonly IGobangServiceCallback callback;

        public User()
        {
            userInfo = new userInfo();
        }

        public virtual void Create()
        {
            bool success = false;
            //插入到数据库
            try
            {
                context.userInfo.Add(userInfo);
                context.SaveChanges();
                success = true;
            }
            catch (Exception err)
            {
                success = false;

            }
            if (success)
            {

            }
        }

        public User(string userName, IGobangServiceCallback callback)
        {
            this.userName = userName;
            this.callback = callback;
        }


    }
}