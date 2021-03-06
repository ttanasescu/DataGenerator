﻿namespace DataGeneratorLibrary.Constrains.Strings
{
    public class BinaryConstraints : CharConstraints
    {
        public BinaryConstraints(int? maxLength) : base(maxLength)
        {
            MaxPossibleLength = maxLength ?? 8000;
        }
    }
}