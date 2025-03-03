using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        
        // связь many-to-many Role с User
        [JsonIgnore]
        public ICollection<User> UserR_U { get; set; } = new List<User>();

        // связь many-to-many Role с Permission
        public ICollection<Permission> PermissionR_P { get; set; } = new List<Permission>();
    }
}