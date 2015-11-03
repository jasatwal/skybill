using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Infrastructure.Billing
{
    public interface IBillingService
    {
        Task<CustomerBill> Find(CustomerAccountNumber customer);
    }
}
