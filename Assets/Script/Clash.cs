using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Vacham : MonoBehaviour
{    
    public TextMeshProUGUI Score;
    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        Score.text = " " + playerData.playerScore;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gold"))
        {
            playerData.playerScore++;
            Score.text = " " + playerData.playerScore;            
            Destroy(collision.gameObject);
        }
    }
}
