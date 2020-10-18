using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudCodeFirst.Models
{
    public class ListEntry
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public double Quantidade { get; set; }
        public string Unidade { get; set; }
    }
}