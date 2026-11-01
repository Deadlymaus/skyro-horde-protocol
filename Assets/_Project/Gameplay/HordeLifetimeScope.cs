using VContainer;
using VContainer.Unity;

namespace HordeProtocol.Gameplay
{
    public class HordeLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameState>(Lifetime.Singleton);
            builder.Register<UI_References>(Lifetime.Singleton);
            builder.Register<EnemyObjectPooling>(Lifetime.Singleton);
            builder.Register<BulletObjectPooling>(Lifetime.Singleton);
        }
    }
}
