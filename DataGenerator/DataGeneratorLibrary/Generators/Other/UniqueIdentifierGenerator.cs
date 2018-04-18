using System;
using DataGeneratorLibrary.Constrains.Other;

namespace DataGeneratorLibrary.Generators.Other
{
    class UniqueIdentifierGenerator : DataTypeGenerator
        {
            private UniqueIdentifierConstrains Constrains { get; set; }

            public UniqueIdentifierGenerator(Column column) : base(column)
            {
                if (Column.constrains is UniqueIdentifierConstrains constrains)
                {
                    Constrains = constrains;
                }
                else
                {
                    Constrains = new UniqueIdentifierConstrains();
                }
            }
        
            public override object Generate()
            {
                return Guid.NewGuid();
            }
        }
    }
