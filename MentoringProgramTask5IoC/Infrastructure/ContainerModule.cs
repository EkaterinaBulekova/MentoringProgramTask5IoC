using System;
using System.Collections.Generic;
using MentoringProgramTask5IoC.IoC;
using MentoringProgramTask5IoC.Logg;
using MentoringProgramTask5IoC.Repo;
using MentoringProgramTask5IoC.Controllers;

namespace MentoringProgramTask5IoC.Infrastructure
{
    internal class ContainerModule : IContainerModule
    {
        public Container GetConfiguredContainer()
        {
            var cont = new Container();
            cont.Configuration.Add("ControllerProperty", new Dictionary<string, Type>
                { { "Logg", typeof(ILogger) }, { "Repo", typeof(IRepository) } });
            cont.Register<IRepository, Repository>();
            cont.Register<ILogger, Logger>("DEBUG - ", "INFO - ");
            cont.Register<IConstructorController, ConstructorController>(typeof(ILogger), typeof(IRepository));
            cont.Register<IPropertyController, PropertyController>(cont.Configuration["ControllerProperty"]);
            return cont;
        }
    }
}
