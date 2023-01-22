using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HHGroupCalculatorAPI.Services;
using HHGroupConvertorAPI.Models;
using HHGroupConvertorAPI.Models.Response;

namespace HHGroupConvertorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController: ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpPost]
        public  JobResponseModel CalculateJobTotal(JobCreateModel input)
        {
            return _calculatorService.Calculate(input);
        }
    }
}
