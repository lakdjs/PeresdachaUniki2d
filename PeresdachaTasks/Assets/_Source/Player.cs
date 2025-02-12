using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IMovable
{
    public float JumpPower { get; private set; }
    public Transform Transform => transform;

    public Rigidbody2D RB { get; private set; }

    [Inject]
    private void Construct(PlayerConfig config)
    {
        JumpPower = config.JumpPower;
        RB = GetComponent<Rigidbody2D>();
    }
}
