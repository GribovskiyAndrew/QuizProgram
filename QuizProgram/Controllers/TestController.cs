using Microsoft.AspNetCore.Mvc;
using QuizProgram.Models;

namespace QuizProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private static readonly IEnumerable<TestModel> Tests = new[]
         {
            new TestModel{ Id =  1, Title = "Test1", Description = "test", Type = 1},
            new TestModel{ Id =  2, Title = "Test2", Description = "test", Type = 1},
            new TestModel{ Id =  3, Title = "Test3", Description = "test", Type = 1},
            new TestModel{ Id =  4, Title = "Test4", Description = "test", Type = 2},
            new TestModel{ Id =  5, Title = "Test5", Description = "test", Type = 2},
            new TestModel{ Id =  6, Title = "Test6", Description = "test", Type = 3},
            new TestModel{ Id =  7, Title = "Test7", Description = "test", Type = 3},

        };

        [HttpGet("testType/{testType:int}")]
        public TestModel[] Get(int testType)
        {
            TestModel[] tests = Tests.Where(i => i.Type == testType).ToArray();

            return tests;
        }
    }
}
