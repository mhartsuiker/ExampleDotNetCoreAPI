namespace Product.Contracts.Interfaces
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
