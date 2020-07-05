using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private Vector3 DestroyObstracle = new Vector3(-5, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObstracleMethod();
    }
    void DestroyObstracleMethod()
    {
        if(transform.position.x < DestroyObstracle.x)
        {
            Destroy(gameObject);
        }
    }
}
