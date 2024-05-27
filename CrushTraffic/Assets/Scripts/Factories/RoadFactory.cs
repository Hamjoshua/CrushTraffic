using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadFactory : Factory
{
    public DynamicObject Road;

    public override void SpawnObject(Transform otherTransform)
    {
        DynamicObject newRoad = Instantiate(Road, SpawnPoint.transform.position, Quaternion.identity);

        float zSize = newRoad.GetComponent<BoxCollider>().bounds.size.z;
        float shiftZ = (newRoad.Speed + GameManager.Instance.GlobalSpeed) / 50;

        Vector3 spawnPosition = new Vector3(otherTransform.localPosition.x,
                                            otherTransform.localPosition.y,
                                            otherTransform.localPosition.z + zSize - shiftZ);

        newRoad.ActionsOnBottomTouch.AddListener(delegate { SpawnObject(newRoad.transform); });
        newRoad.transform.position = spawnPosition;
    }

    public override void SpawnObject()
    {
        SpawnObject(SpawnPoint.transform);
    }
}
