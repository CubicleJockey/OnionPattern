using System.Threading.Tasks;
using OnionPattern.Domain.Entities;

namespace OnionPattern.Domain.Services
{
    public interface IServiceRequest<TEntity, TResponse> where TEntity : VideoGameEntity
    {
        Task<TResponse> Execute();
    }
}