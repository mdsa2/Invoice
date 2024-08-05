 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Filter
{
    public class InvoiceItemFilter:MasterFilter
    {
       public  DateTime? startDate {  get; set; }
            
         public DateTime? endDate { get; set; }
    }
}
