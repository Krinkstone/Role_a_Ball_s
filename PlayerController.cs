using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Globalization;
using System.Security.Cryptography;
using System.Collections.Specialized;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public float jumpPower = 1f;
    private Vector3 MoveDirection;

    private bool jump;
    private bool isGrounded;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        jump = Input.GetButton("Jump");

        MoveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
    }

    void FixedUpdate()
    {
        Jump();
        Move();
    }

    void Move()
    {
        rb.AddForce(MoveDirection * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUpp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();
        }
    }
     
    void setCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 19)
        {
            winText.text = "You WIN!";
        }
    }

    void Jump()
    {   
        LayerMask layer = 1 << gameObject.layer;
        layer = ~layer;
        isGrounded = Physics.CheckSphere(transform.position, 0.8f, layer);
        
        if (jump && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}