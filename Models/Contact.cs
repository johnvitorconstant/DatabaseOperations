namespace DatabaseOperations.Models;

public class Contact:Entity
{
    public string Name { get; set; }
    public string Value { get; set; }
    public int NumberInt { get; set; }
    public long NumberLong { get; set; }
    public float NumberFloat { get; set; }
    public double NumberDouble { get; set; }
    public decimal NumberDecimal { get; set; }

    public User User { get; set; }
    public int UserId { get; set; }
}