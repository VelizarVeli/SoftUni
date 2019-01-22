using System;
using System.Linq;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using TORSHIAWebApp.Models;
using TORSHIAWebApp.Models.Enums;
using TORSHIAWebApp.ViewModels.Tasks;
using Task = TORSHIAWebApp.Models.Task;

namespace TORSHIAWebApp.Controllers
{
    public class TasksController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var taskViewModel = this.Db.Tasks.Where(x => x.Id == id)
                .Select(x => new TaskViewModel
                {
                    Title = x.Title,
                    Level = x.AffectedSectors.Count,
                    DueDate = x.DueDate,
                    Description = x.Description
                   // Participants = x.Participants,
                }).FirstOrDefault();

            if (taskViewModel == null)
            {
                return this.BadRequestError("Invalid channel id.");
            }

            return this.View(taskViewModel);
        }

        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize(nameof(UserRole.Admin))]
        [HttpPost]
        public IHttpResponse Create(CreateTasksInputModel model)
        {
            //TODO: AffectedSectors

            var task = new Task
            {
                Title = model.Title,
                DueDate = model.DueDate,
                Description = model.Description
            };

            if (!string.IsNullOrWhiteSpace(model.AffectedSectors))
            {
                var sectors = model.AffectedSectors.Split(',', ';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var tag in sectors)
                {
                    var dbSector = this.Db.Sectors.FirstOrDefault(x => x.Name == tag.Trim());
                    if (dbSector == null)
                    {
                        dbSector = new Sector { Name = tag.Trim() };
                        this.Db.Sectors.Add(dbSector);
                        this.Db.SaveChanges();
                    }

                    task.AffectedSectors.Add(new TaskSector
                    {
                        SectorId = dbSector.Id
                    });
                }
            }

            this.Db.Tasks.Add(task);
            this.Db.SaveChanges();

            return this.Redirect("/Tasks/Details/" + task.Id);
        }

        [Authorize]
        public IHttpResponse Report(int id)
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            if (!this.Db.Reports.Any(
                x => x.ReporterId == user.Id && x.TaskId == id))
            {
                this.Db.Reports.Add(new Report
                {
                    TaskId = id,
                    ReporterId = user.Id,
                    Status = RandomStatus()
                });

                this.Db.SaveChanges();
            }

            return this.Redirect("/Home/LoggedInIndex");
        }

        public Status RandomStatus()
        {
            var status = new Status();
            Random rnd = new Random();
            int chance = rnd.Next(101);
            if (chance > 75)
            {
                status = Status.Archived;
            }
            else
            {
                status = Status.Completed;
            }

            return status;
        }

        //[Authorize("Admin")]
        //public IHttpResponse Delete(int id)
        //{
        //    var viewModel = this.Db.Products
        //        .Select(x => new UpdateDeleteProductInputModel()
        //        {
        //            Type = x.Type.ToString(),
        //            Name = x.Name,
        //            Id = x.Id,
        //            Price = x.Price,
        //            Description = x.Description,
        //        })
        //        .FirstOrDefault(x => x.Id == id);
        //    if (viewModel == null)
        //    {
        //        return this.BadRequestError("Invalid product id.");
        //    }

        //    return this.View(viewModel);

        //}

        //[Authorize("Admin")]
        //[HttpPost]
        //public IHttpResponse Delete(int id, string name)
        //{
        //    var product = this.Db.Products.FirstOrDefault(x => x.Id == id);
        //    if (product == null)
        //    {
        //        return this.Redirect("/");
        //    }

        //    this.Db.Remove(product);
        //    // product.IsDeleted = true;
        //    this.Db.SaveChanges();

        //    return this.Redirect("/");
        //}
    }
}
