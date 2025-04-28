namespace LnW.DotNet.Collections.Generic.Extensions
{
    public static class CollectionExtensions
    {
        //extension methods are ALWAYS added as instance method in te target type
        //using extension method technique, you can't add any static method to the target type
        //public static T[] ToArray<T>(this MyCollection<T> collection, int startIndex = 0, int count = 0)

        //since the IEnumerable<T> (built-in) type already has ToArray<T>() exrension method. hence changing the name
        public static T[] CopyToArray<T>(this IEnumerable<T> collection, int startIndex = 0, int count = 0)
        {
            T[] values = new T[collection.Count()];
            int index = 0;
            //foreach (var item in values)
            //{
            //    values[index] = item;
            //    index++;
            //}
            if (count == 0)
            {
                for (int i = startIndex; i < collection.Count(); i++)
                {

                    values[index] = collection.ElementAt(i);
                    index++;
                }
            }
            else
            {
                for (int i = startIndex; i < count; i++)
                {

                    values[index] = collection.ElementAt(i);
                    index++;
                }
            }
            return values;
        }
    }
}
