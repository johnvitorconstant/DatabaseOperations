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
    }
}
