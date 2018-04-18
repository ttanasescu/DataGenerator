using System;

namespace DataGeneratorLibrary.Helpers
{
    public static class RandomGenerator
    {
        private static Random _instance;
        public static Random Instance => _instance ?? (_instance = new Random());
    }
}
