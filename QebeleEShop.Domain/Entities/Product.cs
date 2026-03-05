
using QebeleEShop.Domain.BaseEntities;

namespace QebeleEShop.Domain.Entities;

public class Product :BaseEntity
{
    public string Name { get; set; }
    public double Price { get; set; }
}
