using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Entites
{
    public class   FullAuditedEntity<TId>
    {
        [Key]
        public TId Id { get; set; }


        public DateTime CreatedAt { get; set; } 
        public string? CreatedBy { get; set; }
        public DateTime? IsDeleted { get; set; }
        public  string? DeletedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string? UpdatedBy { get; set; }

    }
}
