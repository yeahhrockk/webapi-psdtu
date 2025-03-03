using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [Route("RolesType") ] 
    [ApiController]
    public class RoleControl : ControllerBase                
    {
        private readonly ApplicatonDBContext _context; 
        public RoleControl(ApplicatonDBContext context)
        {
            _context = context;
        }


      // список ролей и их разрешений
    [HttpGet]
    public IActionResult GetAllRoles()
    {
        var roleS = _context.RoleS
                            .Include(r => r.PermissionR_P)
                            .Select(r => new RoleDTO
                            {
                                RoleId = r.Id,
                                Name = r.Name,
                                Permissions = string.Join(", ", r.PermissionR_P.Select(p => p.Name))
                            })
                            .ToList();

        return Ok(roleS);
    }
    
    }
}