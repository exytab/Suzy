using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suzy.BO
{
    /// <summary>
    /// Этот класс работает с Аккаунтами 
    /// </summary>
    public class Account
    {
        private account _account;

        public int id 
        { 
            get { return _account.id; }
            internal set { _account.id = value; } 
        }
        public string name { get { return _account.name; } set { _account.name = value; } }
        public string password { get { return _account.password; } set { _account.password = value; } }
        public string email { get { return _account.email; } set { _account.email = value; } }
        internal int id_avatar { get { return _account.id_avatar; } set { _account.id_avatar = value; } }
        public bool? ban { get { return _account.ban; } set { _account.ban = value; } }
        public bool? admin { get { return _account.admin; } set { _account.admin = value; } }

        /// <summary>
        /// Этот метод сохраняет наш Account в БД        
        /// </summary>
        public void Save()
        {
            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                //Проверяю нет ли такого имени или емейла
                var account = db.accounts.Find(id);
                var aEmail = from a in db.accounts
                               where a.email == this.email && a.id != this.id
                               select a;
                var aName = from a in db.accounts
                            where a.name == name && a.id != this.id
                             select a;
                if ((!string.IsNullOrEmpty(this.email) && aEmail.Any()) || (!string.IsNullOrEmpty(this.name) && aName.Any()))
                {
                }
                else
                {
                    account.name = this.name;
                    account.password = this.password;
                    account.email = this.email;
                    account.id_avatar = this.id_avatar;
                    account.ban = this.ban;
                    account.admin = this.admin;
                    db.SaveChanges();
                }
            }
        }

        internal Account(account _Account)
        {
            _account = _Account;
        }

        /// <summary>
        /// Это наш конструктор для аккаунтов без параметров
        /// </summary>
        public Account()
        {
            _account = new account();
        }
        /// <summary>
        /// Это наш конструктор для аккаунтов без параметров
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Account)
            {
                Account accountObj = obj as Account;
                if (accountObj == null)
                    return false;
                else if (this._account == accountObj._account)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// Get Following Accounts List
        /// </summary>
        public List<Account> GetFollowing()
        {
            return AccountList.GetFollowing(this.id);
        }

        /// <summary>
        /// Get Followers Accounts List
        /// </summary>
        public List<Account> GetFollowers()
        {
            return AccountList.GetFollowers(this.id);
        }

        /// <summary>
        /// Save Avatar (only File name)
        /// </summary>
        public void SaveAvatar(String Path)
        {
            avatar avatar = new avatar();
            avatar.avatar_src = Path;

            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                db.avatars.Add(avatar);
                db.SaveChanges();
            }

            this.id_avatar = avatar.id;
            Save();
        }

        public string GetAvatar()
        {
            if (this.id_avatar > 1)
            {
                using (CustomSuzyEntities db = new CustomSuzyEntities())
                {
                    var avatars = from avatar in db.avatars
                                   where avatar.id == this.id_avatar
                                   select avatar;
                    if (avatars.Any())
                        return avatars.First().avatar_src;
                    else
                        return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool CheckAvatar()
        {
            return this.id_avatar > 1;
        }

        public bool IsFollower(int accountId)
        {
            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                var subs = from sub in db.subscribers
                              where sub.id_leader == this.id &&
                              sub.id_subscriber == accountId
                              select sub;
                return subs.Any();
            }
        }

        public bool IsFollowing(int accountId)
        {
            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                var subs = from sub in db.subscribers
                           where sub.id_leader == accountId &&
                           sub.id_subscriber == this.id
                           select sub;
                return subs.Any();
            }
        }

        public void Following(int accountId)
        {
            if (this.id > 0 && this.id != accountId)
            {
                using (CustomSuzyEntities db = new CustomSuzyEntities())
                {
                    var subs = from sub in db.subscribers
                               where sub.id_leader == accountId &&
                                     sub.id_subscriber == this.id
                               select sub;
                    if (!subs.Any())
                    {
                        db.subscribers.Add(new subscriber()
                                               {
                                                   id_leader = accountId,
                                                   id_subscriber = this.id
                                               });

                        db.SaveChanges();
                    }
                }
            }
        }

        public void UnFollowing(int accountId)
        {
            if (this.id > 0 && this.id != accountId)
            {
                using (CustomSuzyEntities db = new CustomSuzyEntities())
                {
                    var subs = from sub in db.subscribers
                               where sub.id_leader == accountId &&
                                     sub.id_subscriber == this.id
                               select sub;
                    if (subs.Any())
                    {
                        db.subscribers.Remove(subs.First());
                        db.SaveChanges();
                    }
                }
            }
        }

        public LocationArea LastPoint()
        {
            using (CustomSuzyEntities db = new CustomSuzyEntities())
            {
                List<location_area> areas = db.location_area.Where(area => area.id_account == this.id).ToList();
                if(areas.Any())
                {
                    return new LocationArea(areas.OrderByDescending(item => item.id).First());
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
