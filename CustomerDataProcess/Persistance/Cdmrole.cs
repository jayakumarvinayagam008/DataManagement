using System;
using System.Collections.Generic;

namespace Persistance
{
    public partial class Cdmrole
    {
        public Cdmrole()
        {
            Cdmuser = new HashSet<Cdmuser>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<Cdmuser> Cdmuser { get; set; }
    }
}
