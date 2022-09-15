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


        public Group()
        {
            
        }

        public Group(string name, string? email, int numberInt, long numberLong, float numberFloat, double numberDouble, decimal numberDecimal)
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
