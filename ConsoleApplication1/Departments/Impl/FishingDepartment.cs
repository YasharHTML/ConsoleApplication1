using System;
using ConsoleApplication1.Utils;
using ConsoleApplication1.Workers.Impl;

namespace ConsoleApplication1.Departments.Impl
{
    public class FishingDepartment : AbstractDepartment<Fisher>
    {
        private int Boats { get; set; } = RandomGenSingletonUtil.getInstance().Random.Next(5, 11);
        private int BrokenBoats { get; set; } = RandomGenSingletonUtil.getInstance().Random.Next(1, 4);

        public void FixBoat()
        {
            DebtGuard();
            if (BrokenBoats == 0) return;
            Budget -= RandomGenSingletonUtil.getInstance().Random.Next(5000, 10001);
            BrokenBoats--;
            Boats++;
            DebtGuard();
            Console.WriteLine("Broken: " + BrokenBoats);
            Console.WriteLine("Fixed: " + Boats);
        }

        public override string ToString()
        {
            return base.ToString() + $", {nameof(Boats)}: {Boats}, {nameof(BrokenBoats)}: {BrokenBoats}";
        }
    }
}