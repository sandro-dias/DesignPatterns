namespace DesignPatterns.Creational.AbstractFactory
{
    public class AbstractFactoryClient
    {
        ///<summary>
        /// A ideia por trás da AbstractFactory é fornecer uma classe abstrata que permita instanciar uma família de classes concretas através de uma interface base
        /// O interessante é a ideia de delegar e separar a responsabilidade de escolher quem será instanciado e a execução da instância propriamente dita, isolando-a
        /// É importante observar que através da assinatura da AbstractFactory estamos acoplando a família de classes a serem criado, o que é um trade-off intencional  
        /// </summary>
        
        public void ExecuteFactory()
        {
            AbstractFactory factory = new ConcreteFactory1();
            var objectA = factory.CreateObjectA();
            var objectB = factory.CreateObjectB();
            objectA.DoSomething(factory.GetType().Name);
            objectB.DoSomethingElse(factory.GetType().Name, objectA);

            factory = new ConcreteFactory2();
            objectA = factory.CreateObjectA();
            objectB = factory.CreateObjectB();
            objectA.DoSomething(factory.GetType().Name);
            objectB.DoSomethingElse(factory.GetType().Name, objectA);
        }
    }

    public abstract class AbstractFactory
    {
        public abstract IAbstractObjectA CreateObjectA();
        public abstract IAbstractObjectB CreateObjectB();
    }

    public class ConcreteFactory1 : AbstractFactory
    {
        public override IAbstractObjectA CreateObjectA()
        {
            return new ConcreteObjectA1();
        }

        public override IAbstractObjectB CreateObjectB()
        {
            return new ConcreteObjectB1();
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override IAbstractObjectA CreateObjectA()
        {
            return new ConcreteObjectA2();
        }

        public override IAbstractObjectB CreateObjectB()
        {
            return new ConcreteObjectB2();
        }
    }

    public interface IAbstractObjectA
    {
        public void DoSomething(string name);
        public string GetName();
    }

    public interface IAbstractObjectB
    {
        public void DoSomethingElse(string name, IAbstractObjectA objectA);
    }

    public class ConcreteObjectA1 : IAbstractObjectA
    {
        public void DoSomething(string name)
        {
            Console.WriteLine($"I, {nameof(ConcreteObjectA1)}, was created by {name}");
        }

        public string GetName()
        {
            return nameof(ConcreteObjectA1);
        }
    }

    public class ConcreteObjectA2 : IAbstractObjectA
    {
        public void DoSomething(string name)
        {
            Console.WriteLine($"I, {nameof(ConcreteObjectA2)}, was created by {name}");
        }

        public string GetName()
        {
            return nameof(ConcreteObjectA2);
        }
    }

    public class ConcreteObjectB1 : IAbstractObjectB
    {
        public void DoSomethingElse(string name, IAbstractObjectA objectA)
        {
            Console.WriteLine($"And I, {nameof(ConcreteObjectB1)}, was created by {name} after {objectA.GetName()}");
        }
    }

    public class ConcreteObjectB2 : IAbstractObjectB
    {
        public void DoSomethingElse(string name, IAbstractObjectA objectA)
        {
            Console.WriteLine($"And I, {nameof(ConcreteObjectB2)}, was created by {name} after {objectA.GetName()}");
        }
    }
}
