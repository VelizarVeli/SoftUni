using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using Newtonsoft.Json;
using PetClinic.DataProcessor.Dto.Import;
using PetClinic.Models;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace PetClinic.DataProcessor
{
    using System;
    using System.Xml.Linq;
    using PetClinic.Data;

    public class Deserializer
    {
        private const string FailureMessage = "Error: Invalid data.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var deserializedAnimalAids = JsonConvert.DeserializeObject<AnimalAidDto[]>(jsonString);

            var validAnimalAids = new List<AnimalAid>();

            var sb = new StringBuilder();

            foreach (var animalAidDto in deserializedAnimalAids)
            {

                bool alreadyExists = validAnimalAids.Any(a => a.Name == animalAidDto.Name);


                if (!IsValid(animalAidDto) || alreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var animalAid = new AnimalAid
                {
                    Name = animalAidDto.Name,
                    Price = animalAidDto.Price
                };

                validAnimalAids.Add(animalAid);
                sb.AppendLine(string.Format(SuccessMessage, animalAid.Name));
            }

            context.AnimalAids.AddRange(validAnimalAids);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var deserializedAnimals = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);

            var validAnimals = new List<Animal>();

            var sb = new StringBuilder();

            foreach (var animalDto in deserializedAnimals)
            {

                bool passportSerialNumberExists =
                    validAnimals.Any(a => a.PassportSerialNumber == animalDto.Passport.SerialNumber);

                if (!IsValid(animalDto) || !IsValid(animalDto.Passport) || passportSerialNumberExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var regDate = DateTime.ParseExact(animalDto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                var passporta = new Passport
                {
                    SerialNumber = animalDto.Passport.SerialNumber,
                    OwnerName = animalDto.Passport.OwnerName,
                    OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
                    RegistrationDate = regDate
                };

                var validAnimal = new Animal
                {
                    Name = animalDto.Name,
                    Type = animalDto.Type,
                    Age = animalDto.Age,
                    Passport = passporta
                };
               // var validAnimal = Mapper.Map<Animal>(animalDto);

                validAnimals.Add(validAnimal);
                sb.AppendLine(
                    $"Record {animalDto.Name} Passport №: {animalDto.Passport.SerialNumber} successfully imported.");
            }

            context.Animals.AddRange(validAnimals);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(VetDto[]), new XmlRootAttribute("Vets"));
            var deserializedVets =
                (VetDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var validVets = new List<Vet>();

            var sb = new StringBuilder();

            foreach (var vetDto in deserializedVets)
            {
                var vetExists = validVets.Any(n => n.PhoneNumber == vetDto.PhoneNumber);

                if (!IsValid(vetDto) || vetExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var validVet = Mapper.Map<Vet>(vetDto);
                validVets.Add(validVet);
                sb.AppendLine(string.Format(SuccessMessage, validVet.Name));
            }

            context.Vets.AddRange(validVets);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ProcedureDto[]), new XmlRootAttribute("Procedures"));
            var deserializedProcedures =
                (ProcedureDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var validProcedures = new List<Procedure>();

            var sb = new StringBuilder();

            foreach (var procedureDto in deserializedProcedures)
            {
                var vetObj = context.Vets.SingleOrDefault(x => x.Name == procedureDto.Vet);
                var animalObj = context.Animals.SingleOrDefault(x => x.Name == procedureDto.Animal);
                var validProcedureAnimalAids = new List<ProcedureAnimalAid>();
                var allAidsExists = true;

                foreach (var procedureAnimalAid in procedureDto.AnimalAids)
                {
                    var animalAid = context.AnimalAids.SingleOrDefault(ai => ai.Name == procedureAnimalAid.Name);

                    if (animalAid == null || validProcedureAnimalAids.Any(p => p.AnimalAid.Name == procedureAnimalAid.Name))
                    {
                        allAidsExists = false;
                        break;
                    }

                    var animalAidProcedure = new ProcedureAnimalAid
                    {
                        AnimalAid = animalAid
                    };
                    validProcedureAnimalAids.Add(animalAidProcedure);
                }

                if (!IsValid(procedureDto) || !procedureDto.AnimalAids.All(IsValid) || vetObj == null || animalObj == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                var DateTme = DateTime.ParseExact(procedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                var proc = new Procedure
                {
                    Vet = vetObj,
                    Animal = animalObj,
                    DateTime = DateTme,
                    ProcedureAnimalAids = validProcedureAnimalAids
                };

                validProcedures.Add(proc);
                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(validProcedures);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
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