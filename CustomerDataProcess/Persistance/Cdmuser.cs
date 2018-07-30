using System;
using System.Collections.Generic;

namespace Persistance
{
    public partial class Cdmuser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public Cdmrole Role { get; set; }
    }
}
