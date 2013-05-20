using System;
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
            _account.password = account.password;
            _account.email = account.email;
            _account.id_avatar = account.id_avatar > 0  ? account.id_avatar : 1;
            _account.ban = account.ban;
            _account.admin = account.admin;
            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                var aEmail = from a in db.accounts
                             where a.email == account.email
                             select a;
                var aName = from a in db.accounts
                            where a.email == account.name
                            select a;
                if ((!string.IsNullOrEmpty(account.email) && aEmail.Any()) ||
                    (!string.IsNullOrEmpty(account.name) && aName.Any()))
                {
                }
                else
                {
                    db.accounts.Add(_account);
                    db.SaveChanges();
                }
            }
            //using (OurDB db = new OurDB())
            //{
            //    db.Accounts.Add(_account);
            //    db.SaveChanges();
            //}
            account.id = _account.id;
        }

        /// <summary>
        /// Данный метод создает из базы данных список аккаунтов
        /// </summary>
        /// <returns>Возвращаем контейнер Аккаунтов с БД</returns>
        public static List<Account> Get()
        {
            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                return db.accounts.ToList().Select(item => new Account(item)).ToList();
            }
            //using (OurDB db = new OurDB())
            //{
            //    return db.Accounts.ToList().Select(item => new Account(item)).ToList();
            //}

        }

        /// <summary>
        /// Получаем из базы аккаунт по мейлу и паролю
        /// </summary>
        public static Account Get(string email, string password)
        {
            Account result = null;
            //using (OurDB db = new OurDB())
            //{
            //    var accounts = from account in db.Accounts
            //                   where account.email == email && account.password == password
            //                   select account;
            //    if (accounts.Any())
            //        return new Account(accounts.First());
            //}
            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                var accounts = from account in db.accounts
                               where account.email == email && account.password == password
                               select account;
                if (accounts.Any())
                    return new Account(accounts.First());

            }
            return result;
        }
        /// <summary>
        /// Получаем из базы аккаунт по мейлу
        /// </summary>
        public static Account Get(string email)
        {
            Account result = null;
            //using (OurDB db = new OurDB())
            //{
            //    var accounts = from account in db.Accounts
            //                   where account.email == email 
            //                   select account;
            //    if (accounts.Any())
            //        return new Account(accounts.First());
            //}
            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                //Model.Connection.Open();

                var accounts = from account in db.accounts
                               where account.email == email 
                               select account;
                if (accounts.Any())
                    return new Account(accounts.First());
            }
            return result;
        }
        /// <summary>
        /// Получаем из базы аккаунт по мейлу
        /// </summary>
        public static Account GetByName(string name)
        {
            Account result = null;
            //using (OurDB db = new OurDB())
            //{
            //    var accounts = from account in db.Accounts
            //                   where account.name == name
            //                   select account;
            //    if (accounts.Any())
            //        return new Account(accounts.First());
            //}
            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                var accounts = from account in db.accounts
                               where account.name == name
                               select account;
                if (accounts.Any())
                    return new Account(accounts.First());
            }
            return result;
        }
         /// <summary>
        /// Получаем из базы аккаунт по ID
        /// </summary>
        public static Account Get(int id)
        {
            if(id > 0)
                using (CustomSuzyEntities db = new CustomSuzyEntities())
                {
                    var accounts = from account in db.accounts
                                   where account.id == id
                                   select account;
                    if (accounts.Any())
                        return new Account(accounts.First());
                }
            return null;
        }

        //TODO: Get: query
        /// <summary>
        /// Получаем аккаунты, на которых подписаны
        /// </summary>
        public static List<Account> GetFollowing(int accountId)
        {
            if (accountId > 0)
                using (CustomSuzyEntities db = new CustomSuzyEntities())
                {
                   int[] ids = (
                                        from fId in db.subscribers
                                        where fId.id_subscriber == accountId
                                        select fId.id_leader
                                    ).ToArray();

                   return (db.accounts.Where(i => ids.Contains(i.id)).ToList().Select(item => new Account(item)).ToList());
                }
            return null;
        }

        /// <summary>
        /// Получаем получаем подписчиков на аккаунт
        /// </summary>
        public static List<Account> GetFollowers(int accountId)
        {
            if (accountId > 0)
                using (CustomSuzyEntities db = new CustomSuzyEntities())
                {
                    List<int> ids = (
                                        from fId in db.subscribers
                                        where fId.id_leader == accountId
                                        select fId.id_subscriber
                                    ).ToList();

                    return (db.accounts.Where(i => ids.Contains(i.id)).ToList().Select(item => new Account(item)).ToList());
                }
            return null;
        }
    }
}
