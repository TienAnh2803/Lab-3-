using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int scoreValue = 10;
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Pinwheel"))
        {
            ScoreController.Instance.IncreaseScore(scoreValue);
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
}
