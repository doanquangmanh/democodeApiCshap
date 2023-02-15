using Demo.API.Data;
using Demo.API.Models.DTO;
using Demo.API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LoaiController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll() {
            var dsLoai = _context.loais.ToList();
            return Ok(dsLoai);  
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getById(Guid id)
        {
            var loai = _context.loais.SingleOrDefault(x => x.MaLoai == id);
            if(loai != null)
            {
                return Ok(loai);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    NameLoai = model.NameLoai,
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);    
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult upDate(Guid id, LoaiModel model)
        {
            var loai = _context.loais.SingleOrDefault(x => x.MaLoai == id);
            if(loai != null)
            {
                loai.NameLoai = model.NameLoai;
                _context.SaveChanges();
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingPost = await _context.loais.FindAsync(id);
            if (existingPost != null)
            {
                _context.Remove(existingPost);
                await _context.SaveChangesAsync();
                return Ok(existingPost);
            }
            return NotFound();
        }
    }
}
