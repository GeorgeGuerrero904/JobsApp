using JobsApp.Models.Database;

namespace JobsApp.Models.Services.Intefaces
{
    public interface IUserAccountService
    {
        public User? loginUser(string userEmail, string password);
    }
}
