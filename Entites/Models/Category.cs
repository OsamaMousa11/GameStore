﻿

namespace GameStore
{
    public class Category: BaseEntity
    {
     public ICollection<Game> Games {  get; set; }=new List<Game>();
    }
}
