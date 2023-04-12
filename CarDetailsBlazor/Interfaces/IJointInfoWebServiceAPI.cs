using CarDetailsModels;
using Refit;

namespace CarDetailsBlazor.Interfaces
{
    public interface IJointInfoWebServiceAPI
    {
        [Get("/jointinfo")]
        Task<IEnumerable<JointInfo>> GetJointInfo(int? Page = 1, int? PageSize = 12);
    }
}
