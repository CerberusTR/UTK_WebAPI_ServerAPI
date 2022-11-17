using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WepAPI_DB
{
    public enum Cinsiyet {E,K}
    public class Kisi
    {
        public int ID { get; set; }
        public int TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public Cinsiyet CinsiyetKisi { get; set; }
      
    }
}
