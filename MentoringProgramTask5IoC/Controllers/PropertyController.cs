using MentoringProgramTask5IoC.Logg;
using MentoringProgramTask5IoC.Repo;

namespace MentoringProgramTask5IoC.Controllers
{
    internal class PropertyController : IPropertyController
    {
        public ILogger Logg { get; set; }

        public IRepository Repo { get; set; }

        public void SimpleMethod()
        {
            Logg.Info(GetType().Name);
            Logg.Info("Process start");
            Repo.TestRepository1();
            Logg.Info($@"Repo out - {Repo.TestRepository2()}");
            Logg.Debug("Process stopped");
        } 
    }
}
