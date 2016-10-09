namespace INT.Service.Dispatcher.Interfaces
{
    public interface IDispatch<T>
    {
        void SendMessage(T message);
    }
}
