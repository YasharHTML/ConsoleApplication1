using ConsoleApplication1.Workers.Constants;

namespace ConsoleApplication1.Workers.Impl
{
    public class BusinessAnalyst : AbstractWorker
    {
        private BusinessTeam Team;

        public BusinessAnalyst(string name, int salary, int money, BusinessTeam specialty) : base(name,
            salary, money)
        {
            Team = specialty;
        }

        public override int Work(int hours)
        {
            var result = Salary * hours + hours * ((int)Team);
            Money += result;
            return result;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + $"{nameof(Team)}: {Team}";
        }
    }
}