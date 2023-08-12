using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI_5._0.Authorization
{
    public class CreatedMultipleRestaurantsRequirement : IAuthorizationRequirement
    {
        public CreatedMultipleRestaurantsRequirement(int minimumRestaurantCreated)
        {
            MinimumRestaurantCreated = minimumRestaurantCreated;
        }

        public int MinimumRestaurantCreated { get; }
    }
}
