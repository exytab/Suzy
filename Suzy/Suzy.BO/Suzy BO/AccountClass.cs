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
        public int id_avatar { get { return _account.id_avatar; } set { _account.id_avatar = value; } }
        public bool? ban { get { return _account.ban; } set { _account.ban = value; } }
        public bool? admin { get { return _account.admin; } set { _account.admin = value; } }

        /// <summary>
        /// Этот метод сохраняет наш Account в БД        
        /// </summary>
        public void Save()
        {
            using (OurDB db = new OurDB())
            {
                var account = db.Accounts.Find(id);
                account.name = this.name;
                account.password = this.password;
                account.email = this.email;
                account.id_avatar = this.id_avatar;
                account.ban = this.ban;
                account.admin = this.admin;
                db.SaveChanges();
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


    }
}
