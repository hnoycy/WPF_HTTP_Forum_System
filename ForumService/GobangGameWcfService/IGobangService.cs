using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GobangGameWcfService
{
    //需要服务端实现的协定
    [ServiceContract(Namespace = "WcfGobangGameExample",
        CallbackContract = typeof(IGobangServiceCallback))]
    public interface IGobangService
    {
        [OperationContract(IsOneWay = true)]
        void Login(string userName, string password);
    }
     //需要客户端实现的接口
    public interface IGobangServiceCallback
    {
        // 登录回调
        [OperationContract(IsOneWay = true)]
        void LoginCallBack(bool status, string message);
    }

}
