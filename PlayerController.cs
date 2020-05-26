using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Globalization;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public bool onGround;

    private Rigidbody rb;
    private int count;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 41)
        {
            winText.text = "You Win!";
        }
    }

    private void Update()
    {
        if (onGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(0f, 10f, 0f, ForceMode.Impulse);
                onGround = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}