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
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MedicineStockProvider(IMedicineStockRepository medicinestockrepository)
        {
            _medicinestockrepository = medicinestockrepository;
        }
        public IEnumerable<MedicineStockDTO> GetMedicineStock()
        {
            log.Info("Medicine Stock requested");
            var MedicineStockList = _medicinestockrepository.GetAll();
            log.Info("Medicine Stock Retrived");
            return MedicineStockList.ToList();
           
        }
    }
}
