using ConsoleApplication1.Utils;
using ConsoleApplication1.Workers.Impl;

namespace ConsoleApplication1.Departments.Impl
{
    public class BusinessDepartment : AbstractDepartment<BusinessAnalyst>
    {
        private int monthlyIncome = RandomGenSingletonUtil.getInstance().Random.Next(1000, 2001);

        public void PayTaxes()
        {
            DebtGuard();
            Budget -= RandomGenSingletonUtil.getInstance().Random.Next(1000, 2001);
            DebtGuard();
        }

        public override string ToString()
        {
            return base.ToString() + $", {nameof(monthlyIncome)}: {monthlyIncome}";
        }
    }
}