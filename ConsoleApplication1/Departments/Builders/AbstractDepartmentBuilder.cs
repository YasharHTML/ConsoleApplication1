namespace ConsoleApplication1.Departments.Builders
{
    public abstract class AbstractDepartmentBuilder<T, S> where T: new()
    {
        private T department;

        public AbstractDepartmentBuilder<T, S> Builder()
        {
            department = new T();
            return this;
        }

        public T Build()
        {
            return department;
        }

        public AbstractDepartmentBuilder<T, S> addWorker(S worker)
        {
            (department as AbstractDepartment<S>)?.Hire(worker);
            return this;

        }

        public AbstractDepartmentBuilder<T, S> Reset()
        {
            department = default;
            return this;
        }
    }
}