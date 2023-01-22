using System;
using HHGroupCalculatorAPI.Services;
using HHGroupCalculatorAPI.Validators;
using HHGroupConvertorAPI.Models;
using HHGroupConvertorAPI.Models.Configuration;
using HHGroupConvertorAPI.Models.Response;
using Microsoft.Extensions.Options;

namespace HHGroupConvertorAPI.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly CalculatorConfigModel _configs;
        private readonly IValidator _validator;

        public CalculatorService(IOptions<CalculatorConfigModel> converterOptions, IValidator validator)
        {
            _validator = validator;
            _configs = converterOptions.Value;
        }


        public JobResponseModel Calculate(JobCreateModel model)
        {
            var result = new JobResponseModel();

            decimal total = 0;
            decimal extraMargin = 0;

            if (model.HasExtraMargin)
                extraMargin = _configs.ExtraMargin;

            foreach (var item in model.Items)
            {
                var cost = item.Cost;

                if (!item.IsExempt)
                    cost += cost * _configs.Tax;

                result.Items.Add(new ItemModel()
                {
                    Cost = Math.Round(cost, 2),
                    Name = item.Name
                });

                cost += (item.Cost * _configs.Margin + item.Cost * extraMargin);

                total += cost;
            }

            result.Total = (0.02m / 1.00m) * decimal.Round(total * (1.00m / 0.02m));

            _validator.Validate(model);

            return result;
        }
    }
}
