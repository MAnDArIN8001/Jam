using Zenject;

namespace Installers.Mono
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BaseInput>().FromNew().AsSingle().NonLazy();
        }
    }
}
