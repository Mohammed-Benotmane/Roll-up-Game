using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCount();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        print(movement);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Ups"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCount();
        }

    }
   void SetCount()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 15)
        {
            winText.text = "You Win ^^ Bsa7tek";
        }
    }
}
