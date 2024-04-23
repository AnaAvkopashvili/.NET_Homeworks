using Mapster;
using PizzaRestaurant.API.infrastructure.Models.DTO;
using PizzaRestaurant.API.infrastructure.Models.Requests;
using PizzaRestaurant.Application.Address;
using PizzaRestaurant.Application.Order;
using PizzaRestaurant.Application.Pizza;
using PizzaRestaurant.Application.RankHistory;
using PizzaRestaurant.Application.User;

namespace PizzaRestaurant.API.infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<PizzaRequestModel, PizzaResponseModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<PizzaResponseModel, PizzaDTO>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<PizzaCreateModel, PizzaRequestModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<PizzaPutModel, PizzaRequestModel>
                .NewConfig()
                .Map(src => src.Description, dest => dest.PizzaDescription)
                .TwoWays();

            TypeAdapterConfig<UserRequestModel, UserResponseModel>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<UserResponseModel, UserDTO>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<UserCreateModel, UserRequestModel>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<UserPutModel, UserRequestModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<AddressRequestModel, AddressResponseModel>
              .NewConfig()
              .TwoWays();
            TypeAdapterConfig<AddressResponseModel, AddressDTO>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<AddressCreateModel, AddressRequestModel>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<AddressPutModel, AddressRequestModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<OrderCreateModel, OrderResponseModel>
               .NewConfig()
               .TwoWays();
            TypeAdapterConfig<RankHistoryCreateModel, RankHistoryResponseModel>
               .NewConfig()
               .TwoWays();
        }
    }
}
