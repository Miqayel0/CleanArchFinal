using System.Threading.Tasks;

namespace CleanArch.Application.Products.Commands.Hubs
{
    public interface IProductClient
    {
        Task ProductDiscounted(object message);
    }
}
