using System;
using ConsoleApplication1.Workers.Constants;

namespace ConsoleApplication1.Workers.Impl
{
    public class Fisher: AbstractWorker
    {
        private FishingSpecialty Specialty;

        public Fisher(string name, int salary, int money, FishingSpecialty specialty) : base(name, salary, money)
        {
            Specialty = specialty;
        }

        public override int Work(int hours)
        {
            var result = Salary * hours + hours * ((int) Specialty);
            Money += result;
            return result;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + $"{nameof(Specialty)}: {Specialty}";
        }
    }
}