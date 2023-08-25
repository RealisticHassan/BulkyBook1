using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models.ViewModels
{
    public class ProductVM
    {

        public ProductVM()
        {


        }

        public Product product { get; set; }

        public IEnumerable<SelectListItem> CatList { get; set; }
        public IEnumerable<SelectListItem> CTList { get; set; }


    }
}
