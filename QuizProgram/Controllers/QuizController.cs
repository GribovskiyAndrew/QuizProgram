using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuizProgram.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace QuizProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private static readonly IEnumerable<QuestionModel> Questions = new[]
         {
            new QuestionModel{ Id = 1, Title = "question1", Variants = new(){ "1","2","3","4"}, Answer = 1, TestId = 1},
            new QuestionModel{ Id = 2, Title = "question1", Variants = new(){ "1","2","3","4"}, Answer = 3, TestId = 1},
            new QuestionModel{ Id = 3, Title = "question1", Variants = new(){ "1","2","3","4"}, Answer = 2, TestId = 1},
            new QuestionModel{ Id = 4, Title = "question1", Variants = new(){ "1","2","3","4"}, Answer = 4, TestId = 1},

            new QuestionModel{ Id = 5, Title = "question2", Variants = new(){ "1","2","3","4"}, Answer = 1, TestId = 2},
            new QuestionModel{ Id = 6, Title = "question2", Variants = new(){ "1","2","3","4"}, Answer = 1, TestId = 2},
            new QuestionModel{ Id = 7, Title = "question2", Variants = new(){ "1","2","3","4"}, Answer = 3, TestId = 2},
            new QuestionModel{ Id = 8, Title = "question2", Variants = new(){ "1","2","3","4"}, Answer = 1, TestId = 2},

            new QuestionModel{ Id = 9, Title = "question3", Variants = new(){ "1","2","3","4"}, Answer = 1, TestId = 3},
            new QuestionModel{ Id = 10, Title = "question3", Variants = new(){ "1","2","3","4"}, Answer = 2, TestId = 3},
            new QuestionModel{ Id = 11, Title = "question3", Variants = new(){ "1","2","3","4"}, Answer = 3, TestId = 3},
            new QuestionModel{ Id = 12, Title = "question3", Variants = new(){ "1","2","3","4"}, Answer = 1, TestId = 3},

            new QuestionModel{ Id = 13, Title = "question4", Variants = new(){ "1","2","3","4"}, Answer = 1, TestId = 4},
            new QuestionModel{ Id = 14, Title = "question4", Variants = new(){ "1","2","3","4"}, Answer = 4, TestId = 4},
            new QuestionModel{ Id = 15, Title = "question4", Variants = new(){ "1","2","3","4"}, Answer = 2, TestId = 4},
            new QuestionModel{ Id = 16, Title = "question4", Variants = new(){ "1","2","3","4"}, Answer = 2, TestId = 4},

            new QuestionModel{ Id = 17, Title = "question5", Variants = new(){ "1","2","3","4"}, Answer = 1, TestId = 5},
            new QuestionModel{ Id = 18, Title = "question5", Variants = new(){ "1","2","3","4"}, Answer = 2, TestId = 5},
            new QuestionModel{ Id = 19, Title = "question5", Variants = new(){ "1","2","3","4"}, Answer = 2, TestId = 5},
            new QuestionModel{ Id = 20, Title = "question5", Variants = new(){ "1","2","3","4"}, Answer = 2, TestId = 5},

            new QuestionModel{ Id = 21, Title = "question6", Variants = new(){ "1","2","3","4"}, Answer = 3, TestId = 6},
            new QuestionModel{ Id = 22, Title = "question6", Variants = new(){ "1","2","3","4"}, Answer = 1, TestId = 6},
            new QuestionModel{ Id = 23, Title = "question6", Variants = new(){ "1","2","3","4"}, Answer = 4, TestId = 6},
            new QuestionModel{ Id = 24, Title = "question6", Variants = new(){ "1","2","3","4"}, Answer = 1, TestId = 6},

            new QuestionModel{ Id = 25, Title = "question7", Variants = new(){ "1","2","3","4"}, Answer = 2, TestId = 7},
            new QuestionModel{ Id = 26, Title = "question7", Variants = new(){ "1","2","3","4"}, Answer = 1, TestId = 7},
            new QuestionModel{ Id = 27, Title = "question7", Variants = new(){ "1","2","3","4"}, Answer = 2, TestId = 7},
            new QuestionModel{ Id = 28, Title = "question7", Variants = new(){ "1","2","3","4"}, Answer = 1, TestId = 7},

        };

        [HttpGet("type/{testType:int}")]
        public string Get(int testType)
        {
            QuestionModel[] questions = Questions.Where(i => i.TestId == testType).ToArray();

            List<object> questionsData = new();

            foreach (QuestionModel question in questions)
            {
                object QuestionData = new
                {
                    question = question.Title,
                    questionType = "text",
                    answerSelectionType = "single",
                    answers = question.Variants,
                    correctAnswer = question.Answer.ToString(),
                    messageForCorrectAnswer = "Correct answer. Good job.",
                    messageForIncorrectAnswer = "Incorrect answer. Please try again.",
                    explanation = "",
                    point = "0"
                };

                questionsData.Add(QuestionData);
            } 

            string json = JsonConvert.SerializeObject( new
            {
                quizTitle = "React Quiz",
                quizSynopsis = "",
                nrOfQuestions = "4",
                questions = questionsData.ToArray(),
            });

            return json;
        }
    }
}
