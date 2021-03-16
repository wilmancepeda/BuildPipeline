using System;
using Xunit;
using TaskAdmin.Controllers;
using TaskAdmin.Models;
using System.Linq;

namespace TaskAdminTests
{
    public class TaskControllerTest
    {
        private readonly TaskAdminContext _db = new TaskAdminContext();

        
        [Fact]
        public void GetTask_ShouldBeTheSame()
        {
            var tasks = _db.TaskUser.Where(t => t.Id == 1).ToList();

            Assert.Equal(tasks, _db.TaskUser.Where(t => t.Id == 1).ToList());

           // Assert.Equal(0, _db.TaskUser.Where(t => t.Id == 1).Count());
        }
    }
}
