﻿using System.Reflection;

namespace ActionRpg.Server.GameModels.Helpers
{
    public static class GeneralHelpers
    {
        public static Random rand = new Random();

        public static int GetRandBetweenTwoNumbers(int min, int max)
        {
            return rand.Next(min, max);
        }

        public static IEnumerable<T> GetAll<T>()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(T).IsAssignableFrom(type))
                .Where(type =>
                    !type.IsAbstract &&
                    !type.IsGenericType &&
                    type.GetConstructor(new Type[0]) != null)
                .Select(type => (T)Activator.CreateInstance(type))
                .ToList();
        }
    }
}