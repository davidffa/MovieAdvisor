namespace MovieAdvisor
{
    internal class Genre
    {
        private String _id;
        private String _name;

        public String ID { get => _id; set => _id = value; }
        public String Name { get => _name; set => _name = value; }

        public override string ToString()
        {
            return Name;
        }
    }
}
