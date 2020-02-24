using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Text lostText;

    public float force = 5;
    Rigidbody2D rb;
    public Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0);
    public int score;
    public Transform field;

    public static PlayerController instance;

    private void Awake()
    {
        if(instance == null)//instance hasn't been set yet
        {
            instance = this;//set instance to this object
            DontDestroyOnLoad(gameObject);//don't destroy this object when you load a new scene
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello,World");
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Vector2.Distance(field.position, transform.position);
        if (dist + transform.localScale.x/2 > 5)
        //if (transform.position.x - transform.localScale.x/2 < -5 || transform.position.x + transform.localScale.x / 2 > 5 || transform.position.y - transform.localScale.y / 2 < -5 || transform.position.y + transform.localScale.y / 2 > 5)
        {
            Debug.Log("out of boarder");
			lostText.text = "You Lost!";
			lostText.gameObject.SetActive(true);

		}
        else
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.AddForce(movement * force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.localScale += scaleChange;
    }
}
