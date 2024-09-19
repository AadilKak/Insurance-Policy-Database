using Insurance.Models;

namespace Insurance.Services
{
    public interface IPolicyService
    {
        Task<List<Policy>> GetAllPoliciesAsync();

        Task<Policy> GetPolicyByIdAsync(int id);

        Task AddPolicyAsync(Policy policy);

        Task UpdatePolicyAsync(Policy policy, int id);

        Task DeletePolicyAsync(int id);

    }
}
