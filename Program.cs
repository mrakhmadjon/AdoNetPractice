using AdoNetPractice.Model;
using AdoNetPractice.Repositories;
using System;

namespace AdoNetPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PersonRepository personrepo = new PersonRepository();
            personrepo.GetAll();

            //Person person = new Person()
            //{

            //    FirstName = "Akmaljon",
            //    LastName = "Kadirov",
            //    Age = 30,
            //    Email = "akmalkadirov@gmail.com",
            //    Password = "20021001",
            //    Phone_number = "+998912021331"
            //};

            //personrepo.Create(person);


            //personrepo.Read(4);

            //personrepo.Delete(3);


            //Person person = new Person()
            //{
            //    Id = 2,
            //    FirstName = "Akmaljon",
            //    LastName = "Kadirov",
            //    Age = 35,
            //    Email = "akmalkadirov@gmail.com",
            //    Password = "20021001",
            //    Phone_number = "+998912021331"
            //};
            //personrepo.Update(person);
        }
    }
}
