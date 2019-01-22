namespace Torshia.App.Controllers.Reports
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System;
    using System.Linq;
    using Torshia.App.Models;
    using Torshia.App.Models.Enums;
    using Torshia.App.ViewModels.Reports;

    public class ReportsController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int Id)
        {
            if (!this.DbContext.Reports.Any(r => r.Id == Id))
            {
                return this.BadRequestError("Report doesn't exist!");
            }
            else if(this.User.Role != "Admin")
            {
                return this.BadRequestError("404 Page Not Found");
            }

            ReportDetailsViewModel viewModel =
                this.DbContext
                .Reports
                .Select(r => new ReportDetailsViewModel
                {
                    Id = r.Id,
                    TaskTitle = r.Task.Title,
                    TaskDescription = r.Task.Description,
                    TaskLevel = r.Task.AffectedSectors.Count,
                    TaskAffectedSectors = string.Join(", ", r.Task.AffectedSectors.Select(a => a.Sector.SectorType.ToString())),
                    TaskParticipants = string.Join(", ", r.Task.Participants.Select(p => p.Participant.Name)),
                    TaskDueDate = r.Task.DueDate.ToString("d"),
                    ReportedOn = r.ReportedOn.ToString("d"),
                    ReporterName = r.Reporter.Username,
                    ReportStatus = r.Status.ToString()
                })
                .Where(r => r.Id == Id)
                .First();

            return this.View(viewModel);
        }

        [Authorize]
        public IHttpResponse Report(int Id)
        {

            int taskId = this.DbContext.Tasks.FirstOrDefault(t => t.Id == Id).Id;
            if (taskId == 0)
            {
                return this.BadRequestError("Task doesn't exist!");
            }

            int userId = this.DbContext.Users.First(u => u.Username == this.User.Username).Id;

            int[] chances = new int[2]
            {
                25,
                75
            };

            Status status = (Status)chances[new Random().Next(0, 1)];

            Report report = new Report()
            {
                Status = status,
                TaskId = taskId,
                ReporterId = userId
            };

            if (this.DbContext.Reports.Any(r => r.TaskId == report.TaskId && r.ReporterId == report.ReporterId))
            {
                return this.BadRequestError("You have already reported this channel!");
            }
            this.DbContext.Reports.Add(report);
            this.DbContext.SaveChanges();

            return this.Redirect("/");
        }

        [Authorize]
        public IHttpResponse All()
        {
            if (this.User.Role != "Admin")
            {
                return this.BadRequestError("404 Page Not Found");
            }

            var reports =
                this.DbContext
                .Reports
                .Select(r => new ReportsTableViewModel
                {
                    Id = r.Id,
                    Title = r.Task.Title,
                    Level = r.Task.AffectedSectors.Count,
                    Status = r.Status.ToString()
                })
                .ToArray();

            return this.View(reports);
        }
    }
}