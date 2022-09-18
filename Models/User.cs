using Bogus;
using Newtonsoft.Json;


namespace DatabaseOperations.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public long Height { get; set; }
        public float NumberFloat { get; set; }
        public double NumberDouble { get; set; }
        public decimal NumberDecimal { get; set; }

        //n:1
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }

        //1:n
        public IEnumerable<Contact> Contacts { get; set; }

        //n:n
        public IEnumerable<Group> Groups { get; set; }


        public User(string name, string email, int age, long height, float numberFloat, double numberDouble, decimal numberDecimal, int departmentId)
        {
            Name = name;
            Email = email;
            Age = age;
            Height = height;
            NumberFloat = numberFloat;
            NumberDouble = numberDouble;
            NumberDecimal = numberDecimal;
            DepartmentId = departmentId;
        }

        [JsonConstructor]
        public User()
        {
            
        }

      
        
        
    }
}
