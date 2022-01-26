using AdoNetPractice.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetPractice.Repositories
{
    internal class PersonRepository
    {
        public  void GetAll()
        {
            NpgsqlConnection con = new NpgsqlConnection(Constants.CONNECTION_STRING);
            con.Open();
            string query = "select * from person";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);


            NpgsqlDataReader reader = cmd.ExecuteReader();

            IList<Person> person =  new List<Person>();
            int i = 0; 
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   person.Add(new Person()
                   {
                       Id = reader.GetInt32(0),
                       FirstName = reader.GetString(1),
                       LastName = reader.GetString(2),
                       Age = reader.GetInt32(3),
                       Email = reader.GetString(4),
                       Password = reader.GetString(5),
                       Phone_number = reader.GetString(6)

                   });
                    Console.WriteLine($"Id : {person[i].Id} FirstName : {person[i].FirstName} Lastname : {person[i].LastName} Age : {person[i].Age} Email : {person[i].Email} Password : {person[i].Password} PhoneNumber : {person[i].Phone_number}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Tableda Malumot yo'q");
            }
        }




        public void Create (Person person)
        {
            NpgsqlConnection con = new NpgsqlConnection(Constants.CONNECTION_STRING);
            con.Open();
            string query = "select * from person";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);


            NpgsqlDataReader reader = cmd.ExecuteReader();
        }











    }
}
