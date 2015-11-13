using System.Threading.Tasks;

namespace Sky.Billing
{
    public interface IBillingService
    {
        Task<Bill> Find(CustomerAccountNumber customer);
    }
}
