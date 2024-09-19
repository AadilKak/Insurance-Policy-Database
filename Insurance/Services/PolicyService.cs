using Insurance.Models;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly ProjectInsuranceContext _context;  
        public PolicyService(ProjectInsuranceContext context)
        {
            _context = context; 
            
        }
        public async Task<List<Policy>> GetAllPoliciesAsync()
        {
            var result = await _context.Policies.ToListAsync(); 
            return result;  
        }

        async Task IPolicyService.AddPolicyAsync(Policy policy)
        {
            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();
        }

        async Task IPolicyService.DeletePolicyAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if( policy != null)
            {
                _context.Policies.Remove(policy);
                await _context.SaveChangesAsync();
            }
        }

        async Task<Policy> IPolicyService.GetPolicyByIdAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            return policy;
        }

        async Task IPolicyService.UpdatePolicyAsync(Policy policy, int id)
        {
            var dbPolicy = await _context.Policies.FindAsync(id);
            if (dbPolicy != null)
            {
                
                dbPolicy.CustomerFirstName = policy.CustomerFirstName;  
                dbPolicy.CustomerLastName = policy.CustomerLastName;    
                dbPolicy.CustomerEmail  = policy.CustomerEmail;
                dbPolicy.StartDate = policy.StartDate;
                dbPolicy.EndDate = policy.EndDate;
                dbPolicy.Coverage = policy.Coverage;    
                dbPolicy.MonthlyPayment = policy.MonthlyPayment;

                dbPolicy.LifeInsurance = policy.LifeInsurance;
                dbPolicy.Beneficiary = policy.Beneficiary;

                dbPolicy.CarInsurance = policy.CarInsurance;
                dbPolicy.Make = policy.Make;
                dbPolicy.Model = policy.Model;
                dbPolicy.Year = policy.Year;    


                dbPolicy.HomeInsurance = policy.HomeInsurance;
                dbPolicy.HousePrice = policy.HousePrice;


                await _context.SaveChangesAsync();
            }
        }
    }
}
