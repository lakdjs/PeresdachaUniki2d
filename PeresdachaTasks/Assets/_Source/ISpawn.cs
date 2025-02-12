using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawn
{
    GameObject prefabItem { get; }
    Transform[] spawnPoints { get;}
}
