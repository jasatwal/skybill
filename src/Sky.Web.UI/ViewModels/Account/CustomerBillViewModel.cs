using Sky.Billing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sky.Web.UI.ViewModels.Account
{
    public class CustomerBillViewModel
    {
        public Bill Bill { get; set; }
        public IEnumerable<CalledFrequency> CalledFrequency { get; set; }
    }
}
