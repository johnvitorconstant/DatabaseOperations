namespace DatabaseOperations.Models;

public class ResponseModel
{
    public long TimeSpanCreateList { get; init; }
    public long TimeSpanContexts { get; init; }
    public long TimeSpanSave { get; init; }
    public int Result { get;private set; }
    public IEnumerable<Object> Entities { get;private set; }
 


    public ResponseModel(IEnumerable<object> entities, int result)
    {
        Result = result;
        if (entities.Count() > 100)
        {
            Entities = entities.ToList().GetRange(0, 100);
        }
        else
        {
            Entities = entities;
        }
    }
}