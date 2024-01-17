namespace DesignPatterns.Behavioral.Strategy
{
    public class Context
    {
        ///<summary>
        /// A ideia por trás do Strategy é definir uma interface com um método
        /// Essa interface é implementada por diferentes classes que encapsulam diferentes algoritmos
        /// Esses diferentes algoritmos usam o mesmo input, retornam o mesmo output, mas tem regras diferentes
        /// A ideia é que a classe Context tenha a classe concreta fornecida por seu construtor ou um método que Set o Strategy desejado
        /// Em teoria, Context delega a execução propriamente dita da lógica de negócio
        /// É possível aproveitar esse comportamento e tomar uma decisão em tempo de execução sobre qual classe concreta passar
        /// </summary>
        
        private IStrategy? _strategy;

        public Context() { }

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Context: Executing payment");
            _strategy!.ExecutePayment();
        }
    }

    public interface IStrategy
    {
        void ExecutePayment();
    }

    class PaymentByCreditCard : IStrategy
    {
        public void ExecutePayment()
        {
            Console.WriteLine($"...by strategy: {nameof(PaymentByCreditCard)}");
            // CreditCard payment business rules
        }
    }

    class PaymentByPix : IStrategy
    {
        public void ExecutePayment()
        {
            Console.WriteLine($"...by strategy: {nameof(PaymentByPix)}");
            // Pix payment business rules
        }
    }

    class PaymentByBankSlip : IStrategy
    {
        public void ExecutePayment()
        {
            Console.WriteLine($"...by strategy: {nameof(PaymentByBankSlip)}");
            // Pix payment business rules
        }
    }

    public class StrategyProgram
    {
        public void Main()
        {
            var context = new Context();

            context.SetStrategy(new PaymentByCreditCard());
            context.DoSomeBusinessLogic();

            context.SetStrategy(new PaymentByPix());
            context.DoSomeBusinessLogic();

            context.SetStrategy(new PaymentByBankSlip());
            context.DoSomeBusinessLogic();
        }
    }
}
