using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private float moveH,moveV;

    public float getMoveH(){
        return moveH;
    }
    public float getMoveV(){
        return moveV;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");

        Vector3 vectorMovement = new Vector3(moveH,0, moveV);

        rb.velocity = vectorMovement.normalized * speed;
    }
}
