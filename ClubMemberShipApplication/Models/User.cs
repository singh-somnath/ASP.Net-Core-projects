using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMemberShipApplication.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime DatOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AdddressFirstLine { get; set; }
        public string AdddressSecondLine { get; set; }
        public string AdddressThirdLine { get; set; }
        public string PostCode { get; set; }

    }
}
