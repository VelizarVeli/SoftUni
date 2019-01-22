using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
    using System;
    using Data;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid Data";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();


            var deserializedGameDtos = JsonConvert.DeserializeObject<GameDto[]>(jsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var validGames = new List<Game>();


            foreach (var gameDto in deserializedGameDtos)
            {
                var developerExists = validGames.Any(d => d.Developer.Name == gameDto.Developer);
                var genreExists = validGames.Any(g => g.Name == gameDto.Genre);

                if (!genreExists)
                {
                    var currentGenre = new Genre
                    {
                        Name = gameDto.Genre
                    };
                    context.Add(currentGenre);
                }

                if (!developerExists)
                {
                    var currentDeveloper = new Developer
                    {
                        Name = gameDto.Developer
                    };
                    context.Add(currentDeveloper);
                }

                //foreach (var tag in gameDto.Tags)
                //{
                //    var TagExists = validGames.Any(t => t.GameTags == gameDto.Tags);
                //}


                if (!IsValid(gameDto) || gameDto.Tags.Any(c => !IsValid(c)))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var releaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate//,
                                             // Developer = gameDto.Developer,
                                             // Genre = gameDto.Genre
                };

                foreach (var tagsDto in gameDto.Tags)
                {
                    var tag = new Tag
                    {
                        Name = tagsDto.Name
                    };

                  //  game.GameTags.Add(tag);
                    // cellsCount++;
                }


        //  departments.Add(department);

          //      sb.AppendLine($"Imported {department.Name} with {cellsCount} cells");
            }

       //     context.Departments.AddRange(departments);
        //    context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var deserializedUsers = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            var validUsers = new List<User>();

            var sb = new StringBuilder();

            foreach (var userDto in deserializedUsers)
            {
                if (!IsValid(userDto) || !IsValid(userDto.Cards))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var validCards = new List<Card>();
                var CardCounter = 0;
                foreach (var cardDto in userDto.Cards)
                {
                    var type = Enum.Parse<CardType>(cardDto.Type);
                    var card = new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = type
                    };
                    CardCounter++;
                    validCards.Add(card);
                }

                var validUser = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = validCards
                };
                // var validAnimal = Mapper.Map<Animal>(animalDto);

                validUsers.Add(validUser);
                sb.AppendLine($"Imported {validUser.Username} with {CardCounter} cards");
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            //var serializer = new XmlSerializer(typeof(PurchaseDto[]), new XmlRootAttribute("Purchases"));
            //var deserializedPurchases = (PurchaseDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            //var sb = new StringBuilder();

            //var validPurchases = new List<Purchase>();

            //foreach (var purchaseDto in deserializedPurchases)
            //{
            //    if (!IsValid(purchaseDto))
            //    {
            //        sb.AppendLine(FailureMessage);
            //        continue;
            //    }

            //    var productKey = purchaseDto.Key;
            //    var type = Enum.Parse<PurchaseType>(purchaseDto.Type);
            //    var date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            //    var currentCard = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

            //    var userWithCardN = context.Users.

            //        .Include(t => t.OriginStation)
            //        .Include(t => t.DestinationStation)
            //        .Include(t => t.Train)
            //        .ThenInclude(t => t.TrainSeats)
            //        .SingleOrDefault(t => t.OriginStation.Name == ticketDto.Trip.OriginStation &&
            //                              t.DestinationStation.Name == ticketDto.Trip.DestinationStation &&
            //                              t.DepartureTime == departureTime);

            //    var purchase = new Purchase
            //    {

            //        Type = type,
            //        ProductKey = productKey,
            //        Card = currentCard,
            //        Date = date
            //    };

            //    validPurchases.Add(purchase);
            //    sb.AppendLine($"Imported {} for {}");
            //}

            //context.Cards.AddRange(validCards);
            //context.SaveChanges();

            //var result = sb.ToString();
            //return result;

            return "";
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}