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
        }
    }
}
