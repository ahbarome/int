namespace INT.Service.Handler.Interfaces
{
    public interface IHandler<T>
    {
        void Handle(T message);
    }
}
