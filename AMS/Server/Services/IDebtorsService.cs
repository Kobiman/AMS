using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface IDebtorsService
    {
        public Task<DebtorsDto> AddDebtor(Debtors debtor);
        public Task<IEnumerable<DebtorsDto>> GetDebtors();

        public Task<DebtorsDto> UpdateDetor(Debtors debtor);
    }
}
