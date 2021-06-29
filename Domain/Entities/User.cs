using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public Guid UID { get; set; }
        public string UserRole { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string CountryCode { get; set; }
        public string Gender { get; set; }
        public string PhotoURL { get; set; }
        public bool EmailVerified { get; set; }
        public int? LoginAttempt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? ForcePasswordChange { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreateOn { get; set; }
        public Guid? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

    }
}
