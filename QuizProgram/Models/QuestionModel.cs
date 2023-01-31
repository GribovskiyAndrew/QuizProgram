namespace QuizProgram.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<string> Variants { get; set; }

        public int Answer { get; set; }

        public int TestId { get; set; }
    }
}
