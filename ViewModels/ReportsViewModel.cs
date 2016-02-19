using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC5CentrexDataProcessor.Models;

namespace MVC5CentrexDataProcessor.ViewModels
{
    public class ReportsViewModel
    {
        public IEnumerable<Record09> Record09S { get; set; }
        public IEnumerable<Record10> Record10S { get; set; }  

    }
}