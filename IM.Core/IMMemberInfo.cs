using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core
{
    public class IMMemberInfo : Element
    {
        public IMMemberInfo()
        {
            this.TagName = "Info";
            this.Namespace = "agsoftware:Info";
        }
        public IMMemberInfo(string name, string pwd, string sex, int age, string group, string tel, string email) : this()
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
            this.Group = group;
            this.Tel = tel;
            this.Email = email;
            this.Pwd = pwd;
        }
        public string Name
        {
            get { return GetTag("name"); }
            set { SetTag("name", value); }
        }
        public string Pwd
        {
            get { return GetTag("pwd"); }
            set { SetTag("pwd", value); }
        }
        public int FaceId
        {
            get { return GetTagInt("faceid"); }
            set { SetTag("faceid", value.ToString()); }
        }
        public string Sex
        {
            get { return GetTag("sex"); }
            set { SetTag("sex", value); }
        }
        public int Age
        {
            get { return GetTagInt("age"); }
            set { SetTag("age", value.ToString()); }
        }
        public string Group
        {
            get { return GetTag("group"); }
            set { SetTag("group", value); }
        }
        public string Tel
        {
            get { return GetTag("tel"); }
            set { SetTag("tel", value); }
        }
        public string Email
        {
            get { return GetTag("email"); }
            set { SetTag("email", value); }
        }
    }
}
