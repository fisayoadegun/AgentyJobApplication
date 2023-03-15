using AgentyJobApplication.Dtos;
using AgentyJobApplication.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentyJobApplication.Services
{
	public class MyResumeService
	{
		private readonly IMongoCollection<MyResume> _myresumeCollection;

		public MyResumeService(IOptions<AgentyJobApplicationDatabaseSettings> agentyjobapplicationDatabaseSettings)
		{
			var mongoClient = new MongoClient(agentyjobapplicationDatabaseSettings.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(agentyjobapplicationDatabaseSettings.Value.DatabaseName);
			_myresumeCollection = mongoDatabase.GetCollection<MyResume>(agentyjobapplicationDatabaseSettings.Value.AgentyJobApplicationCollectionName);

		}

		public async Task<MyResumeCreate> CreateAsync(MyResume myResume)
		{
			try
			{
				var response = new MyResumeCreate();
				await _myresumeCollection.InsertOneAsync(myResume);
				response.resumeid = myResume.Id;
				response.ReturnMessage = "Resume Added Successfully";
				return response;
			}
			catch (Exception ex)
			{

				return new MyResumeCreate()
				{
					ReturnMessage = ex.Message.ToString()
				};
			}
		}

		public async Task<MyResumeResponse> GetAsync(string id)
		{
			try
			{
				var response = new MyResumeResponse();
				var resume = await _myresumeCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
				response.resume = resume;
				return response;
			}
			catch (Exception ex)
			{

				return new MyResumeResponse()
				{
					ReturnMessage = ex.Message.ToString()
				};
			}
		}		
	}
}
