using DernekYonetim.BLL.DTOs;
using DernekYonetim.DAL.Entities;
using DernekYonetim.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.BLL
{
    public class UyeService
    {
        private IRepo<Uye> uyeRepo;
        private IRepo<Kisi> kisiRepo;

        public UyeService()
        {
            kisiRepo = new KisiRepo();
            uyeRepo = new UyeRepo();
        }

        public UyeService(IRepo<Uye> repoU)
        {
            kisiRepo = new KisiRepo();
            uyeRepo = repoU;
        }
        public UyeService(IRepo<Uye> repoU,IRepo<Kisi> repoK)
        {
            kisiRepo = repoK;
            uyeRepo = repoU;
        }

        public int AktifUyeSayisi()
        {
           return uyeRepo.GetAll().Where(uye => uye.AktifMi == true && uye.UyelikBitisTarihi == null).Count();
        }
        public int BuAykiUyeSayisi()
        {
            return uyeRepo.GetAll().Where(uye => uye.UyelikBaslangicTarihi.Month == DateTime.Now.Month && uye.UyelikBaslangicTarihi.Year == DateTime.Now.Year).Count();
        }
        public List<UyeDTO> UyeListesi()
        {
            var uyeEntities = uyeRepo.GetAll();
            var kisiEntities = kisiRepo.GetAll();

            List<UyeDTO> uyeDtos = new List<UyeDTO>();
            foreach (var item in uyeEntities)
            {
                var kisi = kisiEntities.SingleOrDefault(x => x.Id == item.KisiId);
                uyeDtos.Add(new UyeDTO()
                {
                    UyeId = item.Id,
                    UyelikBaslangicTarihi = item.UyelikBaslangicTarihi,
                    UyelikBitisTarihi = item.UyelikBitisTarihi,
                    AktifMi = item.AktifMi,
                    KisiId = kisi.Id,
                    Ad = kisi.Ad,
                    Soyad = kisi.Soyad,
                    EMail = kisi.EMail,
                    Telefon = kisi.Telefon
                });
            }
            return uyeDtos;
        }
        public void UyeGuncelle(UyeDTO item)
        {
            var kisi = new Kisi()
            {
                Id = item.KisiId,
                Ad = item.Ad,
                Soyad = item.Soyad,
                Telefon = item.Telefon,
                EMail = item.EMail
            };
            var uye = new Uye()
            {
                Id = item.UyeId,
                KisiId = item.KisiId,
                AktifMi = item.AktifMi,
                UyelikBaslangicTarihi = item.UyelikBaslangicTarihi,
                UyelikBitisTarihi = item.UyelikBitisTarihi
            };
            kisiRepo.Update(kisi);
            uyeRepo.Update(uye);
        }
        public UyeDTO IdyeGoreUyeGetir(int UyeId)
        {
            var uye = uyeRepo.GetById(UyeId);
            var kisi = kisiRepo.GetById(uye.KisiId);
            var uyeDto = new UyeDTO()
            {
                Ad = kisi.Ad,
                Soyad = kisi.Soyad,
                Telefon = kisi.Telefon,
                KisiId = kisi.Id,
                EMail = kisi.EMail,
                AktifMi = uye.AktifMi,
                UyeId = uye.Id,
                UyelikBaslangicTarihi = uye.UyelikBaslangicTarihi,
                UyelikBitisTarihi = uye.UyelikBitisTarihi
            };
            return uyeDto;
        }
    }
}
