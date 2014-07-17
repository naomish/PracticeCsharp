using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SWCLMS.Data;
using SWCLMS.Models;

namespace SWCLMS.Tests
{
    [TestFixture]
    public class TeacherRepositories
    {
        [Test]
        public void CreateClassTest()
        {
            TeacherRepository repo = new TeacherRepository();
            var newCourse = new Course
            {
                UserId = "6d8bfd69-9321-4847-9633-5d7214c97f68",
                Description = "Unit Tested Class",
                StartDate = new DateTime(2014, 6, 15),
                EndDate = new DateTime(2014, 9, 15),
                GradeLevel = 5,
                IsArchived = false,
                Name = "Unit testing 101",
                Subject = "Programming"
            };

            repo.CreateCourse(newCourse);

            Assert.AreNotEqual(0, newCourse.ClassId);
        }
    }
}
