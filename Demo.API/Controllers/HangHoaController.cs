using Demo.API.Data;
using Demo.API.Models.DTO;
using Demo.API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private MyDbContext dbContext;
        public HangHoaController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /* [HttpGet]
         public async Task<IActionResult> getAll()
         {
             var hanghoas = await dbContext.HangHoas.ToListAsync();
             return Ok(hanghoas);
         }
         [HttpGet]
         [Route("{id: guid}")]
         public async Task<IActionResult> getById(Guid id)
         {
             var hanghoa = await dbContext.HangHoas.FirstOrDefaultAsync(x => x.MaHh == id);
             if(hanghoa != null) { 
                 return Ok(hanghoa);
             }
             return NotFound();
         }
         [HttpPost]
         public async Task<IActionResult> Add(HangHoaModel addhh) 
         {
             var hanghoa = new HangHoa()
             {
                 Name = addhh.Name,
                 Content = addhh.Content,
                 DonGia = addhh.DonGia,
                 Sale = addhh.Sale

             };
             await dbContext.HangHoas.AddAsync(hanghoa);
             await dbContext.SaveChangesAsync();

             return Ok(hanghoa);
         }
         [HttpPut]
         [Route("{id: guid}")]
         public async Task<IActionResult> upDate(Guid id,HangHoaModel addhh)
         {
             var existing = await dbContext.HangHoas.FindAsync(id);
             if(existing != null) {
                 existing.Name = addhh.Name;
                 existing.Content = addhh.Content;
                 existing.DonGia = addhh.DonGia;
                 existing.Sale = addhh.Sale;

                 await dbContext.SaveChangesAsync();
                 return Ok(existing);
             };
            return NotFound();
         }
         [HttpDelete]
         [Route("{id: guid}")]
         public async Task<IActionResult> delete(Guid id)
         {
             var existing = await dbContext.HangHoas.FindAsync(id);
             if(existing != null)
             {
                 dbContext.Remove(existing);
                 await dbContext.SaveChangesAsync();
                 return Ok(existing);    
             }
             return NotFound();
         }*/

        /*[HttpGet]
        public IActionResult getAll()
        {
            var hanghoas = dbContext.HangHoas.ToListAsync();
            return Ok(hanghoas);
        }
        [HttpGet]
        [Route("{id: guid}")]
        public IActionResult getById(Guid id)
        {
            var hanghoa =  dbContext.HangHoas.FirstOrDefaultAsync(x => x.MaHh == id);
            if (hanghoa != null)
            {
                return Ok(hanghoa);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Add(HangHoaModel addhh)
        {
            var hanghoa = new HangHoa()
            {
                Name = addhh.Name,
                Content = addhh.Content,
                DonGia = addhh.DonGia,
                Sale = addhh.Sale

            };
             dbContext.HangHoas.AddAsync(hanghoa);
             dbContext.SaveChangesAsync();

            return Ok(hanghoa);
        }
        [HttpPut]
        [Route("{id: guid}")]
        public async Task<IActionResult> upDate(Guid id, HangHoaModel addhh)
        {
            var existing = await dbContext.HangHoas.FindAsync(id);
            if (existing != null)
            {
                existing.Name = addhh.Name;
                existing.Content = addhh.Content;
                existing.DonGia = addhh.DonGia;
                existing.Sale = addhh.Sale;

                await dbContext.SaveChangesAsync();
                return Ok(existing);
            };
            return NotFound();
        }
        [HttpDelete]
        [Route("{id: guid}")]
        public async Task<IActionResult> delete(Guid id)
        {
            var existing = await dbContext.HangHoas.FindAsync(id);
            if (existing != null)
            {
                dbContext.Remove(existing);
                await dbContext.SaveChangesAsync();
                return Ok(existing);
            }
            return NotFound();
        }*/

        [HttpGet]
        public IActionResult getAll()
        {
            var dsHh = dbContext.HangHoas.ToList();
            return Ok(dsHh);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getById(Guid id)
        {
            var loai = dbContext.HangHoas.SingleOrDefault(x => x.MaHh == id);
            if (loai != null)
            {
                return Ok(loai);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateNew(HangHoaModel model)
        {
            try
            {
                var loai = new HangHoa
                {
                    Name = model.Name,
                    Content= model.Content,
                    DonGia  = model.DonGia,
                    Sale=model.Sale,
                };
                dbContext.Add(loai);
                dbContext.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult upDate(Guid id, HangHoaModel model)
        {
            var loai = dbContext.HangHoas.SingleOrDefault(x => x.MaHh == id);
            if (loai != null)
            {
                loai.Name = model.Name;
                loai.Content = model.Content;
                loai.DonGia = model.DonGia;
                loai.Sale = model.Sale;
                dbContext.SaveChanges();
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
            var existingPost = await dbContext.HangHoas.FindAsync(id);
            if (existingPost != null)
            {
                dbContext.Remove(existingPost);
                await dbContext.SaveChangesAsync();
                return Ok(existingPost);
            }
            return NotFound();
        }

    }
}
