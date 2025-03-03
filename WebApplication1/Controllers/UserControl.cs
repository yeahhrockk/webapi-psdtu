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
    // работа контроллеров ака эндпоинтов

    [Route("UserCRUD") ]                                  // маршрут URL к контроллеру
    [ApiController]                                          // обработка ошибок проверки данных модели \ привязка маршрута [FromRoute]
    public class UserControl : ControllerBase                
    {
      private readonly ApplicatonDBContext _context; 
      public UserControl(ApplicatonDBContext context)
      {
        _context = context;
      }

      // запрос всех пользователей с их данными
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _context.UseR
                            .Include(u => u.RoleU_R)
                            .ThenInclude(role => role.PermissionR_P)
                            .ToList()
                            .Select(u => new UserDTO
        {
            UserId = u.Id,
            Name = u.Name,
            Age = u.Age,
            Adress = u.Adress,
            Email = u.Email,
            Role = u.RoleU_R.Select(role => new RoleDTO
            {
                RoleId = role.Id,
                Name = role.Name,
                Permissions = string.Join(", ", role.PermissionR_P.Select(perm => perm.Name))
            }).ToList()
        }).ToList();

        return Ok(users);
    }


        // получение одного пользователя по id
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.UseR
                               .Include(u => u.RoleU_R)
                               .ThenInclude(r => r.PermissionR_P)
                               .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }
        // направление через dto
            var userDto = new UserDTO
            {
                UserId = user.Id,
                Name = user.Name,
                Age = user.Age,
                Adress = user.Adress,
                Email = user.Email,
                Role = user.RoleU_R.Select(r => new RoleDTO
                {
                    RoleId = r.Id,
                    Name = r.Name,
                    Permissions = string.Join(", ", r.PermissionR_P.Select(p => p.Name))
                }).ToList()
            };

            return Ok(userDto);
        }


        // добавление нового пользователя с ролями и правами
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCrtUpdDTO ucuD)
        {
            if (ucuD == null)
            {
                return BadRequest();
            }

            var newUser = new User
            {
                Name = ucuD.Name,
                Age = ucuD.Age,
                Adress = ucuD.Adress,
                Email = ucuD.Email,
                RoleU_R = new List<Role>()

            };

            // проверка ролей и разрешений
            if (ucuD.add_role != null && ucuD.add_role.Any())
            {
                foreach (var role in ucuD.add_role)
                {
                    var existingRole = _context.RoleS
                                               .Include(r => r.PermissionR_P)
                                               .FirstOrDefault(r => r.Id == role.RoleId);

                    if (existingRole != null)
                    {
                        newUser.RoleU_R.Add(existingRole);
                    }
                    else
                    {
                        return BadRequest($"Role with ID {role.RoleId} not found.");
                    }
                }
            }

            _context.UseR.Add(newUser);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
        }


        // редактирование пользователя
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserCrtUpdDTO ucuD)
        {
            if (ucuD == null)
            {
                return BadRequest("Invalid request data.");
            }

            var user = _context.UseR
                            .Include(u => u.RoleU_R)
                            .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            user.Name = ucuD.Name;
            user.Age = ucuD.Age;
            user.Adress = ucuD.Adress;
            user.Email = ucuD.Email;

            user.RoleU_R.Clear();

            if (ucuD.add_role != null && ucuD.add_role.Any())
            {
                foreach (var roleDto in ucuD.add_role)
                {
                    var existingRole = _context.RoleS
                                            .Include(r => r.PermissionR_P)
                                            .FirstOrDefault(r => r.Id == roleDto.RoleId);

                    if (existingRole != null)
                    {
                        user.RoleU_R.Add(existingRole);
                    }
                    else
                    {
                        return BadRequest($"Role with ID {roleDto.RoleId} not found.");
                    }
                }
            }

            _context.SaveChanges();

            var response = new
            {
                id = user.Id,
                name = user.Name,
                age = user.Age,
                adress = user.Adress,
                email = user.Email,
                add_role = user.RoleU_R.Select(r => new { id = r.Id }).ToList()
            };

            return Ok(response);
        }



        // удаление пользователя по id
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var user = _context.UseR.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.UseR.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}