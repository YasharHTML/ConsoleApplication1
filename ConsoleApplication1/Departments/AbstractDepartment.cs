using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.Utils;
using ConsoleApplication1.Workers;

namespace ConsoleApplication1.Departments
{
    public abstract class AbstractDepartment<T>
    {
        public int Budget { get; protected set; } = RandomGenSingletonUtil.getInstance().Random.Next(5000, 10000);
        private List<T> Workers = new List<T>();

        public void Hire(T worker)
        {
            Workers.Add(worker);
        }

        public void Fire(T worker)
        {
            Workers.Remove(worker);
        }

        public T GetWorker(int id)
        {
            return Workers[id];
        }

        public int Length()
        {
            return Workers.Count;
        }

        protected void DebtGuard()
        {
            if (Budget < 0) throw new Exception("Debt: " + Budget);
        }

        public override string ToString()
        {
            var result = $"{nameof(Budget)}: {Budget}";
            for (var i = 0; i < Workers.Count; i++)
            {
                
                result = string.Concat(result, $", worker{i}: {Workers[i].ToString()}");
            }

            return result;
        }
    }
}