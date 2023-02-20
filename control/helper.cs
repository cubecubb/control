using control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace control
{
    internal class helper
    {
        private static controlEntities controlEntities1;
        public static controlEntities GetContext()
        {
            if (controlEntities1 == null)
            {
                controlEntities1 = new controlEntities();
            }
            return controlEntities1;
        }

        public string FindUsers(string Login, string Password)
        {
            var User = controlEntities1.User.Where(x => x.Login == Login).FirstOrDefault();
            if (User == null)
            {
                return "Неверно введены логин или пароль!";
            }
            else
            {
                if (Password == User.Password)
                {
                    switch (User.IDRole)
                    {
                        case 1:
                            return "Добро пожаловать! Ваша роль: администратор.";
                            break;
                        case 2:
                            return "Добро пожаловать! Ваша роль: модератор.";
                            break;
                        case 3:
                            return "Добро пожаловать! Ваша роль: пользователь.";
                            break;
                        default: return "Неверно введены логин или пароль!";
                    }
                }
                else return "Неверно введены логин или пароль!";
            }

        }
    }
}
