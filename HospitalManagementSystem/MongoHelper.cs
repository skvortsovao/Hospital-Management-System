using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    using MongoDB.Driver;

    public static class MongoHelper
    {
        private static readonly IMongoClient client = new MongoClient("YOUR_MONGO_CONNECTION_STRING_HERE");
        private static readonly MongoClient client = new MongoClient(connectionString);
        private static readonly IMongoDatabase db = client.GetDatabase("HospitalSystem");

        public static IMongoCollection<User> UsersCollection => db.GetCollection<User>("Users");
    }
}
