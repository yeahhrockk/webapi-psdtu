using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //работа контроллеров ака эндпоинтов

    [Route("api/userrrr") ]                                  //маршрут URL к контроллеру
    [ApiController]                                          //обработка ошибок проверки данных модели \ привязка маршрута [FromRoute]
    public class UserControl : ControllerBase                
    {
      private readonly ApplicatonDBContext _context;
      public UserControl(ApplicatonDBContext context)
      {
        _context = context;
      }

      [HttpGet]
      public IActionResult GetAll()
      {
        var users = _context.Users.ToList();                //запрос к БД \ вывод в виде списка

        return Ok(users);                                   //возвращает результат (список в JSON)
      }

      //запроc данных одного конкретного пользователя по id 
      [HttpGet("{id}")]
      public IActionResult GetById([FromRoute] int id)
      {
        var users = _context.Users.Find(id);
        if(users == null)
        {
          return NotFound();
        }
        return Ok(users);
      }

    }
}