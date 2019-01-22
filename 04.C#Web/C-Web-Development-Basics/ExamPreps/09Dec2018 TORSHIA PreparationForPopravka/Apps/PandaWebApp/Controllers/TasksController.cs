using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using TorshiaWebApp.Models;
using TorshiaWebApp.ViewModels.Tasks;

namespace TorshiaWebApp.Controllers
{
    public class TasksController : BaseController
    {
        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize(nameof(UserRole.Admin))]
        [HttpPost]
        public IHttpResponse Create(CreateTasksInputModel model)
        {
            ICollection<Sector> affectedSectors = new ICollection<Sector>();

            foreach (var sector in model.AffectedSectors)
            {
                if (!Enum.TryParse(sector.SectorName, true, out Sector affectedSector))
                {
                    return this.BadRequestErrorWithView("Invalid affected sector.");
                    break;
                }
                affectedSectors.Add(affectedSector);
            }

            var task = new Task
            {
                Title = model.Title,
                DueDate = model.DueDate,
                Description = model.Description,
                Sectors = ICollection<affectedSectors>
            };

            if (!string.IsNullOrWhiteSpace(model.Participants))
            {
                var participants = model.Participants.Split(',', ';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var participant in participants)
                {
                    var dbParticipant = this.Db.Participants.FirstOrDefault(x => x.Name == participant.Trim());
                    if (dbParticipant == null)
                    {
                        dbParticipant = new Participant { Name = participant.Trim() };
                        this.Db.Participants.Add(dbParticipant);
                        this.Db.SaveChanges();
                    }

                    task.Participants.Add(new TaskParticipants
                    {
                        ParticipantId = dbParticipant.Id,
                    });
                }
            }

            this.Db.Tasks.Add(task);
            this.Db.SaveChanges();

            return this.Redirect("/Tasks/Details");   /*?id=" + task.Id);*/
        }
    }
}