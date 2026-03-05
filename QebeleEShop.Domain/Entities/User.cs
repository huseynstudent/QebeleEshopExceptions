using QebeleEShop.Domain.BaseEntities;
using QebeleEShop.Domain.Enums;

namespace QebeleEShop.Domain.Entities;

public class User: BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public UserType UserType { get; set; }

}
