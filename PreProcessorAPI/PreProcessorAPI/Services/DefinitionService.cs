using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PreProcessorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreProcessorAPI.DB
{
    public class DefinitionService : IDefinitionService
    {
        private readonly IMongoDatabase _db;

        public DefinitionService(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Definition> Definition => _db.GetCollection<Definition>("Definition");

        public async Task<IEnumerable<Definition>> GetAll()
        {
            return await Definition
                            .Find(_ => true)
                            .ToListAsync();
        }
    }

    public interface IDefinitionService
    {
        IMongoCollection<Definition> Definition { get; }

        Task<IEnumerable<Definition>> GetAll();
    }
}
