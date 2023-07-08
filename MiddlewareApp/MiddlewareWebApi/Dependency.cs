using System;

namespace MiddlewareWebApi
{
    public interface IOperation
    {
        public Guid OperationId { get; set; }
    }

    public interface IOperationTransient : IOperation
    {
    }

    public interface IOperationScoped: IOperation
    {
    }

    public interface IOperationSingleton : IOperation
    {
    }

    public interface IOperationSingletonInstance : IOperation
    {
    }

    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton, IOperationSingletonInstance
    {
        public Guid OperationId { get => OperationId; set => new Guid(); }
    }
}
    