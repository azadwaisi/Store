﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Product
	{
        public Guid Id { get; set; }
		public string Name { get; set; }
		public string Barcode { get; set; }
		public DateTime? CreatedDate { get; set; }
		public Guid? CreateUserId { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public Guid? ModifiedUserId { get; set; }
	}
}
