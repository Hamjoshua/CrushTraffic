using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    public GameObject SpawnPoint;

    public abstract void SpawnObject();
    public abstract void SpawnObject(Transform otherTransform);
}
