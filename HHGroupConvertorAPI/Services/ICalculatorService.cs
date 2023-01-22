using HHGroupConvertorAPI.Models;
using HHGroupConvertorAPI.Models.Response;

namespace HHGroupCalculatorAPI.Services
{
    public interface ICalculatorService
    {
        JobResponseModel Calculate(JobCreateModel job);
    }
}
