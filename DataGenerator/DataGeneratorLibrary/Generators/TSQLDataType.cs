namespace DataGeneratorLibrary.Generators
{
    public enum TSQLDataType
    {
        bigint,
        numeric,
        bit,
        smallint,
        @float,
        real,
        @decimal,
        smallmoney,
        @int,
        tinyint,
        money,
        date,
        datetime,
        datetime2,
        datetimeoffset,
        smalldatetime,
        time,
        @char,
        varchar,
        nchar,
        nvarchar,
        binary,
        varbinary,

        //Will be removed from SQL Server
        ntext,
        text,
        image,

        //TODO: Add Other data types
        uniqueidentifier
    }
}