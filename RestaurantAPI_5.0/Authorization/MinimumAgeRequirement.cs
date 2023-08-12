using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI_5._0.Authorization
{
    public class MinimumAgeRequirement: IAuthorizationRequirement
    {
        public int MinimumAge { get; }
        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
}
