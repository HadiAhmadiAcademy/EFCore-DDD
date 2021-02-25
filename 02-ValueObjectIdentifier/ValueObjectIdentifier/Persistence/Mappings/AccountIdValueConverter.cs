using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValueObjectIdentifier.Model;

namespace ValueObjectIdentifier.Persistence.Mappings
{
    public class AccountIdValueConverter : ValueConverter<AccountId, long>
    {
        public AccountIdValueConverter(ConverterMappingHints mappingHints = null)
            : base(
                id => id.Id,
                value => new AccountId(value), 
                mappingHints
            ) { }
    }
}