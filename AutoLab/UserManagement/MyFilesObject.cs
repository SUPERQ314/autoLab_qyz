using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cn.bmob.io;

namespace AutoLab.UserManagement
{
    class MyFilesObject:BmobTable
    {
        private string fTable;
        public BmobFile url { get; set; }
        public string user { get; set; }
        public MyFilesObject() { }
        public MyFilesObject(string tableName)
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
            this.url = input.getFile("url");
            this.user = input.getString("user");
        }
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("url", this.url);
            output.Put("user", this.user);
        }
    }
}
