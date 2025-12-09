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

        public async Task<Employee> GetByEmailAsync(string employeeEmail)
        {
            return await _collection.Find(e => e.Email == employeeEmail).FirstOrDefaultAsync();
        }

        public async Task<Employee> GetByIdAsync(string employeeId)
        {
            return await _collection.Find(e => e.Id == employeeId).FirstOrDefaultAsync();
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _collection.InsertOneAsync(employee);
        }

        public async Task UpdateEmployeeAsync(string employeeId, Employee employee)
        {
            await _collection.ReplaceOneAsync(e => e.Id == employeeId, employee);
        }

        public async Task AddEmployeeTodoAsync(string employeeId, Todo todo)
        {
            var update = Builders<Employee>.Update.Push(e => e.Todos, todo);

            await _collection.UpdateOneAsync(
                e => e.Id == employeeId,
                update
            );

        }

        public async Task DeleteEmployeeTodoAsync(string employeeId, string todoId)
        {
            var update = Builders<Employee>.Update.PullFilter(
                e => e.Todos,
                t => t.Id == todoId
                );

            await _collection.UpdateOneAsync(
                e => e.Id == employeeId,
                update
                );

        }


        public async Task UpdateEmployeeTodoAsync(string employeeId, Todo todo)
        {
            var filter = Builders<Employee>.Filter.And(
                Builders<Employee>.Filter.Eq(e => e.Id, employeeId),
                Builders<Employee>.Filter.Eq("Todos.Id", todo.Id)
                );

            var update = Builders<Employee>.Update
                .Set("Todos.$.Title", todo.Title)
                .Set("Todos.$.Description", todo.Description)
                .Set("Todos.$.DueDate", todo.DueDate)
                .Set("Todos.$.Priority", todo.Priority)
                .Set("Todos.$.Status", todo.Status)
                .Set("Todos.$.UpdatedAt", todo.UpdatedAt);

            await _collection.UpdateOneAsync(filter, update);
        }
    }
}
