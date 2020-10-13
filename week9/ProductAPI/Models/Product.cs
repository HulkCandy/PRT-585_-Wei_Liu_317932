using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class Product
    {
		[Key]
		public int ProductID { get; set; }

		[Required]
		public string ProductName { get; set; }

		[Required]
		public string ProductQuantity{ get; set; }


	}
}
