using System;
using System.Windows.Forms;
using DataGeneratorGUI.ConstraintsPanels.DateTime;
using DataGeneratorGUI.ConstraintsPanels.Numerics;
using DataGeneratorGUI.ConstraintsPanels.Other;
using DataGeneratorGUI.ConstraintsPanels.Strings;
using DataGeneratorLibrary.DAL;
using DataGeneratorLibrary.Generators;

namespace DataGeneratorGUI.ConstraintsPanels
{
    public static class PanelProvider
    {
        public static UserControl GetPanel(Column currentColumn)
        {
            switch (currentColumn.DataType)
            {
                case TSQLDataType.bigint:
                    return new BigIntConstrintsPanel(currentColumn.Constraints);
                case TSQLDataType.@int:
                    return new IntConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.tinyint:
                    return new TinyIntConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.smallint:
                    return new SmallIntConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.numeric:
                case TSQLDataType.@decimal:
                    return new DecimalConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.bit:
                    return new BitConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.@float:
                    return new FloatConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.real:
                    return new RealConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.smallmoney:
                    return new DecimalConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.money:
                    return new DecimalConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.time:
                    return new TimeConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.date:
                    return new DateConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.datetime:
                case TSQLDataType.datetime2:
                    return new DateTime2ConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.smalldatetime:
                    return new SmallDatetimeConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.datetimeoffset:
                    return new DateTimeOffsetConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.nchar:
                case TSQLDataType.@char:
                case TSQLDataType.binary:
                    return new CharConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.text:
                case TSQLDataType.ntext:
                case TSQLDataType.varchar:
                case TSQLDataType.nvarchar:
                    return new VarcharConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.image:
                case TSQLDataType.varbinary:
                    return new VarbinaryConstraintsPanel(currentColumn.Constraints);
                case TSQLDataType.uniqueidentifier:
                    return new UniqueIdentifierConstraintsPanel(currentColumn.Constraints);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
