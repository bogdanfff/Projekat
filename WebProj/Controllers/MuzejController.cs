using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace WebProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MuzejController : ControllerBase
    {
         public MuzejContext Context { get; set; }
         public MuzejController(MuzejContext context)
        {
                Context = context;
        }
        [EnableCors("CORS")]
        [Route("DodajMuzej/{naziv}")]
        [HttpPost]
        public async Task<ActionResult> DodajMuzej(string naziv){

            if (string.IsNullOrWhiteSpace(naziv)){
                return BadRequest("Unesite naziv muzeja");
            }

            try{
               
               Muzej m = new Muzej();
               m.Naziv = naziv;
               Context.Muzej.Add(m);
               await Context.SaveChangesAsync();

               return Ok($"Uspesno dodat muzej pod nazivom: {naziv}");

            }
            catch(Exception ex){

                return BadRequest(ex.Message);
            }
        }
        [EnableCors("CORS")]
        [Route("PrikaziMuzej")]
        [HttpGet]
        public async Task<ActionResult> PrikaziMuzej(){
        try{
            return Ok(

                await Context.Muzej
                .Select(p=> new{

                id = p.ID,
                naziv = p.Naziv
                }).ToListAsync());
            }
            catch(Exception ex){

                return BadRequest(ex.Message);
            }
          
        }
        [EnableCors("CORS")]
        [Route("IzbrisiMuzej")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisatiMuzej(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }

            try
            {
                var muzej = await Context.Muzej.FindAsync(id);
                Context.Muzej.Remove(muzej);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno izbrisan muzej: {muzej.Naziv}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        

        
    }
}
