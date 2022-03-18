using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using Models;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PredmetController : ControllerBase
    {
        public MuzejContext Context { get; set; }

        public PredmetController(MuzejContext context)
        {
            Context = context;
        }
        [EnableCors("CORS")]
        [Route("DodajPredmet/{naziv}/{godina}/{tip}/{tvorac}/{muzejId}/{era}")]
        [HttpPost]
        public async Task<ActionResult> DodajPredmet(string naziv, int godina, string tip, string tvorac, int muzejId,string era)
        {
            if(string.IsNullOrWhiteSpace(naziv) || naziv.Length > 50)
            {
                return BadRequest("Pogresno unet naslov");
            }
            if(string.IsNullOrWhiteSpace(tip) || tip.Length > 20)
            {
                return BadRequest("Pogresno unet tip predmeta");
            }
            if(era != "p.n.e" && era != "n.e.")
            {
                return BadRequest("Pogresno uneta era");
            }
            if(muzejId <= 0)
            {
                return BadRequest("Pogresno unet id muzeja");
            }
            if(godina.ToString().Length > 4)
            {
                return BadRequest("Pogresno uneta godina");
            }
            if(string.IsNullOrWhiteSpace(tvorac) || tvorac.Length > 50)
            {
                return BadRequest("Pogresno unet tvorac");
            }
            try
            {
                
                var muzej = await Context.Muzej.Where(p=>p.ID == muzejId).FirstOrDefaultAsync();
                if(muzej!= null)
                {
                    Predmet pr = new Predmet();
                    pr.Naziv = naziv;
                    pr.Godina = godina;
                    pr.Tip = tip;
                    pr.Tvorac=tvorac;
                    pr.Muzej = muzej;
                    Context.Predmet.Add(pr);
                    await Context.SaveChangesAsync();
                    return Ok($"Uspesno dodat predmet: {naziv}");
                }
                else
                {
                    return BadRequest("Ne postoji muzej");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }[EnableCors("CORS")]
        [Route("PrikaziPredmete")]
        [HttpGet]
        public ActionResult PrkaziPredmete(){
        try{
            return Ok(Context.Predmet);
            
            }
        catch(Exception ex){
            return BadRequest(ex.Message);
            }
        }
        [EnableCors("CORS")]
        [Route("IzbrisiPredmet/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisatiPredmet(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }

            try
            {
                var predmet = await Context.Predmet.FindAsync(id);
                Context.Predmet.Remove(predmet);
                await Context.SaveChangesAsync();
                return Ok($"Uspešno izbrisan predmet: {predmet.Naziv}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [EnableCors("CORS")]
        [Route("PromeniPredmet/{naziv}/{godina}/{tip}/{tvorac}/{muzejj}/{era}")]
        [HttpPut]
        public async Task<ActionResult> PromeniPredmet(int id,string naziv, int godina, string tip, string tvorac,string muzejj,string era)
        {
            if (id <= 0)
            {
                return BadRequest("Pogresno unet id");
            }

            if (godina < 1)
            {
                return BadRequest("Pogresno uneta godina");
            }

            if (naziv.Length > 50)
            {
                return BadRequest("Pogresno unet naziv");
            }

            if (era != "p.n.e" && era != "n.e.")
            {
                return BadRequest("Pogresno uneta era");
            }

            if (tip.Length > 50)
            {
                return BadRequest("Pogresno unet tip");
            }
            if (muzejj.Length > 50)
            {
                return BadRequest("Pogresno unet tip");
            }
            try
            {
                var muzej = Context.Muzej.Where(q => q.Naziv == muzejj).FirstOrDefault();
                var pr = Context.Predmet.Where(p => p.ID == id).FirstOrDefault();
                if(pr!=null)
                {
                    pr.Naziv = naziv;
                    pr.Godina = godina;
                    pr.Tip = tip;
                    pr.Tvorac=tvorac;
                    pr.Muzej=muzej;
                    pr.Era=era;
                    await Context.SaveChangesAsync();
                    return Ok($"Uspesno promenjen predmet: {naziv}");
                }
                else
                {
                    return BadRequest("Pogresni podaci");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [EnableCors("CORS")]
        [Route("PredmetiMuzeja/{muzej}")]
        [HttpGet]

        public async Task<ActionResult> PredmetiMuzeja(string muzej)
        {
            if(string.IsNullOrWhiteSpace(muzej)||muzej.Length >50){
                return BadRequest("Pogresan unos");
            }
            else
            {
                try
                {
                    var m = Context.Muzej.Where(p => p.Naziv == muzej).FirstOrDefault();
                    return Ok( await Context.Predmet.Where(q => q.Muzej == m)
                    .Select ( p => new{
                        id = p.ID,
                        naziv = p.Naziv,
                        godina = p.Godina,
                        tip = p.Tip,
                        tvorac = p.Tvorac,
                        era=p.Era
                        }).ToListAsync());
                }
                catch(Exception e)
                {
                return BadRequest(e.Message);
                }
            }
            
        }
        
    }
}