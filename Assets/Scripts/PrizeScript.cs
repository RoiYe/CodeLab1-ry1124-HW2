using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrizeScript : MonoBehaviour
{
    public static int currentLevel = 0;
    public int targetScore;

    // Start is called before the first frame update
    void Start()
    {
        targetScore = PlayerController.instance.score * 2 + 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController.instance.score++;
        transform.position = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1);

        if(PlayerController.instance.score > targetScore)
        {
            currentLevel++;
            SceneManager.LoadScene(currentLevel);
        }
        }
    }
