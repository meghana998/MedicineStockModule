using MedicineStockModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStockModule.Repository
{
    public class MedicineStockRepository:IMedicineStockRepository
    {
        private static readonly List<MedicineStock> MedicineStockInformation = new List<MedicineStock>() {
            new MedicineStock{Name="Medicine1",
                              Chemical_Composition=new List<string>{"chemical1","chemical2"},
                              Target_Ailment="Orthopaedics",
                              Date_Of_Expiry=DateTime.Parse("10-10-2021"),
                              Number_Of_Tablets_In_Stock=50},
            new MedicineStock{Name="Medicine2",
                              Chemical_Composition=new List<string>{"chemical3","chemical2"},
                              Target_Ailment="General",
                              Date_Of_Expiry=DateTime.Parse("10-09-2021"),
                              Number_Of_Tablets_In_Stock=50},
            new MedicineStock{Name="Medicine3",
                              Chemical_Composition=new List<string>{"chemical1","chemical2"},
                              Target_Ailment="Gynecology",
                              Date_Of_Expiry=DateTime.Parse("10-10-2021"),
                              Number_Of_Tablets_In_Stock=50},
            new MedicineStock{Name="Medicine4",
                              Chemical_Composition=new List<string>{"chemical1","chemical2"},
                              Target_Ailment="Orthopaedics",
                              Date_Of_Expiry=DateTime.Parse("10-01-2021"),
                              Number_Of_Tablets_In_Stock=50},
            new MedicineStock{Name="Medicine5",
                              Chemical_Composition=new List<string>{"chemical6","chemical5"},
                              Target_Ailment="Gynecology",
                              Date_Of_Expiry=DateTime.Parse("10-10-2021"),
                              Number_Of_Tablets_In_Stock=50},

        };

        public IEnumerable<MedicineStock> GetAll()
        {
            var MedicineStocklist = from Medicine in MedicineStockInformation select Medicine;
            return MedicineStocklist.ToList();
        }
    }
}
