using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject player;
    public GameObject winTextObject;

    private Vector3 scaleChange, positionChange;
    private int count = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scaleChange = new Vector3(0.5f, 0.5f, 0.5f);
        positionChange = new Vector3(0.0f, 0.25f, 0.0f);

        SetCountText();
        winTextObject.SetActive(false);

    }

    //This function needed when ball moving
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        
    }

    void SetCountText()
    {
        if (count < 1)
        { countText.text = "Count: Stick" ; }
        if (count > 1 && count < 13)
        { countText.text = "Count: " + count.ToString();  }
        if (count == 13)
        { countText.text = "T H I C C"; }
        if (count >= 13)
        {
            winTextObject.SetActive(true);
        }

    }

    void FixedUpdate()
    {

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement *speed);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            player.transform.localScale += scaleChange;
            player.transform.position += positionChange;
            SetCountText();

        }
    }

    // Update is called once per frame
    /* 
      void Update()
     {

     }
     */
}
