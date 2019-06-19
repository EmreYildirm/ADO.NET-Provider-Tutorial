using System;
using System.Collections.Generic;
using DernekYonetim.BLL.Tests.Fakes;
using DernekYonetim.BLL.Tests.Stubs;
using DernekYonetim.DAL.Entities;
using DernekYonetim.DAL.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DernekYonetim.BLL.Tests
{
    [TestClass]
    public class UyeServiceShould
    {
        [TestMethod]
        public void GetAktifUyeSayısı_3_WithStub()
        {
            var uyeRepoStub = new UyeRepoStub();
            UyeService uyeService = new UyeService(uyeRepoStub);

            var actual = uyeService.AktifUyeSayisi();
            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBuAykiUyeSayısı_2_WithStub()
        {
            var uyeRepoStub = new UyeRepoStub();
            UyeService uyeService = new UyeService(uyeRepoStub);

            var actual = uyeService.BuAykiUyeSayisi();
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAktifUyeSayısı_3_WithFake()
        {
            var uyeRepoFake = new UyeRepoFake();
            UyeService uyeService = new UyeService(uyeRepoFake);

            var actual = uyeService.AktifUyeSayisi();
            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBuAykiUyeSayısı_1_WithFake()
        {
            var uyeRepoFake = new UyeRepoFake();
            UyeService uyeService = new UyeService(uyeRepoFake);

            var actual = uyeService.BuAykiUyeSayisi();
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAktifUyeSayısı_3_WithMock()
        {
          
            List<Uye> uyelerList = new List<Uye>();
            Uye uye1 = new Uye()
            {
                Id = 1,
                AktifMi = true,
                UyelikBaslangicTarihi = new DateTime(1991, 1, 1),
                UyelikBitisTarihi = null,
                KisiId = 1,
            };
            Uye uye2 = new Uye()
            {
                Id = 2,
                AktifMi = true,
                UyelikBaslangicTarihi = new DateTime(1993, 2, 12),
                UyelikBitisTarihi = null,
                KisiId = 2,
            };
            Uye uye3 = new Uye()
            {
                Id = 3,
                AktifMi = true,
                UyelikBaslangicTarihi = DateTime.Now,
                UyelikBitisTarihi = null,
                KisiId = 3,
            };
            Uye uye4 = new Uye()
            {
                Id = 4,
                AktifMi = false,
                UyelikBaslangicTarihi = new DateTime(1990, 3, 5),
                UyelikBitisTarihi = new DateTime(2011, 1, 1),
                KisiId = 5,
            };
            uyelerList.Add(uye1);
            uyelerList.Add(uye2);
            uyelerList.Add(uye3);
            uyelerList.Add(uye4);

            Mock<IRepo<Uye>> uyeRepoMock = new Mock<IRepo<Uye>>();
            uyeRepoMock.Setup(x => x.GetAll()).Returns(uyelerList);

            UyeService uyeService = new UyeService(uyeRepoMock.Object);
            var actual = uyeService.AktifUyeSayisi();
            var expected = 3;
            Assert.AreEqual(expected, actual);
          
        }
        
        [TestMethod]
        public void CallGetAllinRepo()
        {
            Mock<IRepo<Uye>> uyeRepoMock = new Mock<IRepo<Uye>>();
            UyeService uyeService = new UyeService(uyeRepoMock.Object);
            uyeRepoMock.Setup(x => x.GetAll()).Returns(new List<Uye>());
            //uyeService.Invoking<Action<>>
        }
    }
}
