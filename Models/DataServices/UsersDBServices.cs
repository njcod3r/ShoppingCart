using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicCard.Models.DataServices
{
    public class UsersDBServices
    {
        private readonly MagicCardModel db;

        public UsersDBServices()
        {
            db = new MagicCardModel();
        }


        public Usr_Users getUserDataByNameAndPassword(string username, byte[] password)
        {
            var user = db.Usr_Users.SingleOrDefault(u => u.UserName == username && u.UserPassword == password);
            return user;
        }


    }
}