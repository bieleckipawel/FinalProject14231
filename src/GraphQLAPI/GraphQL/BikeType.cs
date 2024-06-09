using FinalProject14231.Domain.Entities;
using HotChocolate.Types;

public class BikeType : ObjectType<Bike>
{
    protected override void Configure(IObjectTypeDescriptor<Bike> descriptor)
    {
        descriptor.Field(b => b.Id).Type<NonNullType<IdType>>();
        descriptor.Field(b => b.Name).Type<NonNullType<StringType>>();
        descriptor.Field(b => b.Price).Type<NonNullType<FloatType>>();
        descriptor.Field(b => b.Description).Type<StringType>();
    }
}
