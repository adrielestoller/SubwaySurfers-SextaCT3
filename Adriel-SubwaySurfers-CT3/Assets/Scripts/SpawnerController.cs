using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lanes = new GameObject[3];
    private Vector3 offset;
    private float timer = 1f;

    void Start()
    {
        offset = transform.position + new Vector3(0f, 0f, transform.position.z + 10f);    
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Instantiate(lanes[Random.Range(0, 3)], offset, Quaternion.identity);
            timer = 3f;
        }
    }
}
