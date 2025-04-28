namespace SortingDemo
{
    public class PersonComparer : IComparer<Person>
    {
        private int choice;
        public PersonComparer()
        {
            choice = 1;
        }
        public PersonComparer(int choice) => this.choice = choice;

        public int Compare(Person? x, Person? y)
        {
            if (x == null)
                throw new ArgumentNullException(nameof(x));

            if (y == null)
                throw new ArgumentNullException(nameof(y));

            if (x == y) return 0;

            //if (x.Id.CompareTo(y.Id) == 0)
            //    return x.Name.CompareTo(y.Name);
            //else
            //    return x.Id.CompareTo(y.Id);

            int result = choice switch
            {
                1 => x.Id.CompareTo(y.Id),
                2 => x.Name.CompareTo(y.Name),
                _ => x.Id.CompareTo(y.Id)
            };
            return result;
        }
    }
}
