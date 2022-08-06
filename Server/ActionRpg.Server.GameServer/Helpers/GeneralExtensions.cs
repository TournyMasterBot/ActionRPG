using System.Reflection;

namespace ActionRpg.Server.GameServer.Helpers
{
    public static class GeneralHelpers
    {
        public static Random rand = new Random();

        public static int GetRandBetweenTwoNumbers(int min, int max)
        {
            return rand.Next(min, max);
        }

        public static T?[] GetAll<T>()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => 
            x.GetTypes()
            .Where(type => typeof(T).IsAssignableFrom(type))
            .Where(type =>
                    !type.IsAbstract &&
                    !type.IsGenericType &&
                    type.GetConstructor(new Type[0]) != null)
                .Select(type => (T?)Activator.CreateInstance(type))
                .ToArray()
            ).ToArray();
        }

        public static IEnumerable<T> GetEnumItems<T>()
        {
            T[] array = (T[])Enum.GetValues(typeof(T));
            return array;
        }
    }
}
