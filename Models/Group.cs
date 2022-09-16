using Bogus;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DatabaseOperations.Models
{
    public class Group : Entity
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public int NumberInt { get; set; }
        public long NumberLong { get; set; }
        public float NumberFloat { get; set; }
        public double NumberDouble { get; set; }
        public decimal NumberDecimal { get; set; }

        public IEnumerable<User> Users { get; set; }

        [JsonConstructor]
        public Group()
        {
            var faker = new Faker("pt_PT");

            Name = faker.Commerce.Categories(1)[0];
            Email = faker.Internet.Email(Name.ToLower());
            var number = faker.Random.Decimal(0M, 100M);
            NumberDecimal = number;
            NumberDouble = Decimal.ToDouble(number);
            NumberFloat = (float)Decimal.ToDouble(number);
            NumberInt = Decimal.ToInt32(number);
            NumberLong = Decimal.ToInt64(number);

        }

        public Group(string name, string email, int numberInt, long numberLong, float numberFloat, double numberDouble, decimal numberDecimal)
        {
            Name = name;
            Email = email;
            NumberInt = numberInt;
            NumberLong = numberLong;
            NumberFloat = numberFloat;
            NumberDouble = numberDouble;
            NumberDecimal = numberDecimal;
        }
    }
}
