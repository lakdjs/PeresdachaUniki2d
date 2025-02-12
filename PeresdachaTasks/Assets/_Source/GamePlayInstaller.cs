using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePlayInstaller : MonoInstaller
{
    [SerializeField] private Player playerPrefab;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private Obstacle obstacle;
    [SerializeField] private ScoreView scoreView;

    public override void InstallBindings()
    {
        BindPlayer();
        BindMovement();
        BindScore();
    }

    private void BindPlayer()
    {
        Container.Bind<PlayerConfig>().FromInstance(playerConfig);
        Player player = Container.InstantiatePrefabForComponent<Player>(playerPrefab,
                                                                      playerSpawnPoint.position,
                                                                      Quaternion.identity,
                                                                      null);
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();
    }

    private void BindMovement()
    {
        Container.BindInterfacesAndSelfTo<Movement>().AsSingle().NonLazy();
    }
    private void BindScore()
    {
        Container.Bind<Obstacle>().FromInstance(obstacle);
        Container.BindInterfacesAndSelfTo<Score>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ScoreView>().FromInstance(scoreView);
    }
}
