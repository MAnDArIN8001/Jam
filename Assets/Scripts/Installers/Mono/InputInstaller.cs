using Zenject;

namespace Installers.Mono
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var baseInput = new BaseInput();
            
            Container.Bind<BaseInput>().FromInstance(baseInput).AsSingle().NonLazy();
            
            baseInput.Enable();
        }
    }
}
