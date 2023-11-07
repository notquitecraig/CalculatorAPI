using CalculatorAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/calculator")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorRepository _calculatorRepository;

        public CalculatorController(ICalculatorRepository calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }

        [HttpGet("add")]
        public IActionResult Add(int a, int b)
        {
            int result = a + b;
            LogCalculation(a, b, "add", result);
            return Ok(result);
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(int a, int b)
        {
            int result = a - b;
            LogCalculation(a, b, "subtract", result);
            return Ok(result);
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(int a, int b)
        {
            int result = a * b;
            LogCalculation(a, b, "multiply", result);
            return Ok(result);
        }


        private void LogCalculation(int value1, int value2, string operation, int result)
        {
            var calculation = new Calculation
            {
                Value1 = value1,
                Value2 = value2,
                Operation = operation,
                Result = result
            };

            _calculatorRepository.AddCalculation(calculation);
        }
    }
}
