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
    public class MaliHareketlerService
    {
        private MaliHareketRepo maliHareketRepo;
        private AidatRepo aidatRepo;
        private DonemRepo donemRepo;
        private HareketTipRepo hareketTipRepo;
        private KisiRepo kisiRepo;

        public MaliHareketlerService()
        {
            maliHareketRepo = new MaliHareketRepo();
            aidatRepo = new AidatRepo();
            donemRepo = new DonemRepo();
            hareketTipRepo = new HareketTipRepo();
            kisiRepo = new KisiRepo();
        }
        public int GuncelOdenmisAidatSayisi()
        {
            var guncelDonem = donemRepo.GetByMonthAndYear(DateTime.Now.Month, DateTime.Now.Year);
            return aidatRepo.GetAidatsByDonemId(guncelDonem.Id).Count();
        }
        public decimal GuncelOdenmisAidatMiktar()
        {
            aidatRepo.GetAll();
            var guncelDonem = donemRepo.GetByMonthAndYear(DateTime.Now.Month, DateTime.Now.Year);
            var guncelAidatlar = aidatRepo.GetAidatsByDonemId(guncelDonem.Id);
            var guncelAidatHareketIdList = guncelAidatlar.Select(x => x.HareketId).ToList();
            return maliHareketRepo.GetAll().Where(x => guncelAidatHareketIdList.Contains(x.Id)).Sum(y => y.Miktar);
        }

        public decimal ToplamOdenmisAidatMiktar()
        {
            var hareketTip = hareketTipRepo.GetByTanim("Aidat");
            return maliHareketRepo.GetAll().Where(x => x.TipId == hareketTip.Id).Sum(y => y.Miktar);
        }
        public decimal ToplamOdenmisBagisMiktar()
        {
            var hareketTip = hareketTipRepo.GetByTanim("Bağış");
            return maliHareketRepo.GetAll().Where(x => x.TipId == hareketTip.Id).Sum(y => y.Miktar);
        }
        public decimal ToplamCikanParaMiktar()
        {
            var hareketTip = hareketTipRepo.GetByTanim("Para Çekme");
            return -maliHareketRepo.GetAll().Where(x => x.TipId == hareketTip.Id).Sum(y => y.Miktar);
        }
        public decimal GuncelBakiye()
        {
            return maliHareketRepo.GetAll().Sum(y => y.Miktar);
        }
        public List<MaliHareketDTO> KisiIdyeGoreMaliHareketleriGetir(int kisiId)
        {
            Func<HareketTip, HareketTipDTO> converter = x => new HareketTipDTO() { TipId = x.Id, Tanim = x.Tanim };
            return maliHareketRepo.GetMaliHareketsByKisiId(kisiId).Select(x=>new MaliHareketDTO() {
                MaliHareketId = x.Id,
                Miktar = x.Miktar,
                Tip = converter(hareketTipRepo.GetById(x.TipId))
            }).ToList();
        }
        public List<AidatDTO> KisiIdyeGoreGecikmisAidatGetir(int kisiId)
        {
           
            var donemler = donemRepo.GetAll();
            var odenenler = aidatRepo.KisiyeGoreAidatGetir(kisiId).Select(x=>x.DonemId).ToList();
            var kisi = kisiRepo.GetById(kisiId);
            var odenmeyenler = donemler.Where(x => !odenenler.Contains(x.Id)).ToList();

            Func<Kisi, KisiDTO> kisiConverter = x => new KisiDTO()
            {
                Ad = kisi.Ad,
                Soyad = kisi.Soyad,
                EMail = kisi.EMail,
                KisiId = kisi.Id,
                Telefon = kisi.Telefon
            };
            Func<Donem, DonemDTO> donemConverter = x => new DonemDTO()
            {
                Ay = x.Ay,
                DonemId = x.Id,
                Tanim = x.Tanim,
                Yil = x.Yil
            };
            List<AidatDTO> odenmeyenAidatlar = new List<AidatDTO>();
            foreach (var item in odenmeyenler)
            {
                odenmeyenAidatlar.Add(new AidatDTO()
                {
                    Kisi = kisiConverter(kisi),
                    Donem = donemConverter(item) 
                });
            }
            return odenmeyenAidatlar;
        }
        public void AidatOde(AidatDTO aidat)
        {
            var aidatTip = hareketTipRepo.GetByTanim("Aidat");
            MaliHareket mHar = new MaliHareket()
            {
                KisiId = aidat.Kisi.KisiId,
                Miktar = aidat.MaliHareket.Miktar,
                TipId = aidatTip.Id
            };
            var hareketId = maliHareketRepo.Add(mHar);
            Aidat aid = new Aidat()
            {
                DonemId = aidat.Donem.DonemId,
                HareketId = hareketId,
                KisiId = aidat.Kisi.KisiId
            };

            aidatRepo.Add(aid);
        }
    }
}