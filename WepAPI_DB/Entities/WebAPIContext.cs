using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WepAPI_DB.Entities.Configuration;

namespace WepAPI_DB.Entities
{
    public class WebAPIContext:DbContext
    {
        public WebAPIContext(DbContextOptions<WebAPIContext>options) : base(options)
        {

        }
        public DbSet<Kisi> Kisiler { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KisiConfiguration());
            modelBuilder.Entity<Kisi>().HasData(
                new Kisi { ID=2,Ad = "Tolga", Soyad = "SERTKAYA", CinsiyetKisi = Cinsiyet.E, TC = 11111, DogumTarihi = DateTime.Now.AddYears(-30) },
                new Kisi { ID = 7, Ad = "Onur Alp", Soyad = "AYDIN", CinsiyetKisi = Cinsiyet.E, TC = 22222, DogumTarihi = DateTime.Now.AddYears(-28) },
                new Kisi { ID = 4, Ad = "Cenk", Soyad = "TANKSOYLU", CinsiyetKisi = Cinsiyet.K, TC = 33333, DogumTarihi = DateTime.Now.AddYears(-32) },
                new Kisi { ID = 5, Ad = "Oğuzhan", Soyad = "BAYRAM", CinsiyetKisi = Cinsiyet.K, TC = 44444, DogumTarihi = DateTime.Now.AddYears(-32) },
                new Kisi { ID = 6, Ad = "Tarık", Soyad = "AYDIN", CinsiyetKisi = Cinsiyet.E, TC = 77777, DogumTarihi = DateTime.Now.AddYears(-38) }
                );
        }
    }
}
