using System.Collections.Generic;
using FinancialApp.Core;
using Hotel.Rates.Data.Interfaces;

namespace Hotel.Rates.Data.Services
{
    public class RatePlanService: IRatePlanService
    {
        private readonly IRepository<RatePlan> _ratePlanRepository;

        public RatePlanService(IRepository<RatePlan> ratePlanRepository)
        {
            _ratePlanRepository = ratePlanRepository;
        }

        public ServiceResult<IReadOnlyList<RatePlan>> GetRatePlans()
        {
            return ServiceResult<IReadOnlyList<RatePlan>>.SuccessResult(_ratePlanRepository.Get());
        }

        public ServiceResult<RatePlan> GetRatePlanById(int id)
        {
            var ratePlan = _ratePlanRepository.Getid(id);
            return ServiceResult<RatePlan>.SuccessResult(ratePlan);
        }
    }
}