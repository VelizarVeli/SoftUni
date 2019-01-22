using System.Linq;
using Newtonsoft.Json;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            //    var games[] = context.Games.AddRange();
            //    foreach (var game in games)
            //    {

            //    }

            //    var games = context.Games
            //        .Where(g => g.Genre == phoneNumber)
            //        .Select(a => new
            //        {
            //            OwnerName = a.Passport.OwnerName,
            //            AnimalName = a.Name,
            //            Age = a.Age,
            //            SerialNumber = a.Passport.SerialNumber,
            //            RegisteredOn = a.Passport.RegistrationDate
            //        })
            //        .OrderBy(a => a.Age)
            //        .ThenBy(a => a.SerialNumber)
            //        .ToArray();

		    //    string result = JsonConvert.SerializeObject(games, Formatting.Indented, new JsonSerializerSettings());
		    //    return result;


		    throw new NotImplementedException();
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			throw new NotImplementedException();
		}
	}
}