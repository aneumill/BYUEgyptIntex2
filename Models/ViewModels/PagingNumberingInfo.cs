using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYUEgyptIntex2.Models.ViewModels
{
    public class PagingNumberingInfo
    {
       
            public int NumItemsPerPage { get; set; }
            public int CurrentPage { get; set; }
            public int TotalNumItems { get; set; }

            //Calculate Number of Pages
            public int NumPages => (int)(Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage));
        
    }
}
