using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierFuerVier.Models
{
    public class Beer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}