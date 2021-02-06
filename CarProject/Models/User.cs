using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarProject.DataAccess;

namespace CarProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public int CheckUserValidity(string userName, string pass)
        {
            return UserDB.CheckUserValidity(userName,pass);
        }
    }
}