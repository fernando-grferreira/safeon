namespace Safeon.IOC.Contracts
{
    public interface IContainer
    {
        T GetInstance<T>() where T : class;
    }
}