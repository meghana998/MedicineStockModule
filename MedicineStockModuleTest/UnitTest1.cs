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
            new MedicineStockDTO{Name="Aspirin",
                              ChemicalComposition=new List<string>{"Acetylsalicyclic acid"},
                              TargetAilment="General",
                              DateOfExpiry=DateTime.Parse("22-10-2021"),
                              NumberOfTabletsInStock=250},
            new MedicineStockDTO{Name="Codeine",
                              ChemicalComposition=new List<string>{"serotonin"},
                              TargetAilment="Orthopaedics",
                              DateOfExpiry=DateTime.Parse("10-09-2021"),
                              NumberOfTabletsInStock=150},
            new MedicineStockDTO{Name="Mifepristone",
                              ChemicalComposition=new List<string>{"methotrexate"},
                              TargetAilment="Gynecology",
                              DateOfExpiry=DateTime.Parse("10-10-2021"),
                              NumberOfTabletsInStock=100},
            new MedicineStockDTO{Name="Combiflam",
                              ChemicalComposition=new List<string>{"Acetaminophen"},
                              TargetAilment="Orthopaedics",
                              DateOfExpiry=DateTime.Parse("10-01-2021"),
                              NumberOfTabletsInStock=50},
            new MedicineStockDTO{Name="Misoprostol",
                              ChemicalComposition=new List<string>{"Adenylate cyclase"},
                              TargetAilment="Gynecology",
                              DateOfExpiry=DateTime.Parse("10-10-2021"),
                              NumberOfTabletsInStock=50},
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