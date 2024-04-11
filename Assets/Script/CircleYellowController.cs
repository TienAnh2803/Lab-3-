using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleYellowController : MonoBehaviour
{
    
    private int direction = 1;
    private float moveSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        Vector3 movement = new Vector3(0f, direction, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        if (transform.position.y > 1.0f || transform.position.y < -1.0f)
        {
            direction *= -1;
        }

    }
}

