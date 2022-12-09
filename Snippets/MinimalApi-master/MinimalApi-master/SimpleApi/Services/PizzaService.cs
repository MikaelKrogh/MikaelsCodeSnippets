using SimpleApi.Models;
namespace SimpleApi.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;

        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza(1, "Classic Italian", false ),
                new Pizza(2, "Cheese Pizza", true )
            };
        }

        public static List<Pizza> GetAll() => Pizzas;
        public static Pizza? Get(int id) => Pizzas.FirstOrDefault(x => x._Id == id);
        public static void Add(Pizza pizza)
        {
            pizza._Id = nextId++;
            Pizzas.Add(pizza);
        }
        public static void Delete(int id)
        {
            Pizzas.Remove(Pizzas.FirstOrDefault(x => x._Id == id));
        }
        public static void Update(Pizza pizza)
        {
            int index = Pizzas.FindIndex(x => x._Id == pizza._Id);
            Pizzas[index] = pizza;
        }
    }
}
