using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cn.bmob.io;

namespace BmobCSharpFileDemo.Model
{
    class MyUserObject: BmobUser
    {
        //对应云端字段名称
      /*  public String username { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        */
        //构造函数
        public MyUserObject() { }

       /* //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);

            this.username = input.getString("username");
            this.password = input.getString("password");
            this.email = input.getString("email");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            output.Put("username", this.username);
            output.Put("password", this.password);
            output.Put("email", this.email);
        }*/
    }
}
