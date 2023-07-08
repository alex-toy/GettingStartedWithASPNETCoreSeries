namespace MiddlewareWebApi
{
    public class DependencyServiceBis
    {
        private readonly IOperationTransient _operationTransient;
        private readonly IOperationScoped _operationScoped;
        private readonly IOperationSingleton _operationSingleton;
        private readonly IOperationSingletonInstance _operationSingletonInstance;

        public DependencyServiceBis(IOperationTransient operationTransient, IOperationScoped operationScoped, IOperationSingleton operationSingleton, IOperationSingletonInstance operationSingletonInstance)
        {
            _operationTransient = operationTransient;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
            _operationSingletonInstance = operationSingletonInstance;
        }

        public void Write()
        {
            System.Console.WriteLine("###############################################");
            System.Console.WriteLine("From DependencyServiceBis");
            System.Console.WriteLine($"Transient : {_operationTransient.OperationId}");
            System.Console.WriteLine($"Scoped : {_operationScoped.OperationId}");
            System.Console.WriteLine($"Singleton : {_operationSingleton.OperationId}");
            System.Console.WriteLine($"Singleton instance : {_operationSingletonInstance.OperationId}");
            System.Console.WriteLine("###############################################");
        }
    }
}
