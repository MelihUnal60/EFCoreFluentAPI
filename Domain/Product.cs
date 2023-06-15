using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product:BaseEntity
    {
        //[StringLength(128)]  //Data annotations
        //[Required(AllowEmptyStrings = true)] // dbde alanı null olabilecek şekilde ayarlamak

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        //[ForeignKey("Category")] clean architecture kurallarına aykırı bir annotation. Domain katmanında db tarafı için özel bir kod bulundurulmamalı.

        public int CategoryId { get; set; }

        public float TAX { get; set; }

        public decimal IncludeTax =>  Price* Convert.ToDecimal(TAX);

        public Category Category { get; set; }  //navigation property

        
    }
}
