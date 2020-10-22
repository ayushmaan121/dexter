using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dexterAPI.Services
{
    public class Action: IAction
    {
        public JsonResult GenerateZip()
        {
            return new JsonResult("hi");
        }
    }
}
