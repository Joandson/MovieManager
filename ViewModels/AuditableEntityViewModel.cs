using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieManager.ViewModels
{
    public class AuditableEntityViewModel
    {
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool Deleted { get; set; }
    }
}