using System.Collections.Generic;
using FinancialApp.Core;

namespace Hotel.Rates.Data.Interfaces
{
    public interface IRatePlanService
    {
        ServiceResult<IReadOnlyList<RatePlan>> GetRatePlans();
        ServiceResult<RatePlan> GetRatePlanById(int id);
    }
}