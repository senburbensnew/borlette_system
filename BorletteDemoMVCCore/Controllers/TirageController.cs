using BorletteDTO;
using BorletteRepository.Factory;
using Microsoft.AspNetCore.Mvc;

namespace BorletteDemoMVCCore.Controllers
{
    public class TirageController : Controller
    {
        private IDAOFactory _factory;
        public TirageController(IDAOFactory fact) { 
            _factory = fact;
        }

        public IActionResult Index()
        {
           List<Tirage> tirages= _factory.CreateInstanceDAOTirage().GetAllTirage();
           return View(tirages);
        }
    }
}
