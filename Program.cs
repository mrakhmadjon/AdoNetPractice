using AdoNetPractice.Model;
using AdoNetPractice.Repositories;
using System;
using System.Collections.Generic;

namespace AdoNetPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            PersonRepository personrepo = new PersonRepository();

            string option;

            do
            {
              Console.WriteLine("1 : Create\t2 : Update\t3 : GetONe\t4 : GetAll\t5 : Delete");
              option = Console.ReadLine();
            } while (option != "1" && option != "2"  && option != "3" && option != "4" && option != "5" );

            if (option == "1")
            {
                string firstname = Console.ReadLine();
                string lastname = Console.ReadLine();
                int age = int.Parse( Console.ReadLine());
                string email = Console.ReadLine();
                string password = Console.ReadLine();
                string phonenum = Console.ReadLine();

                personrepo.Create(new Person()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    Email = email,
                    Password = password,
                    Phone_number = phonenum
                });
            }
            
            else if (option == "2")
            {
                int id = int.Parse( Console.ReadLine());
                string firstname = Console.ReadLine();
                string lastname = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                string email = Console.ReadLine();
                string password = Console.ReadLine();
                string phonenum = Console.ReadLine();

                personrepo.Update(new Person()
                {
                    Id = id,
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    Email = email,
                    Password = password,
                    Phone_number = phonenum
                });
            }

            else if(option == "3")
            {
                Console.WriteLine("Id ni kiriting");
                int id = int.Parse( Console.ReadLine());
                Person person = personrepo.Read(id);
            }
            else if (option == "4")
            {
                Console.Write("Take : ");
                int take = int.Parse( Console.ReadLine());
                Console.Write("Skip : ");
                int skip = int.Parse( Console.ReadLine());
                IList<Person> people = personrepo.GetAll(take, skip);
                foreach (Person person in people)
                {
                    Console.WriteLine(person.Id + ' ' + person.FirstName + " " + person.LastName + ' ' + person.Age);
                }
            }
           
            else 
            {
                Console.WriteLine("Delete qilmoqchi bo'lgan odamni Id sini kiriting ");
                int idDelte = int.Parse( Console.ReadLine());
                personrepo.Delete(idDelte);
            }

        }
    }
}
