using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private CubePool _cubePool;

    [SerializeField] private int _sleepingFrequency;

    void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            SpawnCube();

            yield return new WaitForSeconds(_sleepingFrequency);
        }
    }

    private void SpawnCube()
    {
        int numberCube = Random.Range(0, _spawnPoints.Count);
        Cube cube = _cubePool.GetCube(_spawnPoints[numberCube].transform.position);

        Vector3 derection = Random.insideUnitSphere;
        derection.y = 0;
        
        cube.SetDirection(derection);

        StartCoroutine(PushCube(cube));
    }

    private IEnumerator PushCube(Cube cube)
    {
        yield return new WaitForSeconds(5);

        _cubePool.Retern(cube);
    }
}