﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_try
{
    internal class User
    {
        //private int id = 0;
        //private string login;
        //private string password;

        private LoginPassword l_p = new LoginPassword();

        private List<LoginPassword> data = new List<LoginPassword>();

        public void loginSetter ()
        {
            Console.WriteLine("Введите Логин");
            string login = Console.ReadLine();
            l_p.login = login;
        }

        public void passwordSetter()
        {
            Console.WriteLine("Введите Пароль");
            string password = Console.ReadLine();
            l_p.password = password;
        }

        public User ()
        {            
            loginSetter();
            passwordSetter();
            // Считываем все строки из файла
            string[] lines = File.ReadAllLines("loginPassword.txt");

            // Проверяем, есть ли строки в файле
            if (lines.Length == 0)
            {
                Console.WriteLine("Файл пуст.");
                return;
            }

            // Заполняем массив данными из файла (i = 1 т.к. первая строка в тхт файле это шапка таблицы)
            for (int i = 1; i < lines.Length; i++)
            {
                this.data.Add(new LoginPassword(lines[i]));
            }

            CheckLoginPassword();
        }

        public void CheckLoginPassword()
        {           

            foreach (LoginPassword lp in data) 
            {
                if (lp.login == l_p.login && lp.password == l_p.password)
                {
                    l_p.id = lp.id;
                    Console.WriteLine("Все ОК!!!");
                }
            }
            if (l_p.id == 0)
            {
                Console.WriteLine("Логин или пароль неверные");
                throw new Exception();
            }
        }
    }
}
