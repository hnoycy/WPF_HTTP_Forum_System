using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services.Description;

namespace GobangGameWcfService
{
    //需要服务端实现的协定
    [ServiceContract(Namespace = "WcfGobangGameExample",
        CallbackContract = typeof(IGobangServiceCallback))]
    public interface IGobangService
    {
        [OperationContract(IsOneWay = true)]
        void Login(string userName, string password);

        [OperationContract(IsOneWay = true)]
        void Logout(string userName);

        [OperationContract(IsOneWay = true)]
        void GetAllPosts(int userID);

        [OperationContract(IsOneWay = true)]
        void CreateNewPost(int posterID, string title, string content);

        [OperationContract(IsOneWay = true)]
        void CreateNewComment();
    }
     //需要客户端实现的接口
    public interface IGobangServiceCallback
    {
        // 登录回调
        [OperationContract(IsOneWay = true)]
        void LoginCallBack(bool status, string message, int userID);

        [OperationContract(IsOneWay = true)]
        void GetAllPostsCallBack(List<Post> postsList);

        [OperationContract(IsOneWay = true)]
        // 帖子列表刷新
        void RefreshPostList();
    }

}
