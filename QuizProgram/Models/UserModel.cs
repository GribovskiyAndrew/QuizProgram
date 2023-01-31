using System.ComponentModel.DataAnnotations.Schema;

namespace QuizProgram.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
