﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Common
{
	public class ResultDto
	{
        public bool IsSuccess { get; set; }
		public string Message { get; set; }
    }

	public class ResultDto<T>
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public T Result { get; set; }
	}
}
