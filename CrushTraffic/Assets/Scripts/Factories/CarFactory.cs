using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFactory : Factory
{
    public float SpawnTime = 5f;
    public float Spread = 1f;
    public float SpawnYOffset = 3f;

    public int CountOfSpawnedInOneTime = 1;

    public DynamicObject[] Cars;
    void Start()
    {
        for(int _ = 0; _ < CountOfSpawnedInOneTime; ++_)
        {
            Invoke("SpawnObject", GetRandomSpawnTime());
        }
    }    

    public float GetRandomSpawnTime()
    {
        return Random.Range(SpawnTime - Spread, SpawnTime + Spread);
    }

    DynamicObject GetRandomCar()
    {
        int indexOfCar = Random.Range(0, Cars.Length);
        return Cars[indexOfCar];
    }

    Vector3 GetRandomSpawnPoint()
    {
        var boxBounds = SpawnPoint.GetComponent<BoxCollider>().bounds;
        float randomX = Random.Range(boxBounds.min.x, boxBounds.max.x);

        Vector3 randomPosition = new Vector3(randomX,
                                            SpawnPoint.transform.position.y,
                                            SpawnPoint.transform.position.z);

        return randomPosition;
    }

    public override void SpawnObject()
    {
        DynamicObject car = Instantiate(GetRandomCar());
        Vector3 randomPoint = GetRandomSpawnPoint();

        float zSize = car.GetComponent<BoxCollider>().bounds.size.z;
        float ySize = car.GetComponent<BoxCollider>().bounds.size.y;

        Vector3 spawnPosition = new Vector3(randomPoint.x,
                                            randomPoint.y + SpawnYOffset,
                                            randomPoint.z + zSize);

        car.transform.position = spawnPosition;
        Invoke("SpawnObject", GetRandomSpawnTime());
    }
    public override void SpawnObject(Transform transform)
    {
        throw new System.NotImplementedException();
    }
}
