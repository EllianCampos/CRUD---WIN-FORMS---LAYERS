using ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace DATA
{
    public class PersonDAL
    {
        private readonly string _connectionString;

        public PersonDAL()
        {
            _connectionString = Connection.get();
        }

        public List<Person> GetAll()
        {
            var people = new List<Person>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string query = "SELECT * FROM People";

                var cmd = new SqlCommand(query, sqlConnection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    people.Add(new Person
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        NickName = reader.GetString(4),
                        DateOfBirth = DateOnly.FromDateTime(reader.GetDateTime(3)),
                        Age = reader.GetInt32(5)
                    });
                }
                reader.Close();
            }

            return people;
        }

        public Person GetById(int id)
        {
            Person person = null;

            using (SqlConnection sqlConnection = new SqlConnection(Connection.get()))
            {
                
                sqlConnection.Open();

                string query = "SELECT * FROM People WHERE PersonId = @id";

                var cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    person = new Person
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        NickName = reader.GetString(4),
                        DateOfBirth = DateOnly.FromDateTime(reader.GetDateTime(3)),
                        Age = reader.GetInt32(5)
                    };
                }
                reader.Close();                    
            }
            return person;
        }

        public bool Insert(Person person)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                
                string query = "INSERT INTO People (FirstName, LastName, NickName, DateOfBirth, Age) VALUES (@firstname, @lastname, @nickname, @dateofbirth, @age)";

                var cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@firstname", person.FirstName);
                cmd.Parameters.AddWithValue("@lastname", person.LastName);
                cmd.Parameters.AddWithValue("@nickname", person.NickName);
                cmd.Parameters.AddWithValue("@dateofbirth", person.DateOfBirth.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@age", person.Age);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(Person person)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string query = "UPDATE People SET FirstName = @firstname, LastName = @lastname, NickName = @nickname, DateOfBirth = @dateofbirth, Age = @age WHERE PersonId = @id";

                var cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@id", person.Id);
                cmd.Parameters.AddWithValue("@firstname", person.FirstName);
                cmd.Parameters.AddWithValue("@lastname", person.LastName);
                cmd.Parameters.AddWithValue("@nickname", person.NickName);
                cmd.Parameters.AddWithValue("@dateofbirth", person.DateOfBirth);
                cmd.Parameters.AddWithValue("@age", person.Age);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string query = "DELETE FROM People WHERE PersonId = @id";

                var cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
