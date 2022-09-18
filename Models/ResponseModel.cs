namespace DatabaseOperations.Models;

public class ResponseModel<T> where T : class, new()
{
    public long TimeSpanCreateList { get; init; }
    public long TimeSpanContexts { get; init; }
    public long TimeSpanSave { get; init; }
    public int Result { get;private set; }
    public IEnumerable<T> Entities { get;private set; }
    
    
    public ResponseModel(IEnumerable<T> entities, int result)
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
    public ResponseModel(T entity, int result)
    {
        var tempEntity = new List<T> { entity };
        Entities = tempEntity;
        Result = result;
    }

}