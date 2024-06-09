using FinalProject14231.Domain.Entities;
using HotChocolate.Types;

public class RentalType : ObjectType<Rental>
{
    protected override void Configure(IObjectTypeDescriptor<Rental> descriptor)
    {
        descriptor.Field(r => r.Id).Type<NonNullType<IdType>>();
        descriptor.Field(r => r.StartDate).Type<NonNullType<DateTimeType>>();
        descriptor.Field(r => r.EndDate).Type<NonNullType<DateTimeType>>();
        descriptor.Field(r => r.Price).Type<NonNullType<FloatType>>();
        descriptor.Field(r => r.RentedBike).Type<BikeType>();
        descriptor.Field(r => r.Renter).Type<CustomerType>();
    }
}
