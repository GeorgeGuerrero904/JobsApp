using JobsApp.Models.Database;
using JobsApp.Models.Database.Migrations;
using JobsApp.Models.Services.Intefaces;


namespace JobsApp.Models.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly JobsContext _context;
        public UserAccountService(JobsContext context)
        {
            _context = context;
        }

        public User? loginUser(string userEmail, string password)
        {
            User? loginUser = _context.User.Where(x => x.email.ToLower() == userEmail.ToLower()).FirstOrDefault();
            if (loginUser != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, loginUser.password)) return loginUser;
            }
            return null;
        }
    }
}
