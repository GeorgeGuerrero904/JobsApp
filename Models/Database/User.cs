using System.ComponentModel.DataAnnotations.Schema;

namespace JobsApp.Models.Database
{
    public class User : BaseTableInfo
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string jobTitle { get; set; }

        public int roleId { get; set; }


        [ForeignKey("roleId")]
        public Role userRole { get; set; }
    }
}
