namespace CollectionsDemo
{
    class Person
    {
        private int id;
        private string? name;

        public int Id { get => id; set => id = value; }
        public string? Name { get => name; set => name = value; }

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
    }

}
