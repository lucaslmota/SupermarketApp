using System.Threading.Tasks;

namespace api_rest.Domains.Repositories
{
     public interface IUnityOfWork
    {
        Task CompleteAsync();
    }
}