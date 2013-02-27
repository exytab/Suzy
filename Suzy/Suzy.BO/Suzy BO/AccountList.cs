﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suzy.BO
{
   abstract class AccountList
    {
        public static void Add(Account account)
        {
            account _account = new account();
            _account.name = account.name;
            _account.surname = account.surname;
            _account.login = account.login;
            _account.password = account.password;
            _account.email = account.email;
            _account.id_avatar = account.id_avatar;
            _account.ban = account.ban;
            _account.admin = account.admin;
            using (OurDB db = new OurDB())
            {
                db.Accounts.Add(_account);
                db.SaveChanges();
            }

        }

        /// <summary>
        /// Повертає усіх користувачів з бази данних
        /// </summary>
        /// <returns>Усіх користувачів у вигляді списку</returns>
        public static List<Account> Get()
        {
            using (OurDB db = new OurDB())
            {
                return db.Accounts.ToList().Select(item => new Account(item)).ToList();
            }

        }

    }
}
