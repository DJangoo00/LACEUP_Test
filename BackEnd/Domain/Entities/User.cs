using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class User : BaseEntity
{
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Password { get; set; }

    public ICollection<Role> Roles { get; set; } = new HashSet<Role>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    public ICollection<UserRole> UsersRoles { get; set; }
}