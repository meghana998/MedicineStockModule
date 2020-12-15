using Castle.Core.Internal;
using MedicineStockModule.Controllers;
using MedicineStockModule.Models;
using MedicineStockModule.Providers;
using MedicineStockModule.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicineStockModuleTest
{
    [TestFixture]
    public class Tests
    {
       private Mock<IMedicineStockProvider> _pro;
       private Mock<IMedicineStockRepository> _repo;
        public IMedicineStockRepository repo;
        public IMedicineStockProvider pro;
         List<MedicineStockDTO> medicineStock;        
        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IMedicineStockRepository>();
            _pro = new Mock<IMedicineStockProvider>();
            medicineStock = new List<MedicineStockDTO> {
           new MedicineStockDTO
            {
                Name = "Medicine1",
                ChemicalComposition = new List<string> { "chemical1", "chemical2" },
                TargetAilment = "Orthopaedics",
                DateOfExpiry = DateTime.Parse("10-10-2021"),
                NumberOfTabletsInStock = 50
            },
            new MedicineStockDTO
            {
                Name = "Medicine2",
                ChemicalComposition = new List<string> { "chemical3", "chemical2" },
                TargetAilment = "General",
                DateOfExpiry = DateTime.Parse("10-09-2021"),
                NumberOfTabletsInStock = 50
            },
            new MedicineStockDTO
            {
                Name = "Medicine3",
                ChemicalComposition = new List<string> { "chemical1", "chemical2" },
                TargetAilment = "Gynecology",
                DateOfExpiry = DateTime.Parse("10-10-2021"),
                NumberOfTabletsInStock = 50
            },
            new MedicineStockDTO
            {
                Name = "Medicine4",
                ChemicalComposition = new List<string> { "chemical1", "chemical2" },
                TargetAilment = "Gynecology",
                DateOfExpiry = DateTime.Parse("10-10-2021"),
                NumberOfTabletsInStock = 50
            },
            new MedicineStockDTO
            {
                Name = "Medicine5",
                ChemicalComposition = new List<string> { "chemical1", "chemical2" },
                TargetAilment = "General",
                DateOfExpiry = DateTime.Parse("10-10-2021"),
                NumberOfTabletsInStock = 50
            },
            };
            _pro.Setup(x => x.GetMedicineStock()).Returns(medicineStock);
            pro = _pro.Object;
            _repo.Setup(m => m.GetAll()).Returns(medicineStock);
            repo = _repo.Object;
        
        }


        [Test]
        public void MedicineStockInfoTest()
        {
           IEnumerable<MedicineStockDTO> answer = pro.GetMedicineStock();
            Assert.AreEqual(medicineStock, answer);
            Assert.Pass();
        }

        [Test]
        public void MedicineStockInfoTest_PassCase_Service()
        {
            IEnumerable<MedicineStockDTO> result =pro.GetMedicineStock();
            Assert.IsNotNull(result);
        }
        [Test]
        public void MedicineStockInfoTest_FailCase_Service()
        {
            medicineStock = null;
            _pro.Setup(x => x.GetMedicineStock()).Returns(medicineStock);
            pro = _pro.Object;
            List<MedicineStock> result = (List<MedicineStock>)pro.GetMedicineStock();
            Assert.IsNull(result);
        }
        [Test]
        public void MedicineStockInfoTest_PassCase_Repository()
        {
            IEnumerable<MedicineStockDTO> result = repo.GetAll();
            Assert.IsNotNull(result);
        }
        [Test]
        public void MedicineStockInfoTest_FailCase_Repository()
        {
            medicineStock = null;
            _repo.Setup(m => m.GetAll()).Returns(medicineStock);
            repo = _repo.Object;
            List<MedicineStock> result = (List<MedicineStock>)repo.GetAll();
            Assert.IsNull(result);
        }
        [Test]
        public void GetMedicineStockinfo_ValidInput_OkResult()
        {
            _pro.Setup(x => x.GetMedicineStock()).Returns(medicineStock);
            var controller = new MedicineStockInformationController(_pro.Object);
            var data = controller.Get();
            var res = data as OkObjectResult;
            Assert.AreEqual(200, res.StatusCode);
        }


    }
}