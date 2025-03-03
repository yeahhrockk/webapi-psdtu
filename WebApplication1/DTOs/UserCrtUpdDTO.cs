using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class UserCrtUpdDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Role4CrtUpdDTO> add_role { get; set; } = new List<Role4CrtUpdDTO>();
    }
}