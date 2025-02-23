using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace WebApplication1.Models
{
    //создание колонок в базе данных PostgreSQL
    public class Userss
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;    
   
    }
}