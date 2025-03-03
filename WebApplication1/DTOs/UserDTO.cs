using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<RoleDTO> Role { get; set; } = new List<RoleDTO>();
    }
}