using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Permission
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 



        // связь Many-to-Many Permission с Role
        [JsonIgnore]
        public ICollection<Role> RoleP_R { get; set; } = new List<Role>();
    }
}