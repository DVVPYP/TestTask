﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Books books = new Books();
            string a = "";
            while (a!="6")
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:\n 1.Создать книгу;\n 2.Список авторов;\n 3.Список книг; \n 4.Поиск авторов по книге; \n 5.Удаление книги по номеру;\n 6.Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            books.Create();
                        }
                        break;
                    case "2":
                        {
                            books.Autor();
                        }
                        break;
                    case "3":
                        {
                            books.Book();
                        }
                        break;
                    case "4":
                        {
                            books.Select();
                        }
                        break;
                    case "5":
                        {
                            books.Delete();
                        }
                        break;
                    case "6":
                        {
                            a = "6";
                        }
                        break;
                }
                
            }       
        }
    }
}
