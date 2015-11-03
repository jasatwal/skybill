using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Infrastructure.Billing
{
    internal static class DtoExtensions
    {
        public static Period Convert(this PeriodDto dto)
        {
            return new Period(dto.from, dto.to);
        }

        public static Package Convert(this PackageDto dto)
        {
            var map = new Dictionary<string, Subscription>(StringComparer.OrdinalIgnoreCase)
            {
                { "tv", null },
                { "talk", null },
                { "broadband", null }
            };
            
            foreach (var subscriptionDto in dto.subscriptions)
            {
                if (map.ContainsKey(subscriptionDto.type))
                    map[subscriptionDto.type] = new Subscription(subscriptionDto.name, subscriptionDto.cost);
                else
                    throw new NotSupportedException(String.Format("'{0}' not supported.", subscriptionDto.type));
            }

            return new Package(map["tv"], map["talk"], map["broadband"], dto.total);
        }

        public static CallCharge Convert(this CallDto dto)
        {
            return new CallCharge(dto.called, dto.duration, dto.cost);
        }

        public static SkyStorePurchase Convert(this RentalDto dto)
        {
            return new SkyStorePurchase(new SkyStoreMovie(dto.title), dto.cost);
        }

        public static SkyStorePurchase Convert(this BuyAndKeepDto dto)
        {
            return new SkyStorePurchase(new SkyStoreMovie(dto.title), dto.cost);
        }
    }
}
