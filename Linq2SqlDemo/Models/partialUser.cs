using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linq2SqlDemo.Models
{
    public partial class User
    {
        public User(users u)
        {
            this.userId = u.userId;
            this.userName = u.userName;
            this.fullName = u.fullName;
            this.emailId = u.emailId;
            this.phoneNo = u.phoneNo;
            this.password = u.password;
            this.cityid = u.cityId;
            
        }
    }
}