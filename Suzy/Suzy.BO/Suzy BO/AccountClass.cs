using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suzy.BO
{
    class Account
    {
       	private account _account;
	
        public int id { get { return _account.id;} private set { _account.id = value;} }
        public string name { get { return _account.name;} set { _account.name = value;} }
        public string surname { get { return _account.surname;} set { _account.surname = value;} }
        public string login { get { return _account.login;} set { _account.login = value;} }
        public string password { get { return _account.password;} set { _account.password = value;} }
        public string email { get { return _account.email;} set { _account.email = value;} }
        public int id_avatar { get { return _account.id_avatar;} set { _account.id_avatar = value;} }
        public bool ban { get { return _account.ban;} set { _account.ban = value;} }
        public bool admin { get { return _account.admin;} set { _account.admin = value;} }
        public void Save()
        {
            using (OurDB db = new OurDB())
            {
                var account = db.Accounts.Find(id);
                account.name = this.name;
                account.surname = this.surname;
                account.login = this.login;
                account.password = this.password;
                account.email = this.email;
                account.id_avatar = this.id_avatar;
                account.ban = this.ban;
                account.admin = this.admin;
                db.SaveChanges();
            }

        }
       

      public Account(account _Account)
        {
			_account = _Account;
        }

        public Account()
        {
			_account = new account();
        }
    }
}
