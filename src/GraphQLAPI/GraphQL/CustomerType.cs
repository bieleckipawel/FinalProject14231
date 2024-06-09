using FinalProject14231.Domain.Entities;
using HotChocolate.Types;

public class CustomerType : ObjectType<Customer>
{
    protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
    {
        descriptor.Field(c => c.Id).Type<NonNullType<IdType>>();
        descriptor.Field(c => c.FirstName).Type<NonNullType<StringType>>();
        descriptor.Field(c => c.LastName).Type<NonNullType<StringType>>();
        descriptor.Field(c => c.Email).Type<NonNullType<StringType>>();
    }
}
