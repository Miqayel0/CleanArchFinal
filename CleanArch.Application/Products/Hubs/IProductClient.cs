using System.Threading.Tasks;

namespace CleanArch.Application.Products.Hubs
{
    public interface IProductClient
    {
        Task ProductDiscounted(object message);
    }
}
