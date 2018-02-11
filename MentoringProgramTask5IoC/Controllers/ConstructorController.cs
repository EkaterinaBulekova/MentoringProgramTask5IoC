using MentoringProgramTask5IoC.Logg;
using MentoringProgramTask5IoC.Repo;

namespace MentoringProgramTask5IoC.Controllers
{
    internal class ConstructorController : IConstructorController
    {
        private readonly ILogger _logg;
        private readonly IRepository _repo;

        public ConstructorController(ILogger logg, IRepository repo)
        {
            _logg = logg;
            _repo = repo;
        }

        public void SimpleMethod()
        {
            _logg.Info(GetType().Name);
            _logg.Debug("Process start");
            _repo.TestRepository1();
            _logg.Info($@"Repo out - {_repo.TestRepository2()}");
            _logg.Debug("Process stopped");
        } 
    }
}
