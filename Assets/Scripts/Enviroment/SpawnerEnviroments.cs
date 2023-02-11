using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnviroments : MonoBehaviour
{
    public float[] valuePositions;
    public GameObject[] enviroments;

    void Start()
    {
        int amountPlants = Random.Range(4, 10);
        for (int i = 0; i<=amountPlants; i++)
        {
            int xIndex = Random.Range(0, valuePositions.Length);
            int yIndex = Random.Range(0, valuePositions.Length);
            int envIndex = Random.Range(0, enviroments.Length);
            Instantiate(enviroments[envIndex], new Vector3(valuePositions[xIndex], valuePositions[yIndex], 0f), Quaternion.identity);
        }
    }
}
