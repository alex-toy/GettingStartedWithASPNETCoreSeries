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
        private Guid operationId;

        public Operation()
        {
            operationId = Guid.NewGuid();
        }

        public Operation(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                operationId = Guid.NewGuid();
            }
            else
            {
                operationId = guid;
            }
        }

        public Guid OperationId { get => operationId; set => operationId = Guid.NewGuid(); }
    }
}
    