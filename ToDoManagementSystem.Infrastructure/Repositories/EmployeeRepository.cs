using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ToDoManagementSystem.Application.Interfaces.Repositories;
using ToDoManagementSystem.Core.Entities;
using ToDoManagementSystem.Infrastructure.Configuration;

namespace ToDoManagementSystem.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMongoCollection<Employee> _collection;

        public EmployeeRepository(IMongoClient client, IOptions<MongoDbSettings> settings)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Employee>("Employees");
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _collection.InsertOneAsync(employee);
        }

        public async Task<Employee> GetByEmailAsync(string employeeEmail)
        {
            return await _collection.Find(e=>e.Email == employeeEmail).FirstOrDefaultAsync();
        }

        public async Task<Employee> GetByIdAsync(string employeeId)
        {
            return await _collection.Find(e=>e.Id==employeeId).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeAsync(string employeeId, Employee employee)
        {
            await _collection.ReplaceOneAsync(e => e.Id == employeeId, employee);
        }
    }
}
