using System;
using System.Linq;
using System.Web;
using Tethys.Observer.Domain.Common;
using Tethys.Observer.Domain.DataAccess;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Infrastructure
{
    public class SecurityManager
    {
        private const string LoggedUserKey = "LoggedUser";
        private static readonly object mutex = new object();
        private static SecurityManager current;

        private SecurityManager()
        {
        }

        public static SecurityManager Current
        {
            get
            {
                if (current == null)
                {
                    lock (mutex)
                    {
                        if (current == null)
                        {
                            current = new SecurityManager();
                        }
                    }
                }

                return current;
            }
        }

        public User LoggedUser
        {
            get
            {
                return HttpContext.Current.Session[LoggedUserKey] as User;
            }
            private set
            {
                HttpContext.Current.Session[LoggedUserKey] = value;
            }
        }

        public void Logout()
        {
            LoggedUser = null;
        }

        public bool TryLogin(string login, string password, TethysContext context)
        {
            var user = context.Users.FirstOrDefault(x => x.Login == login);

            if (user == null) return false;

            if (user.Password != password.GetSHA512()) { return false; }

            LoggedUser = user;

            return true;
        }
    }
}