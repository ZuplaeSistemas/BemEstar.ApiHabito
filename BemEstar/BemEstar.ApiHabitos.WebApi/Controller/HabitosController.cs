using BemEstar.ApiHabitos.Models;
using BemEstar.ApiHabitos.Service;
using Microsoft.AspNetCore.Mvc;

namespace BemEstar.ApiHabitos.WebApi.Controller;
[Route("api/[controller]")]
[ApiController]

public class HabitosController :ControllerBase
{
    private HabitosService _service = new HabitosService();

        [HttpGet]
        public List<Habitos> Get()
        {
            return this._service.Read();
        }


        [HttpGet("{id}")]
        public Habitos Get(int id)
        {
            return this._service.ReadById(id);
        }


        [HttpPost]
        public void Post([FromBody] Habitos model)
        {
            this._service.Create(model);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Habitos model)
        {
            if (id != model.Id)
            {
                throw new ArgumentException("O ID do Objeto Person não é igual ao Id da URL.");
            }
            this._service.Update(model);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._service.Delete(id);
        }
    }

