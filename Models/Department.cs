using Bogus;
using Newtonsoft.Json;

namespace DatabaseOperations.Models
{
    public class Department: Entity
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
        public Department()
        {
            var faker = new Faker("pt_PT");
            Name = faker.Commerce.Department();
            Email = faker.Internet.Email(Name).ToLower();
            var number = faker.Random.Decimal(0M, 100M);
            NumberDecimal = number;
            NumberDouble = Decimal.ToDouble(number);
            NumberFloat = (float)Decimal.ToDouble(number);
            NumberInt = Decimal.ToInt32(number);
            NumberLong = Decimal.ToInt64(number);
        }
    }
}
