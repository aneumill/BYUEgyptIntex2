using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYUEgyptIntex2.Models.ViewModels
{
    public class ViewRecordViewModel
    {
        public IEnumerable<MummyModel> Mummy { get; set; }

        public PagingNumberingInfo PageNumberingInfo { get; set; }
    }
}
