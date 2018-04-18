using System;
using System.Collections.Generic;
using DataGeneratorLibrary.Generators.DateTime;
using DataGeneratorLibrary.Generators.Numerics;
using DataGeneratorLibrary.Generators.Other;
using DataGeneratorLibrary.Generators.Strings;
using DataGeneratorLibrary.Helpers;

namespace DataGeneratorLibrary.Generators
{
    public abstract class DataTypeGenerator
    {
        protected Column Column { get; }

        protected DataTypeGenerator(Column column)
        {
            Column = column;
            Random = RandomGenerator.Instance;
        }

        public abstract object Generate();
        protected readonly Random Random;

        public IList<object> Generate(int count)
        {
            var values = new List<object>(count);
            for (var i = 0; i < count; i++)
            {
                values.Add(Generate());
            }

            return values;
        }

        public IList<object> GenerateUnique(int count)
        {
            var values = new List<object>(count);
            for (var i = 0; i < count; i++)
            {
                var value = Generate();
                if (!values.Contains(value))
                {
                    values.Add(Generate());
                }
                else
                {
                    i--;
                    //TODO: rewrite
                }
            }

            return values;
        }

        public static DataTypeGenerator GetGenerator(Column column)
        {
            switch (column.DataType)
            {
                case TSQLDataType.bit:
                    return new BitGenerator(column);
                case TSQLDataType.tinyint:
                    return new TinyIntGenerator(column);
                case TSQLDataType.smallint:
                    return new SmallIntGenerator(column);
                case TSQLDataType.@int:
                    return new IntGenerator(column);
                case TSQLDataType.bigint:
                    return new BigIntGenerator(column);

                case TSQLDataType.@float:
                    return new FloatGenerator(column);
                case TSQLDataType.real:
                    return new RealGenerator(column);

                case TSQLDataType.numeric:
                case TSQLDataType.@decimal:
                case TSQLDataType.money:
                case TSQLDataType.smallmoney:
                    return new DecimalsGenerator(column);

                case TSQLDataType.time:
                    return new TimeGenerator(column);
                case TSQLDataType.date:
                    return new DateGenerator(column);
                case TSQLDataType.datetime:
                    return new Datetime2Generator(column);
                case TSQLDataType.datetime2:
                    return new Datetime2Generator(column);
                case TSQLDataType.smalldatetime:
                    return new SmallDatetimeGenerator(column);
                case TSQLDataType.datetimeoffset:
                    return new DatetimeOffsetGenerator(column);
                    
                case TSQLDataType.text:
                case TSQLDataType.ntext:
                case TSQLDataType.@char:
                case TSQLDataType.varchar:
                case TSQLDataType.nchar:
                case TSQLDataType.nvarchar:
                    return new StringGenerator(column);

                case TSQLDataType.image:
                case TSQLDataType.binary:
                case TSQLDataType.varbinary:
                    return new BinaryGenerator(column);

                case TSQLDataType.uniqueidentifier:
                    return new UniqueIdentifierGenerator(column);
                    
                default:
                    throw new NotImplementedException();
            }
        }
    }
}