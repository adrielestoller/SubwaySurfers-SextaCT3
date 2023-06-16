using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBehaviour : MonoBehaviour
{
    private float speed = 3f;

    void Start()
    {
        Destroy(this.gameObject, 10f);    
    }

    void Update()
    {
        transform.position -= new Vector3(0f, 0f, speed) * Time.deltaTime;
    }
}
