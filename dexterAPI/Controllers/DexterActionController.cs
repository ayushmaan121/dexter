using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dexterAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace dexterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DexterActionController : Controller
    {
        private IDexterAction _action;
        public DexterActionController(IDexterAction action)
        {
            _action = action;
        }

        [HttpGet]
        public IActionResult GenerateZip()
        {
            return _action.GenerateZip();
        }
    }
}
