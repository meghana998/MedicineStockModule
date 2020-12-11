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
            new MedicineStockDTO{Name="Medicine1",
                              Chemical_Composition=new List<string>{"chemical1","chemical2"},
                              Target_Ailment="Orthopaedics",
                              Date_Of_Expiry=DateTime.Parse("10-10-2021"),
                              Number_Of_Tablets_In_Stock=50},
            new MedicineStockDTO{Name="Medicine2",
                              Chemical_Composition=new List<string>{"chemical3","chemical2"},
                              Target_Ailment="General",
                              Date_Of_Expiry=DateTime.Parse("10-09-2021"),
                              Number_Of_Tablets_In_Stock=50},
            new MedicineStockDTO{Name="Medicine3",
                              Chemical_Composition=new List<string>{"chemical1","chemical2"},
                              Target_Ailment="Gynecology",
                              Date_Of_Expiry=DateTime.Parse("10-10-2021"),
                              Number_Of_Tablets_In_Stock=50},
            new MedicineStockDTO{Name="Medicine4",
                              Chemical_Composition=new List<string>{"chemical1","chemical2"},
                              Target_Ailment="Orthopaedics",
                              Date_Of_Expiry=DateTime.Parse("10-01-2021"),
                              Number_Of_Tablets_In_Stock=50},
            new MedicineStockDTO{Name="Medicine5",
                              Chemical_Composition=new List<string>{"chemical6","chemical5"},
                              Target_Ailment="Gynecology",
                              Date_Of_Expiry=DateTime.Parse("10-10-2021"),
                              Number_Of_Tablets_In_Stock=50},

        };

        public IEnumerable<MedicineStockDTO> GetAll()
        {
            
            var MedicineStocklist = from Medicine in MedicineStockInformation select Medicine;
            return MedicineStocklist.ToList();
            log.Info("Medicine Stock retreived from godown");
        }
    }
}
