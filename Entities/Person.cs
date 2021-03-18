
namespace Bank.Entities
{
    class Person
    {
        protected string Name;
        protected double CurrentMoney;

        public Person(string name, double currentMoney)
        {
            Name = name;
            CurrentMoney = currentMoney;
        }

        public double GetCurrentMoney() => CurrentMoney;
        public string GetName() => Name;
        public void SetCurrentMoney(double value) => CurrentMoney = value;

    }
}
