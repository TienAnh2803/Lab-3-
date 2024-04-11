using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSliderController : MonoBehaviour
{
    public Slider slider;
    private bool isGameOver = false;
    public Canvas gameOverCanvas;
    // Start is called before the first frame update
    private void Start()
    {
        slider.value = 10f;
        gameOverCanvas.gameObject.SetActive(false);
    }
    void Update()
    {
      if(!isGameOver&& slider.value <= 0)
        {
            GameOver();
        }
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pinwheel"))
        {
            Debug.Log("Pinwheel");
            slider.value--;
        }
    }
    void GameOver()
    {
        isGameOver = true;
        gameOverCanvas.gameObject.SetActive(true);
    }
}
