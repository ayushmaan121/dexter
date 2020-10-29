using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dexterAPI.Models
{
    public partial class ChangeObject
    {
        public bool ContainHeader { get; set; }
        public bool ContainBody { get; set; }
        public bool ContainFooter { get; set; }
        public string OrgNameHeader { get; set; }
        public string OrgNameFooter { get; set; }
    }
}
