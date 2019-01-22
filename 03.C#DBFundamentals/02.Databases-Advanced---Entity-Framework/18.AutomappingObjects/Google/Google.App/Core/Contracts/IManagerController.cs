using Google.App.Core.Dtos;

namespace Google.App.Core.Contracts
{
    public interface IManagerController
    {
        void SetManager(int employeeId, int managerId);

        ManagerDto GetManagerInfo(int employeeId);
    }
}
