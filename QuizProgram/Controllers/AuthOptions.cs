using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace QuizProgram.Controllers
{
    public static class AuthOptions
    {
        public const string ISSUER = "TestQuizServer";
        public const string AUDIENCE = "TestQuizClient";
        private const string KEY = "vnpWF(#4fj8d,9[-3d02ecr3034fdlweood[k";
        public const int LIFETIME = 10080;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
