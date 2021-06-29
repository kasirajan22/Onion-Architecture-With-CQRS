using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public class ResponseEntity
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
