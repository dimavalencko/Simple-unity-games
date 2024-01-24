using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public Text countText, winText, remainText;
    private int countCoub;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        countCoub = GameObject.FindGameObjectsWithTag("cubes").Length;
        SetCount();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cubes")
        {
            Destroy(other.gameObject);
            count++;
            SetCount();
        }
    }

    private void SetCount()
    {
        countText.text = "Количество: " + count.ToString();
        remainText.text = $"Осталось: {countCoub - count}";
        if(count >= countCoub)
            winText.text = "Победа!!!";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
