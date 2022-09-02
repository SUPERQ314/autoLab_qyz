using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cn.bmob.api;
using cn.bmob.io;

namespace AutoLab.UserManagement
{
    class BmobManager
    {
        static BmobManager instance = null;
        BmobWindows mgr = null;
        private BmobManager()
        {
            mgr = new BmobWindows();
            mgr.initialize("a9d9cec47d56cde6aa91589aede02314", "ae626757b2be3fbe84066835ef047810");
        }
        ///<summary>
        ///BmobManager
        ///</summary>
        ///<returns></return>
        public static BmobManager GetInstance()
        {
            if(instance==null)
            {
                instance = new BmobManager();
            }
            return instance;
        }
        public delegate void RegisterFinished(string strResult);
        public delegate void LoginFinished(bool strResult);
        public delegate void UpdateFinished(string strResult);

        public delegate void InsertFinished(string strResult);

        public void RegisterUser(BmobUser user,RegisterFinished callBack)
        {
            string result = "";
            mgr.Signup(user, (resp, exception) =>
                {
                    if(exception!=null)
                    {
                        result = "请检查网络！";
                    }
                    else
                    {
                        if (resp.sessionToken != null)
                        {
                            result = "注册成功，请登录!";
                        }
                        else
                        {
                            result = "提示：您已注册过账号！";
                        }
                    }
                    if (callBack != null)
                    {
                        callBack(result);
                    }
                });
        }
        public void LoginUser(BmobUser user,LoginFinished callBack)
        {
            bool result = false;
            mgr.Login<BmobUser>(user.username,user.password,(resp,exception)=>
            {
                /*if (resp != null)
                {
                    result = "登录成功！";
                }*/
                
                if(exception != null)
                {
                    //result = "无法登录:\n用户名或密码错误\n如正确，请检查网络";
                }
                else
                {
                    result = true;
                    //result = "登录成功！";
                }
                if(callBack != null)
                {
                    callBack(result);
                }
            });
        }
        public BmobUser GetCurUser()
        {
            return BmobUser.CurrentUser;
        }
        public void UpdateUser(BmobUser user,UpdateFinished callBack)
        {
            string result = "";
            mgr.UpdateUser(GetCurUser().objectId, user, GetCurUser().sessionToken, (resp, exception) =>
                {
                    if (exception != null)
                    {
                        result = "error:" + exception.Message;
                    }
                    else
                    {
                        result = "success:" + resp.updatedAt;
                    }
                    if (callBack != null)
                    {
                        callBack(result);
                    }
                });
        }
    }
}
