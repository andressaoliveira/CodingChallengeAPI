namespace CodingChallengeAPI.Util
{
    public static class EnumerableUtil
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> lista)
        {
            return lista == null || !lista.Any();
        }
    }
}
