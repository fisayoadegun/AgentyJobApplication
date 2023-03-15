using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentyJobApplication.Models
{
	public class AgentyJobApplicationDatabaseSettings
	{
		public string ConnectionString { get; set; } = null!;

		public string DatabaseName { get; set; } = null!;

		public string AgentyJobApplicationCollectionName { get; set; } = null!;
	}
}
