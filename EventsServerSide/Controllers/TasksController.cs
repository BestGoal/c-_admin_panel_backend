using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using Domain.Models;
using EventsManagemtns.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsManagemtns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly DbContextImpl context;
        public TasksController(DbContextImpl ctx)
        {
            context = ctx;
        }

       

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public List<Tasks> Get(int id)
        {
            List<Tasks> lists
                       = context.Tasks.Include(x => x.status)
                        .Where(x => x.assigned_for.id == id)
                        .Include(x => x.assigned_for)
                        .Include(x => x.comments)
                        .ToList();
            return lists;
        }
        [HttpGet("subTasks")]
        public List<Tasks> GetSubTask(int parentTask)
        {
            List<Tasks> lists
                       = context.Tasks.Include(x => x.status)
                        .Where(x => x.parentTask.id == parentTask)
                        .Include(x => x.assigned_for)
                        .Include(x => x.comments)
                        .ToList();
            return lists;
        }

        [HttpGet("TasksByOwner")]
        public List<Tasks> getTasksByOwner(int owner)
        {
            List<Tasks> lists
                       = context.Tasks.Include(x => x.status)
                        .Where(x => x.taskOwner == owner)
                        .Include(x => x.assigned_for)
                        .Include(x => x.comments)
                        .ToList();
            return lists;
        }


        // POST api/<TasksController>
        [HttpPost]
        public Tasks Post([FromBody] Tasks value)
        {
            value.status = context.statuses.Where(s => s.StatusTypeId == (int)EntityType.Task && s.isClosing).SingleOrDefault();
            Section section = context.sections.Find(value.assigned_for.id);
            if (value.parentTask != null)
            {
                Tasks task = context.Tasks.Find(value.parentTask.id);
                value.parentTask = task;
            }
            value.assigned_for = section;
            context.Tasks.Add(value);
            context.SaveChanges();
            int intIdt = context.Tasks.Max(u => u.id);
           return new Tasks { id = intIdt };
        }

        // PUT api/<TasksController>
        [HttpPut("updateStatus")]
        public void Put(int id, int status)
        {
            var entity = context.Tasks.Find(id);
            var st = context.statuses.Find(status);
            entity.status = st;
            context.Entry(entity).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        [HttpPut("comments")]
        public void AddComment(int id, string Com, string CommentBy)
        {
            var entity = context.Tasks.Find(id);
            Comment comment = new Comment();
            comment.commentString = Com;
            comment.commentDate = DateTime.Now;
            if (entity.comments == null)
                entity.comments = new List<Comment>();
            //comment.commentedBy = new EmploCommentBy;
            entity.comments.Add(comment);
            context.Entry(entity).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        [HttpPut("progress")]
        public void updateProgress(int id, int prog)
        {
            var entity = context.Tasks.Find(id);
            entity.progress = prog;
            context.Entry(entity).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }
        [HttpPut("status")]
        public void updateStatus(int id)
        {
            Status status = context.statuses.Where(s => s.StatusTypeId == (int)EntityType.Task && !s.isClosing && !s.isOpen).SingleOrDefault();
            var entity = context.Tasks.Find(id);
            entity.status = status;
            context.Entry(entity).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        [HttpPost("closeTask")]
        public void Put([FromBody] CloseReport report)
        {
            var entity = context.Tasks.Find(report.id);
            entity.closingReport = report;
            report.closingDate = DateTime.Now;
            context.closeReports.Add(report);
            entity.status = context.statuses.Where(s => s.StatusTypeId == (int)EntityType.Task && s.isClosing).SingleOrDefault();
            context.Entry(entity).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }


        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
