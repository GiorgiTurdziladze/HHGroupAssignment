using HHGroupConvertorAPI.Models;

namespace HHGroupCalculatorAPI.Validators
{
    public interface IValidator
    {
        void Validate(JobCreateModel model);
    }
}
