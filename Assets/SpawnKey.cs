using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    private Vector3[] spawnPositions = {
        new Vector3(17, 0, 114),
        new Vector3(4, 0, 94),
        new Vector3(-3, 0, 62),
        new Vector3(-8.085f, 1.313f, 4.214f),
        new Vector3(10.687f, 0.69f, 4.886f),
        new Vector3(9, 0, 25)
    };
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];
        this.gameObject.transform.position = spawnPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
