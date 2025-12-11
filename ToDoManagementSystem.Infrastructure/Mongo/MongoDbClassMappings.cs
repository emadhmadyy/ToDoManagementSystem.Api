using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using ToDoManagementSystem.Core.Entities;

namespace ToDoManagementSystem.Infrastructure.Mongo
{
    public class MongoDbClassMappings
    {
        public static void Register()
        {
            // Employee mapping
            if (!BsonClassMap.IsClassMapRegistered(typeof(Employee)))
            {
                BsonClassMap.RegisterClassMap<Employee>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdProperty(e => e.Id)
                      .SetIdGenerator(StringObjectIdGenerator.Instance)
                      .SetSerializer(new StringSerializer(BsonType.ObjectId));
                });
            }
        }

    }
}
