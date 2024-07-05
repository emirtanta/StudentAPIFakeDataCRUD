using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPIFakeDataCRUD.API.Data;
using StudentAPIFakeDataCRUD.API.Models;

namespace StudentAPIFakeDataCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public StudentsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _context.Students.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var record = _context.Students.Find(id);
            if (record==null)
            {
                return NotFound();
            }

            return Ok($"{record.Id} numaralı kayde ait bilgiler!");
        }

        [HttpPost]
        public IActionResult Post([FromBody]Student model)
        {
            _context.Students.Add(model);

            _context.SaveChanges();

            return Ok($"{model.Name} {model.Surname} adlı veri başarılı bir şekilde kaydedildi!");
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody]Student model)
        {
            _context.Students.Update(model);

            _context.SaveChanges();

            return Ok($"{model.Name} {model.Surname} adlı veri başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var record=_context.Students.Find(id);

            if (record!=null)
            {
                _context.Students.Remove(record);

                _context.SaveChanges();

                return Ok($"{record.Name} {record.Surname} adlı kayıt sistemden silinmiştir!");
            }

            return NotFound("Veri bulunamadı!");
        }
    }
}
