using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IMovable
{
    public float JumpPower { get; private set; }
    public Transform Transform => transform;

    [Inject]
    private void Construct(PlayerConfig config)
    {
        JumpPower = config.JumpPower;
    }
}
