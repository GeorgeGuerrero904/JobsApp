using System.ComponentModel.DataAnnotations.Schema;

namespace JobsApp.Models.Database
{
    public class UserServices : BaseTableInfo
    {
        public int userId { get; set; }
        public string name { get; set; }

        [ForeignKey("userId")]
        public User User { get; set; }
    }
}
