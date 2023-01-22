using System;
using System.Collections.Generic;
using HHGroupCalculatorAPI.Validators;
using HHGroupConvertorAPI.Models;
using HHGroupConvertorAPI.Models.Configuration;
using HHGroupConvertorAPI.Services;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HHGroupCalculatTests
{
    [TestClass]
    public class CalculatorServiceTest
    {
        private CalculatorService _service;
        public CalculatorServiceTest()
        {
            var validator = new Validator();

            var options = Options.Create(new CalculatorConfigModel()
            {
                Margin = (decimal)0.11,
                ExtraMargin = (decimal)0.05,
                Tax = (decimal)0.07
            });

            _service = new CalculatorService(options,validator);

        }

        [TestMethod]
        public void CostShouldNotBeZeroTest()
        {
            var model = new JobCreateModel()
            {
                HasExtraMargin = false,
                Items = new List<ItemModel>()
                {
                    new ItemModel()
                    {
                        Cost = 0,
                        Name = "Test"
                    }
                }
            };

            var result = Assert.ThrowsException<ArgumentException>(() => _service.Calculate(model));
            Assert.AreEqual(result.Message, "Cost can not be less than or equal to 0");
        }

        [TestMethod]
        public void ShouldCalculateTotal1()
        {
            var model = new JobCreateModel()
            {
                HasExtraMargin = true,
                Items = new List<ItemModel>()
                {
                    new ItemModel()
                    {
                        Cost = (decimal)520.00,
                        Name = "envelopes",
                        IsExempt = false
                    },
                    new ItemModel()
                    {
                        Cost = (decimal)1983.37,
                        Name = "letterhead",
                        IsExempt = true
                    }
                }
            };
            var result = _service.Calculate(model);
            Assert.AreEqual((decimal)2940.30, result.Total );
        }

        [TestMethod]
        public void ShouldCalculateTotal2()
        {
            var model = new JobCreateModel()
            {
                HasExtraMargin = false,
                Items = new List<ItemModel>()
                {
                    new ItemModel()
                    {
                        Cost = (decimal)294.04,
                        Name = "t-shirts",
                        IsExempt = false
                    }
                }
            };
            var result = _service.Calculate(model);
            Assert.AreEqual((decimal)346.96, result.Total);
        }

        [TestMethod]
        public void ShouldCalculateTotal3()
        {
            var model = new JobCreateModel()
            {
                HasExtraMargin = true,
                Items = new List<ItemModel>()
                {
                    new ItemModel()
                    {
                        Cost = (decimal)19385.38,
                        Name = "frisbees",
                        IsExempt = true
                    },
                    new ItemModel()
                    {
                        Cost = (decimal)1829,
                        Name = "yo-yos",
                        IsExempt = true
                    }
                }
            };
            var result = _service.Calculate(model);
            Assert.AreEqual((decimal)24608.68, result.Total);
        }
    }
}
