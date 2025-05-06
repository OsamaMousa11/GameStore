

namespace GameStore
{
    public class Category: BaseEntity
    {
     public ICollection<Games> Games {  get; set; }=new List<Games>();
    }
}
