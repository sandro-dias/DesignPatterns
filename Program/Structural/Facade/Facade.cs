namespace DesignPatterns.Structural.Facade
{
    public class Facade
    {
        ///<summary>
        /// A ideia por trás do Facade é bastante simples.
        /// Pretendemos simplificar as dependências e interações de subsistemas da nossa aplicação em uma única classe, o Facade
        /// A ideia é que a classe cliente não precise ter essas dependências diretas, mas que chame o Facade para resolver o que for necessário para ela
        /// O propósito acaba sendo, então, de encapsular as dependências dentro do Facade, isolando uma potencial complexidade do código cliente
        /// É importante entender se o Facade introduz mais complexidade ou ajuda a abstrair a complexidade existente para facilitar o entendimento e manutenção do sistema
        /// Dentro dos conceitos de Clean Arch, um bom Facade seria aquele teria sua implementação reaproveitada por mais de um caso de uso, dentro em vista evitar a duplicação de código e delegar a lógica menos importante
        /// </summary>

        protected Subsystem1 _subsystem1 = new();
        protected Subsystem2 _subsystem2 = new();
        public Facade() {}

        public string Operation()
        {
            string result = "Facade initializes subsystems:\n";
            result += _subsystem1.Operation1();
            result += _subsystem2.Operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += _subsystem1.OperationN();
            result += _subsystem2.OperationZ();
            return result;
        }
    }

    public class Subsystem1
    {
        public string Operation1()
        {
            return "Subsystem1: Ready!\n";
        }

        public string OperationN()
        {
            return "Subsystem1: Go!\n";
        }
    }

    public class Subsystem2
    {
        public string Operation1()
        {
            return "Subsystem2: Get ready!\n";
        }

        public string OperationZ()
        {
            return "Subsystem2: Fire!\n";
        }
    }

    public static class Client
    {
        public static void ClientCode(Facade facade)
        {
            Console.WriteLine(facade.Operation());
        }
    }
}
