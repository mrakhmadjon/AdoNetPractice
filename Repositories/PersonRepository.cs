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
        public List<Person> GetAll(int lim,int offse)
        {
            NpgsqlConnection con = new NpgsqlConnection(Constants.CONNECTION_STRING);
            con.Open();
            string query = $"select * from person limit {lim} offset {offse}";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);


            NpgsqlDataReader reader = cmd.ExecuteReader();

            IList<Person> person =  new List<Person>();
            int i = 0; 
           
                while (reader.Read())
                {
                   person.Add(new Person()
                   {
                       Id = reader.GetInt32(0),
                       FirstName = reader.GetString(1).ToString(),
                       LastName = reader.GetString(2).ToString(),
                       Age = reader.GetInt32(3),
                       Email = reader.GetString(4).ToString(),
                       Password = reader.GetString(5).ToString(),
                       Phone_number = reader.GetString(6).ToString()

                   });
                    i++;
                }
            con.Close();
            return (List<Person>)person;
            
        }




        public void Create (Person person)
        {
            try
            {
                NpgsqlConnection con = new NpgsqlConnection(Constants.CONNECTION_STRING);
                con.Open();

                string query = $"insert into person(firstname , lastname, age,email,password,phone_number)" +
                    $"values('{person.FirstName}', '{person.LastName}',{person.Age},'{person.Email}','{person.Password}', '{person.Phone_number}')";

                NpgsqlCommand cmd = new NpgsqlCommand(query, con);

                int created = cmd.ExecuteNonQuery();
                if (created == 1)
                    Console.WriteLine("Qo'shildi...");
                con.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); 
            }
        }


        public Person Read(int id)
        {
            NpgsqlConnection con = new NpgsqlConnection(Constants.CONNECTION_STRING);
            con.Open();
            string query = "select * from person";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);


            NpgsqlDataReader reader = cmd.ExecuteReader();
           
            
                while (reader.Read())
                {
                    if(reader.GetInt32(0) == id)
                    {
                        return new Person()
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Age = reader.GetInt32(3),
                            Email = reader.GetString(4),
                            Password = reader.GetString(5),
                            Phone_number = reader.GetString(6)
                        };
                        
                    }
                }
            throw new Exception("Bunday user yo'q");
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

        public void Update( Person person)
        {

            NpgsqlConnection con = new NpgsqlConnection(Constants.CONNECTION_STRING);
            con.Open();

            string updateQuery = $"update  person set firstname = '{person.FirstName}',lastname = '{person.LastName}',age = '{person.Age}', email = '{person.Email}',password = '{person.Password}',phone_number = '{person.Phone_number}' where id = {person.Id}";

            NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, con);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Yangilandi" : "Bunday Id dagi inson Yo'q");
            con.Close();


        }



    }
}
