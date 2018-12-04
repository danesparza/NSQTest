using Refit;
using System.Threading.Tasks;

namespace NSQ.Library
{
    public interface IQueueApi
    {
        [Post("/pub?topic={topic}")]
        Task<string> SendUserInformation([Body] User user, string topic);
    }
}
