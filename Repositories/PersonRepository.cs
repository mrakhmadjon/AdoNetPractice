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
            con.Close();
        }




        public void Create (Person person)
        {
            NpgsqlConnection con = new NpgsqlConnection(Constants.CONNECTION_STRING);
            con.Open();

            string query = $"insert into person(firstname , lastname, age,email,password,phone_number)" +
                $"values('{person.FirstName}', '{person.LastName}',{person.Age},'{person.Email}','{person.Password}', '{person.Phone_number}')";
            
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void Read(int id)
        {
            NpgsqlConnection con = new NpgsqlConnection(Constants.CONNECTION_STRING);
            con.Open();
            string query = "select * from person";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);


            NpgsqlDataReader reader = cmd.ExecuteReader();
            bool isExist = false;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if(reader.GetInt32(0) == id)
                    {
                        Console.WriteLine($"Id : {reader[0]} FirstName : {reader[1]} Lastname : {reader[2]} Age : {reader[3]} Email : {reader[4]} Password : {reader[5]} PhoneNumber : {reader[6]}");
                        isExist = true;
                    }
                }
                if (!isExist)
                    Console.WriteLine("Bunday Id dagi inson yo'q");
            }
            else
            {
                Console.WriteLine("Tableda Malumot yo'q");
            }
        }


        public void Delete(int id)
        {

            NpgsqlConnection con = new NpgsqlConnection(Constants.CONNECTION_STRING);
            con.Open();
            string delete = $"delete from person where id = {id}";

            

            NpgsqlCommand cmd = new NpgsqlCommand(delete, con);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "O'chirildi":"Bunday Id dagi inson Yo'q");
            con.Close();

        }

        public void Update(int id, Person person)
        {

            NpgsqlConnection con = new NpgsqlConnection(Constants.CONNECTION_STRING);
            con.Open();

            string updateQuery = $"update  person set firstname = '{person.FirstName}',lastname = '{person.LastName}',age = '{person.Age}', email = '{person.Email}',password = '{person.Password}',phone_number = '{person.Phone_number}' where id = {id}";




            NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, con);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Yangilandi" : "Bunday Id dagi inson Yo'q");
            con.Close();


        }



    }
}
