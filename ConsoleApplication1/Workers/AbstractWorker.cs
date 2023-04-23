namespace ConsoleApplication1.Workers
{
    public abstract class AbstractWorker
    {
        protected AbstractWorker(string name, int salary, int money)
        {
            Name = name;
            Salary = salary;
            Money = money;
        }

        protected string Name { get; set; }
        protected int Salary { get; set; }
        protected int Money { get; set; }


        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Salary)}: {Salary}, {nameof(Money)}: {Money}";
        }

        public abstract int Work(int hours);
    }
}