using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SquareController : MonoBehaviour
{
    // Update is called once per frame
    public float timeRemaining = 60;
    public Text countdownText;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    private Vector2 shootDirection;
    private Quaternion bulletDirection;
    public Transform spawn;

    void Start()
    {
        StartCoroutine(Countdown());
        shootDirection = Vector2.right;
        bulletDirection = Quaternion.Euler(0f, 0f, 0f);
    }
    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            countdownText.text = "Time: " + timeRemaining.ToString();
        }
        countdownText.text = "Time's up!";
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal < 0)
        {
            shootDirection = Vector2.left;
            bulletDirection = Quaternion.Euler(0f, 0f, 180f);
        }
        else if (horizontal > 0)
        {
            shootDirection = Vector2.right;
            bulletDirection = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (vertical < 0)
        {
            shootDirection = Vector2.down;
            bulletDirection = Quaternion.Euler(0f, 0f, 270f);
        }
        else if (vertical > 0)
        {
            shootDirection = Vector2.up;
            bulletDirection = Quaternion.Euler(0f, 0f, 90f);
        }
        

        // Bắn đạn khi người chơi nhấn Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        Vector3 movement = new Vector3(x: horizontal, y: vertical, z: 0f).normalized;
        transform.Translate(movement * 4f * Time.deltaTime);
    }
    public void LoadNextSence()
    {
        int currentSenceIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSenceIndex + 1);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Circle"))
        {
            Debug.Log("xxxx");
            transform.position = spawn.position;
        }
        if (col.gameObject.name.Equals("Box"))
        {
            Debug.Log("Win");
            LoadNextSence();
        }
        if (col.gameObject.name.Equals("Pinwheel"))
        {
            Debug.Log("xxx");
            Vector2 Position = new Vector2(-7, 1);
            transform.position = (Vector3)Position;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MapEdge"))
        {
            Debug.Log("xxx");
            Vector2 fistPosition = new Vector2(-7, 1);
            transform.position = fistPosition;
        }
    }
    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        Transform bulletTf = newBullet.GetComponent<Transform>();
        if (bulletRb != null)
        {
            bulletRb.velocity = shootDirection * bulletSpeed;  // Bắn theo hướng "up" của GameObject
            bulletTf.rotation = bulletDirection;
        }

    }
}


