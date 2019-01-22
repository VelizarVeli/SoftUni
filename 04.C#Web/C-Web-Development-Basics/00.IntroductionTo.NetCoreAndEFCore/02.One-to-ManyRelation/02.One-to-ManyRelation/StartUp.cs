using System;
using OneToManyRelations.Data;

namespace _02.One_to_ManyRelation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new RelationsDbContext();
            context.Database.EnsureCreated();
        }
    }
}
