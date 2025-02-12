using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private Player player;
    [SerializeField] private Obstacle obstaclePrefab;
    [SerializeField] private ScoreView scoreView;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(player).AsSelf();
        builder.RegisterComponent(obstaclePrefab).AsSelf();
        builder.RegisterInstance(new Score(obstaclePrefab)).AsSelf();
        builder.RegisterComponent(scoreView).AsSelf();
        builder.RegisterInstance(new Movement(new DesktopInput(), player)).AsSelf();

        builder.RegisterFactory<Obstacle>(container =>
        {
            return () => Instantiate(obstaclePrefab);
        }, Lifetime.Transient);

        builder.RegisterFactory<Obstacle>(container =>
        {
            return () =>
            {
                var obstacle = Instantiate(obstaclePrefab);
                container.Inject(obstacle);
                return obstacle;
            };
        }, Lifetime.Transient);
    }
}
