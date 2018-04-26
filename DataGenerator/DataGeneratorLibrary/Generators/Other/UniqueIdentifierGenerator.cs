using System;
using DataGeneratorLibrary.Constrains.Other;

namespace DataGeneratorLibrary.Generators.Other
{
    class UniqueIdentifierGenerator : DataTypeGenerator
        {
            private UniqueIdentifierConstraints Constraints { get; set; }

            public UniqueIdentifierGenerator(Column column) : base(column)
            {
                if (Column.Constraints is UniqueIdentifierConstraints constrains)
                {
                    Constraints = constrains;
                }
                else
                {
                    Constraints = new UniqueIdentifierConstraints();
                }
            }
        
            public override object Generate()
            {
                return Guid.NewGuid();
            }
        }
    }
