namespace CalculatorAPI.Domain
{
    public interface ICalculatorRepository
    {
        void AddCalculation(Calculation item);
        Calculation GetCalculation(int id);
        List<Calculation> GetAllCalculations();

    }
}
