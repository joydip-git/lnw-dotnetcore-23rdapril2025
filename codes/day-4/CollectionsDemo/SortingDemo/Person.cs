namespace SortingDemo
{
    public class Person : IComparable<Person>
    {
        private int id;
        private string name = string.Empty;

        public int Id { get => id; set => id = value; }
        public required string Name { get => name; set => name = value; }

        public object this[int x]
        {
            set
            {
                switch (x)
                {
                    case 1:
                        id = (int)value;
                        break;
                    case 2:
                        name = (string?)value;
                        break;

                    default:
                        break;
                }
            }
            get
            {
                if (x == 1)
                    return id;
                else if (x == 2)
                    return name ?? "NA";
                else
                    throw new ArgumentException("index should either 1(id) or 2(name)");
            }
        }
        public object this[string key]
        {
            set
            {
                switch (key)
                {
                    case "id":
                        id = (int)value;
                        break;
                    case "name":
                        name = (string?)value;
                        break;

                    default:
                        break;
                }
            }
            get
            {
                if (key == "id")
                    return id;
                else if (key == "name")
                    return name ?? "NA";
                else
                    throw new ArgumentException("index should either 1(id) or 2(name)");
            }
        }

        public override string ToString()
        {
            return $"Id={id}, Name={name}";
        }

        //writing the logic of compraison between two instances of Person through CompareTo method from IComparable interface is known as: internalization of comparison
        public int CompareTo(Person? obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (obj == this) return 0;

            if (this.Id.CompareTo(obj.Id) == 0)
                return this.Name.CompareTo(obj.Name);
            else
                return this.Id.CompareTo(obj.Id);
        }

        public static bool operator >(Person left, Person right)
        {
            return left.CompareTo(right) > 0;
        }
        public static bool operator <(Person left, Person right)
        {
            return !(left.CompareTo(right) > 0);
        }
    }
}
