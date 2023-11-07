using CalculatorAPI.Domain;

namespace CalculatorAPI.Services
{
    public class CalculatorRepository : ICalculatorRepository
    {
        private readonly CalculatorDbContext _context;

        public CalculatorRepository(CalculatorDbContext context)
        {
            _context = context;
        }

        public void AddCalculation(Calculation item)
        {
            _context.Calculations.Add(item);
            _context.SaveChanges();
        }

        public List<Calculation> GetAllCalculations()
        {
            return _context.Calculations.ToList();
        }

        public Calculation GetCalculation(int id)
        {
            var item = _context.Calculations.FirstOrDefault(c => c.Id == id);
            return item ?? new NullCalculation();
        }
    }
}
