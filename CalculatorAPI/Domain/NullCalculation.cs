namespace CalculatorAPI.Domain
{
    public class NullCalculation : Calculation
    {
        public NullCalculation() {
            Id = -1;
            Value1 = 0;
            Value2 = 0;
            Operation = String.Empty;
            Result = 0;
        }
    }
}
