using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager bgm;
    // Start is called before the first frame update

    public Text infoText;
    private float timer = 0;

    private void Awake()
    {
        if (bgm == null)//instance hasn't been set yet
        {
            bgm = this;//set instance to this object
            DontDestroyOnLoad(gameObject);//don't destroy this object when you load a new scene
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        infoText.text = "Score:" + PlayerController.instance.score + "Time:" + (int)timer;
    }
}
