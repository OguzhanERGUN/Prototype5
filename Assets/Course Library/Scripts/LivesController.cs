using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    public static int lives;
    public TextMeshProUGUI livesText;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        livesText.text = "Lives: " + lives;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Bad")
        {
            lives--;
            livesText.text = "Lives: " + lives;

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
