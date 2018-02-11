using System;
using MentoringProgramTask5IoC.Controllers;
using MentoringProgramTask5IoC.Infrastructure;

namespace MentoringProgramTask5IoC
{
    internal class Program
    {
        private static IConstructorController _constructorController;
        private static IPropertyController _propertyController;

        static void Main()
        {
            InitialMethod();
            _constructorController.SimpleMethod();
            _propertyController.SimpleMethod();

            Console.ReadLine();
        }

        static void InitialMethod()
        {
            var cont = new ContainerModule().GetConfiguredContainer();
            _constructorController = cont.Create<IConstructorController>();
            _propertyController = cont.Create<IPropertyController>();
        }
    }
}
