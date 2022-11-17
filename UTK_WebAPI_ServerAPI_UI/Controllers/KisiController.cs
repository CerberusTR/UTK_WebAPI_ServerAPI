using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WepAPI_DB;
using WepAPI_DB.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UTK_WebAPI_ServerAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KisiController : ControllerBase
    {
        private readonly WebAPIContext db;

        public KisiController(WebAPIContext db)
        {
            this.db = db;
        }
        // GET: api/<KisiController>
        [HttpGet]
        public ActionResult<ICollection<Kisi>> Get()
        {
            if (db.Kisiler == null)
            {
                return BadRequest();
            }
            return db.Kisiler.Select(x=>x).OrderBy(x=>x.Ad).ToList();

        }

        // GET api/<KisiController>/5
        [HttpGet("ben/{tc:int}")]
        public ActionResult<Kisi> GetKisiByTC(int tc)
        {
            if (tc < 10000||tc>99999)
            {
                return BadRequest();
            }
            if (db.Kisiler.Where(x => x.TC == tc).Count() != 1)
            {
                return NotFound();
            }
            return db.Kisiler.Where(x => x.TC == tc).FirstOrDefault();
        }

      
        // POST api/<KisiController>
        [HttpPost("Ekle")]
        public ActionResult<Kisi> KisiYarat(Kisi kisi)
        {
            //Yemek.kaydet
            Kisi Kayıtlı = new Kisi()
            {

                Ad = kisi.Ad,
                Soyad = kisi.Soyad,
                TC = kisi.TC,
                CinsiyetKisi = kisi.CinsiyetKisi,
                DogumTarihi = kisi.DogumTarihi
            };
            try
            {
                db.Kisiler.Add(Kayıtlı);
                db.SaveChanges();
                return Kayıtlı;
            }
            catch (Exception)
            {

                return Forbid();
            }

        }

        // PUT api/<KisiController>/5
        [HttpPut("/degistir/{id:int}")]
        public ActionResult<Kisi> KisiUpdate(int id, Kisi değişen)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            if (id != değişen.ID)
            {
                return BadRequest();
            }
            Kisi eski = db.Kisiler.Find(id);
            eski.Ad = değişen.Ad;
            eski.Soyad = değişen.Soyad;
            eski.TC = değişen.TC;
            eski.CinsiyetKisi = değişen.CinsiyetKisi;
            eski.DogumTarihi = değişen.DogumTarihi;
            db.Kisiler.Update(eski);
            db.SaveChanges();
            return eski;
        }

        // DELETE api/<KisiController>/5
        [HttpDelete("sil/{ad}/{soyad}")]
        public void KisiSilme(string ad, string soyad)
        {
            var secili = db.Kisiler.Where(x => x.Ad == ad && x.Soyad == soyad).FirstOrDefault();
            db.Kisiler.Remove(secili);
            db.SaveChanges();
            return;
        }
        [HttpGet("ben/{dogumgünü:int}")]
        public ActionResult<IEnumerable<Kisi>> GetKisiByDogumGunu(int dogumgünü)
        {
            if (dogumgünü < 1 || dogumgünü > 31)
            {
                return BadRequest();
            }
            if (db.Kisiler.Where(x => x.DogumTarihi.Day == dogumgünü).Count()< 1)
            {
                return NotFound();
            }
            return db.Kisiler.Where(x => x.DogumTarihi.Day == dogumgünü).OrderBy(x => x.DogumTarihi).ToList()  ;
            
        }
    }
}
