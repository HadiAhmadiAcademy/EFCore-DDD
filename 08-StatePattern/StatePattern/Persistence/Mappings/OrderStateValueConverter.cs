using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StatePattern.Model;

namespace StatePattern.Persistence.Mappings
{
    public class OrderStateValueConverter : ValueConverter<OrderState, int>
    {
        //This is for the purpose of the demo, you can use any kind of factory here
        private static readonly Dictionary<int, Type> Values = new Dictionary<int, Type>()
        {
            {1, typeof(DraftState)},
            {2, typeof(ConfirmedState)},
            {3, typeof(ShippedState)},
        };

        public OrderStateValueConverter(ConverterMappingHints mappingHints = null)
            : base(
                state => GetValue(state.GetType()),
                value => GetState(value), 
                mappingHints
            ) { }
      
        private static int GetValue(Type stateType)
        {
            return Values.First(a => a.Value == stateType).Key;
        }
        private static OrderState GetState(int value)
        {
            var type = Values[value];
            return Activator.CreateInstance(type) as OrderState;
        }

    }

}