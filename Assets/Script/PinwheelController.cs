using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Yellow;
    public float rotationSpeed =  100f ;
    private int direction = 1;
    private float moveSpeed = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0f, direction, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        if (transform.position.y > 2.0f || transform.position.y < -2.0f)
        {
            direction *= -1;
        }
        Quaternion deltaRotation = Quaternion.Euler(0, 0,rotationSpeed* Time.deltaTime ) ;
        transform.rotation = transform.rotation * deltaRotation;
    }
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("bullet"))
        {
            Instantiate(Yellow, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

