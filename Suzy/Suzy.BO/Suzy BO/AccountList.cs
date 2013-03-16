﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suzy.BO
{
    /// <summary>
    /// Данный класс создает контейнер для оперировании с объектами типа Account
    /// </summary>
   public static class AccountList
    {
        /// <summary>
        /// Метод добавляет в базу данных объект типа Account
        /// </summary>
        /// <param name="location_area">Объект типа Account</param>
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
       /// Данный метод создает из базы данных список аккаунтов
       /// </summary>
       /// <returns>Возвращаем контейнер Аккаунтов с БД</returns>
        public static List<Account> Get()
        {
            using (OurDB db = new OurDB())
            {
                return db.Accounts.ToList().Select(item => new Account(item)).ToList();
            }

        }

    }
}
