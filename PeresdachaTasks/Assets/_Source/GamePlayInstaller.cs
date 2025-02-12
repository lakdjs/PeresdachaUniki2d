using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePlayInstaller : MonoInstaller
{
    [SerializeField] private Player playerPrefab;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private PlayerConfig playerConfig;

    public override void InstallBindings()
    {
        BindPlayer();
        BindMovement();
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
        Container.Bind<Movement>().AsSingle().NonLazy();
    }
}
