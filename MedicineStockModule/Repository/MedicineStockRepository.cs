using MedicineStockModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStockModule.Repository
{
    public class MedicineStockRepository:IMedicineStockRepository
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly List<MedicineStockDTO> MedicineStockInformation = new List<MedicineStockDTO>() {
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
        
        public IEnumerable<MedicineStockDTO> GetAll()
        {
            
            var MedicineStocklist = from Medicine in MedicineStockInformation select Medicine;
            return MedicineStocklist.ToList();
           log.Info("Medicine Stock retreived from godown");
        }
    }
}
