using DATA;
using ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class PersonBLL
    {
        private readonly PersonDAL _personDAL;

        public PersonBLL()
        {
            _personDAL = new PersonDAL();
        }

        public List<Person> GetAll() => _personDAL.GetAll();

        public Person GetById(int id) => _personDAL.GetById(id);

        public void Save(Person person)
        {
            if (person.FirstName == "")
                throw new ArgumentException("The FirstName is required");

            if (person.LastName == "")
                throw new ArgumentException("The LastName is required");

            bool result = _personDAL.Insert(person);

            if (!result)
                throw new Exception("There was an error saving the Person in the database");
        }

        public Result Update(Person person)
        {
            if (person.FirstName == "")
                return new Result { Success = false, Message = "The FirstName is required" };

            if (person.LastName == "")
                return new Result { Success = false, Message = "The LastName is required" };
            try
            {
                _personDAL.Update(person);
                return new Result { Success = true, Message = "Person data updated successfuly" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = "Something went wrong: " + ex.Message };
            }         
        } 
        
        public Result Delete(int id)
        {
            try
            {
                _personDAL.Delete(id);
                return new Result { Success = true, Message = "Person Deleted Successfully" };
            } catch (Exception ex)
            {
                return new Result { Success = false, Message = "Something went wrong: " + ex.Message };
            }
        }
    }
}
