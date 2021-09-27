using Infrastructure.ScheduleModel;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ScheduleRepository
    {
        private const string ConnectionString = "AccountEndpoint=https://at-petshop.documents.azure.com:443/;AccountKey=cZsHexAVqOeDQXG4DyrdqEzoR0lxVUvSLVmP7VfEPTVomOfoacDtJMGFZsRC8CqPSUbTcLi6CsjEiWKawzk6JQ==;";
        private const string Database = "at-petshop";
        private const string Container = "schedules";

        private CosmosClient CosmosClient { get; set; }

        public ScheduleRepository()
        {
            this.CosmosClient = new CosmosClient(ConnectionString);
        }

        public List<Schedule> GetAllSchedules()
        {
            var container = this.CosmosClient.GetContainer(Database, Container);

            QueryDefinition queryDefinition = new QueryDefinition("SELECT * FROM c");

            var result = new List<Schedule>();

            var queryResult = container.GetItemQueryIterator<Schedule>(queryDefinition);

            while (queryResult.HasMoreResults)
            {
                FeedResponse<Schedule> currentResultSet = queryResult.ReadNextAsync().Result;
                result.AddRange(currentResultSet.Resource);
            }

            return result;
        }

        public Schedule GetById(Guid id)
        {
            var container = this.CosmosClient.GetContainer(Database, Container);

            QueryDefinition queryDefinition = new QueryDefinition($"SELECT * FROM c where c.id = '{id}'");

            var result = new List<Schedule>();

            var queryResult = container.GetItemQueryIterator<Schedule>(queryDefinition);

            while (queryResult.HasMoreResults)
            {
                FeedResponse<Schedule> currentResultSet = queryResult.ReadNextAsync().Result;
                result.AddRange(currentResultSet.Resource);
            }

            return result.FirstOrDefault();
        }

        public async Task Create(Schedule obj)
        {
            var container = this.CosmosClient.GetContainer(Database, Container);
            await container.CreateItemAsync<Schedule>(obj, new PartitionKey(obj.PartitionKey));
        }

        public async Task Delete(Schedule obj)
        {
            var container = this.CosmosClient.GetContainer(Database, Container);
            await container.DeleteItemAsync<Schedule>(obj.Id.ToString(), new PartitionKey(obj.PartitionKey));
        }

        public async Task Update(Schedule obj)
        {
            var container = this.CosmosClient.GetContainer(Database, Container);
            await container.ReplaceItemAsync<Schedule>(obj, obj.Id.ToString(), new PartitionKey(obj.PartitionKey));
        }

    }
}
