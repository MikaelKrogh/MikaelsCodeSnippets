

namespace SimpleApi.Models
{
    public class Pizza
    {
        public int? _Id { get; set; }
        public string _Name { get; set; }
        public bool _IsGlutenFree { get; set; }

        public Pizza(int id, string name, bool isGlutenFree)
        {
            _Id = id;
            _Name = name;
            _IsGlutenFree = isGlutenFree;
        }

        public Pizza(string name, bool isGlutenFree)
        {
            _Name = name;
            _IsGlutenFree = isGlutenFree;
        }
    }
}
