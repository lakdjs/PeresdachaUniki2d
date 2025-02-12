using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable 
{
    float JumpPower { get; }
    Transform Transform { get; }
    Rigidbody2D RB { get; }
}
