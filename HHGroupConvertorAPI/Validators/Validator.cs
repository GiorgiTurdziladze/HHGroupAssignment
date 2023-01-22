
using System;
using HHGroupConvertorAPI.Models;

namespace HHGroupCalculatorAPI.Validators
{
    public class Validator : IValidator
    {
        public void Validate(JobCreateModel model)
        {
            foreach (var item in model.Items)
            {
                if (item.Cost <= 0)
                    throw new ArgumentException("Cost can not be less than or equal to 0");
            }
        }
    }
}
