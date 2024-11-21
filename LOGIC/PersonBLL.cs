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

        public Result Save(Person person)
        {
            var errors = Validations(person);
            if (errors.Count != 0)
                return new Result { Success = false, Message = "The fields don't meet the validations", Errors = errors };

            try
            {
                _personDAL.Insert(person);
                return new Result { Success = true, Message = "Person saved successfuly" };
            }
            catch (Exception ex)
            {
                return new Result { Success = false, Message = "Something went wrong: " + ex.Message };
            }
        }

        public Result Update(Person person)
        {
            var errors = Validations(person);
            if (errors.Count != 0)
                return new Result { Success = false, Message = "The fields don't meet the validations", Errors = errors };
            
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

        public Dictionary<string, string> Validations(Person person)
        {
            var errros = new Dictionary<string, string>();

            if (person.FirstName == "")
                errros.Add("FirstName", "The FirstName is required");
            else if (person.FirstName.Length < 5)
                errros.Add("FirstName", "The FirstName must have a least 5 characters"); 

            if (person.LastName == "")
                errros.Add("LastName", "The LastName is required");

            return errros;
        }
    }
}
