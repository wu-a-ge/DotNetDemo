using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.DataBinding;

namespace Demo
{
    [Serializable]
    public class Customer
    {
        [DataProperty]
        public string ID { get; set; }
        [DataProperty]
        public string FirstName { get; set; }
        [DataProperty]
        public string LastName { get; set; }
        [DataProperty]
        public string Gender { get; set; }
        [DataProperty]
        public int? Age { get; set; }
        [DataProperty]
        public DateTime? BirthDay { get; set; }
        [DataProperty]
        public bool? IsVip { get; set; }
    }
}
