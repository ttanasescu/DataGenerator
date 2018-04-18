using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return new Guid();
            }
        }
    }
