using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Permissions { get; set; } = string.Empty;
    }
}