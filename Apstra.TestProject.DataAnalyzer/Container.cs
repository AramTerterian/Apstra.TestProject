using Apstra.TestProject.DataAnalyzer.Interfaces;
using Ninject.Modules;

namespace Apstra.TestProject.DataAnalyzer
{
    public class SimpleConfigModule : NinjectModule, IContainer
    {
        public override void Load()
        {
            Bind<ILoader>().To<Loader>();
            Bind<IExtension>().To<Extension>();
            Bind<IAnalyzer>().To<Analyzer>();
            Bind<IProcessor>().To<Processor>();
        }
    }
}