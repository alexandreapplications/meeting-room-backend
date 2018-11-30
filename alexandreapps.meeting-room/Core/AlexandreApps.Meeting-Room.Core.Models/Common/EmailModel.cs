using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlexandreApps.Meeting_Room.Core.Models.Common
{
    public class EmailModel
    {
        public Guid? Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required, EmailAddress]
        public string Value { get; set; }
        public string Remarks { get; set; }
    }
}
