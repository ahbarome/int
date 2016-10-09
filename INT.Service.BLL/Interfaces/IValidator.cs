namespace INT.Service.BLL.Interfaces
{
    public interface IValidator<T>
    {
        void Validate(T request);
    }
}
