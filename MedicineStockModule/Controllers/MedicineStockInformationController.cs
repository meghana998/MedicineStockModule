using MedicineStockModule.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using log4net;
using log4net.Config;


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4net.config", Watch = true)]
namespace MedicineStockModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicineStockInformationController : Controller
    {
        
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //creating provider layer interface object
        private readonly IMedicineStockProvider iMedicineStock;
        public MedicineStockInformationController(IMedicineStockProvider _imedicinestock)
        {
            this.iMedicineStock = _imedicinestock;
        }

        //hhtp get method to get all the medicine stock list 
        [HttpGet]
        public IActionResult Get()
        {
            BasicConfigurator.Configure();
            log.Info("All the Medicine Stock from the Godown are getting retrived");
            return Ok(iMedicineStock.GetMedicineStock());
        }
    }
}
