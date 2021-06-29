using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class UserSession
    {
        [Key]
        public Guid SessionUID { get; set; }
        public Guid UserUID { get; set; }
        public string SessionType { get; set; }
        public string SessionToken { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? EndsOn { get; set; }
        public string DeviceIP { get; set; }
        public string Device { get; set; }
    }
}
