using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Models;

namespace Projekat.Controllers
{
     [ApiController]
    [Route("[controller]")]
    public class KarteController : ControllerBase
    {
        public MuzejContext Context { get; set; }

        public KarteController(MuzejContext context)
        {
            Context = context;
        }

        [EnableCors("CORS")]
        [Route("DodajKartu/{ime}/{prezime}/{muzejId}/{brRezervacije}")]
        [HttpPost]

        public async Task<ActionResult> DodajKartu(string ime, string prezime, int muzejId,int brRezervacije)
        {
            if(string.IsNullOrWhiteSpace(ime) || ime.Length > 50)
            {
                return BadRequest("Pogresno uneto ime");
            }
            if(string.IsNullOrWhiteSpace(prezime) || prezime.Length > 50)
            {
                return BadRequest("Pogresno uneto prezime");
            }
            if(muzejId <= 0)
            {
                return BadRequest("Pogresno unet id muzeja");
            }
            if(brRezervacije > 100000||brRezervacije<0){
                return BadRequest("Netacan broj rezervacije");  
            }
            try
            {
                var muzej = await Context.Muzej.Where(p => p.ID == muzejId).FirstOrDefaultAsync();
                if(muzej != null)
                {
                    Karta karta = new Karta();
                    karta.Ime = ime;
                    karta.Prezime =prezime;
                    karta.Muzej = muzej;
                    karta.BrojRezervacije=brRezervacije;
                    Context.Karta.Add(karta);
                    await Context.SaveChangesAsync();

                    var karte  = await Context.Karta.Where(p=>p.BrojRezervacije==brRezervacije && p.Muzej.ID == muzejId && p.Ime.Equals(ime) 
                 && p.Prezime.Equals(prezime)).ToListAsync();
                    return Ok(
                    karte.Select(p=> new{
                        Ime = p.Ime,
                        Prezime = p.Prezime,
                        Muzej = p.Muzej.Naziv,
                        BrojRezervacije=p.BrojRezervacije,
                        
                    }).ToList());
                }

                return BadRequest("Ne postoji uneti muzej");
               
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [EnableCors("CORS")]
        [Route("PrikaziKarte")]
        [HttpGet]
        public ActionResult PrikaziKarte()
        {
        try{
            return Ok(Context.Karta);
            }
        catch(Exception ex){
            return BadRequest(ex.Message);
            }
        }
        
        [EnableCors("CORS")]
        [Route("ObrisiKartu2/{ime}/{prezime}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiKartu2(string ime, string prezime)
        {
            if(string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(prezime))
                return BadRequest("Prazan string");

            if(prezime.Length > 50|| ime.Length > 50)
                return BadRequest("Predugacak string");  
                
            
            try
            {
                var k = await Context.Karta.Where(p=>p.Ime.Equals(ime)&& p.Prezime.Equals(prezime)).FirstOrDefaultAsync();
                Context.Karta.Remove(k);
                await Context.SaveChangesAsync();

                return Ok(k);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [EnableCors("CORS")]
        [Route("ObrisiKartu/{broj}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiKartu(int broj)
        {
            if(broj > 100000||broj<0){
                return BadRequest("Netacan broj rezervacije");  
            }
            try
            {
                var kk = await Context.Karta.Where(p=>p.BrojRezervacije==broj).FirstOrDefaultAsync();
                var k = await Context.Karta.Where(p=>p.BrojRezervacije==broj).Include(p=>p.Muzej).ToListAsync();
               
                Context.Karta.Remove(kk);
                await Context.SaveChangesAsync();
                

                return Ok(k.Select(p=>new{
                    ime=p.Ime,
                    prezime=p.Prezime,
                    muzej=p.Muzej.Naziv,
                    brojRezervacije=p.BrojRezervacije
                }
                ));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [EnableCors("CORS")]
        [Route("IzmeniKartu/{broj}/{ime}/{prezime}/{muzej}")]
        [HttpPut]
        public async Task<ActionResult> IzmeniKartu(int broj,string ime,string prezime,string muzej)
        {
            if(broj > 100000||broj<0){
                return BadRequest("Netacan broj rezervacije");  
            }
            if(string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(prezime)){
                return BadRequest("Prazan string");
            }
            if(prezime.Length > 50|| ime.Length > 50){
                return BadRequest("Predugacak string");
            }
            if(muzej.Length > 50|| string.IsNullOrEmpty(muzej)){
                return BadRequest("Predugacak string");
            }
            try
            {
                var muz = await Context.Muzej.Where(p=>p.Naziv==muzej).FirstOrDefaultAsync();
                var kk = await Context.Karta.Where(p=>p.BrojRezervacije==broj).FirstOrDefaultAsync();
                var k = await Context.Karta.Where(p=>p.BrojRezervacije==broj).Include(p=>p.Muzej).ToListAsync();
                var zadnje=k.Select(p=>new{
                    ime=p.Ime,
                    prezime=p.Prezime,
                    muzej=p.Muzej.Naziv,
                    brojRezervacije=p.BrojRezervacije
                }
                );
                
                
                kk.Ime=ime;
                kk.Prezime=prezime;
                kk.Muzej=muz;
                await Context.SaveChangesAsync();

                return Ok(zadnje);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        
    }
    
}