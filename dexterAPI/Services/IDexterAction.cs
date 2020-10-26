using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dexterAPI.Services
{
   public interface IDexterAction
    {
        public JsonResult GenerateZip();
    }
}
