using MedicineStockModule.Models;
using MedicineStockModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStockModule.Providers
{
    public class MedicineStockProvider : IMedicineStockProvider
    {
        private readonly IMedicineStockRepository _medicinestockrepository;
        public MedicineStockProvider(IMedicineStockRepository medicinestockrepository)
        {
            _medicinestockrepository = medicinestockrepository;
        }
        public IEnumerable<MedicineStock> GetMedicineStock()
        {
            var MedicineStockList = _medicinestockrepository.GetAll();
            return MedicineStockList.ToList();
           
        }
    }
}
