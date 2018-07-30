using System;
using System.Collections.Generic;

namespace Persistance
{
    public partial class B2bcategory
    {
        public B2bcategory()
        {
            BusinessToBusiness = new HashSet<BusinessToBusiness>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<BusinessToBusiness> BusinessToBusiness { get; set; }
    }
}
