using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Globalization;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace NetsisSQLWebApi.Controllers
{
    public class StokController : ApiController
    {
        
        private const string token= "61d1bf81482adf2ec6db5cbb703649b9e0770bb44b168d34a19cd2ecfb379a67c75c917023d603091f73e0b386b4c1e1134eb5f06fcc17b12334017c9c3fe8e7";
        public NetsisEntities db = null;
       


        public StokController()
        {

            db = new NetsisEntities();
            
          
        }
    
        public IEnumerable<STOK_RAPOR_Result> Get()
        {

            return db.STOK_RAPOR();
        }
        
     
        [HttpGet]
        [Route("token/" + token + "/stok/{st_kod}")]
        
        public IEnumerable<STOK_AL_Result> Get(string st_kod)
        {

            return db.STOK_AL(st_kod);
        }

   

        [HttpGet]
        [Route("token/" + token + "/stok/{st_kod}/{miktar}")]

        public IEnumerable<STOK_DUS_Result> Get(string st_kod,decimal miktar)
        {

            return db.STOK_DUS(st_kod,miktar);
        }
        
        [HttpGet]
        [Route("token/" + token + "/stok/cinsiyet/{cins}")]

        public IEnumerable<STOK_AL_CINS_Result> Get(int cins)
        {
            string cins_yazi;

            if (cins == 1)
            {
                cins_yazi = "ERKEK";
            }
            else if (cins == 0)
            {
                cins_yazi = "UNISEX";
            }
            else if (cins == 2)
            {
                cins_yazi = "KIZ";
            }
            else
            {
                cins_yazi = "";
            }

            return db.STOK_AL_CINS(cins_yazi);
        }

        
        [HttpGet]
       // [Route("token/" + token + "/stok/cari_ekle/{cari_kod}/{cari_tel}/{cari_il}/{cari_isim}/{cari_adres}/{cari_ilce}/{email}/{tc_no}/{kullanici}")]
        [Route("token/" + token + "/stok/cari_ekle/")]
        
        public IEnumerable<CARI_EKLE_Result> Get(string cari_kod, string cari_tel, string cari_il, string cari_isim, string cari_adres, string cari_ilce, string email, string tc_no, string kullanici)

        {
            DateTime zaman = DateTime.Now;
            string tarih = zaman.ToString("yyyy-MM-dd HH:mm:ss");
           /*
            CariEklePrm degerler = new CariEklePrm
            {
                CariKod = cari_kod,
                CariTel = cari_tel,
                CariIl = cari_il,
                CariIsim = cari_isim,
                CariAdres = cari_adres,
                CariIlce = cari_ilce,
                Email = email,
                TcNo = tc_no,
                Kullanici = kullanici,
                Tarih = tarih
            };
           */
           

                
            return db.CARI_EKLE( cari_kod,  cari_tel,  cari_il,  cari_isim,  cari_adres,  cari_ilce,  email,  tc_no,  kullanici, tarih);
        }


    }

    public class CariEklePrm
    {
        public string CariKod { get; set; }
        public string CariTel { get; set; }
        public string CariIl { get; set; }
        public string CariIsim { get; set; }
        public string CariAdres { get; set; }
        public string CariIlce { get; set; }
        public string Email { get; set; }
        public string TcNo { get; set; }
        public string Kullanici { get; set; }
        public string Tarih { get; set; }
    }

   
}
