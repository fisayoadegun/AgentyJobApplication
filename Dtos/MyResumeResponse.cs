using AgentyJobApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentyJobApplication.Dtos
{
	public class MyResumeResponse
	{
		public MyResume resume { get; set; }
		public string ReturnMessage { get; set; }
	}
}
