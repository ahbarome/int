namespace INT.Service.BLL.Interfaces
{
    public interface IProcessor<T>
    {
        void Execute(T request);
    }
}
