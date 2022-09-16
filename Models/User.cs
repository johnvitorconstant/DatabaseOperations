using System.ComponentModel;
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
        private Department? Department { get; set; }
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
        public User(int qtDpt)
        {
            var faker = new Faker("pt_PT");

            Name = faker.Name.FullName();
            Email = faker.Internet.Email(Name.ToLower());
            Age = faker.Random.Int(18, 50);
            Height = faker.Random.Int(1500, 2100);
            
            var number = faker.Random.Decimal(0M, 100M);
            NumberDecimal = number;
            NumberDouble = Decimal.ToDouble(number);
            NumberFloat = (float)Decimal.ToDouble(number);

            DepartmentId = faker.Random.Int(1, qtDpt);
        }

        public User()
        {
            
        }
        
        
    }
    public class UserDto
    {
      

        [DefaultValue("John")]
        public string Name { get; set; }

        [DefaultValue("johnvitorconstant@gmail.com")]
        public string Email { get; set; }


        [DefaultValue(29)]
        public int Age { get; set; }

        [DefaultValue(1740)]
        public long Height { get; set; }

        [DefaultValue(38.56)]
        public decimal Number { get; set; }

        [DefaultValue(1)]
        public int DepartmentId { get; set; }

        //1:n

        public UserDto(string name, string email, int age, long height, decimal number, int departmentId)
        {
            Name = name;
            Email = email;
            Age = age;
            Height = height;
            Number = number;
            DepartmentId = departmentId;
            
        }

        public UserDto()
        {
            var faker = new Faker("pt_PT");

            Name = faker.Name.FindName();
            Email = faker.Internet.Email(Name);
            Age = faker.Random.Int(18, 50);
            Height = faker.Random.Int(1500, 2100);
            Number = faker.Random.Decimal(0M, 1M);
            DepartmentId = 1;



        }

        

    }

}
