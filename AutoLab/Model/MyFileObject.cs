using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cn.bmob.io;
using cn.bmob.api;
using cn.bmob.json;
using cn.bmob.tools;

namespace AutoLab.Model
{
    class MyFileObject : BmobTable
    {
        public string fTable;
        //以下对应云端字段名称
        public String UserName { get; set; }
        public String URL { get; set; }
        //构造函数
        public MyFileObject() { }
        //构造函数
        public MyFileObject(String tableName)
        {
            this.fTable = tableName;
        }
        public override string table
        {
            get
            {
                if (fTable != null)
                {
                    return fTable;
                }
                return base.table;
            }
        }
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            this.UserName = input.getString("Username");
            this.URL = input.getString("URL");
        }
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("Username", this.UserName);
            output.Put("URL", this.URL);
        }
    }
}