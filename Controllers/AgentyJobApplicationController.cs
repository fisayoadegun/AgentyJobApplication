using AgentyJobApplication.Dtos;
using AgentyJobApplication.Models;
using AgentyJobApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentyJobApplication.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AgentyJobApplicationController : ControllerBase
	{
		private readonly MyResumeService _resumeService;

		public AgentyJobApplicationController(MyResumeService resumeService)
		{
			_resumeService = resumeService;
		}


		[HttpPost("[action]")]
		public async Task<MyResumeCreate> Post(MyResume newResume)
		{
			var resume = await _resumeService.CreateAsync(newResume);

			return resume;
		}

		[HttpGet("[action]/{id}")]
		public async Task<ActionResult<MyResumeResponse>> Get(string id)
		{
			var resume = await _resumeService.GetAsync(id);

			if (resume is null)
			{
				return NotFound();
			}

			return resume;
		}		
	}
}
