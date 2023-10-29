using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private float moveX,moveY,moveZ;

    //Jump
    public float jumpForce;
    public bool inFloor;
    public bool nextWallRight, nextWallLeft, nextWallBack, nextWallFront;
    public float jumpTime;
    public float gravityForce;
    private Vector3 vectorMovement;
    public Transform groundCheckRight, groundCheckLeft;
    public Transform wallCheckRight, wallCheckLeft, wallCheckBack, wallCheckFront;
    public LayerMask groundLayer;
    private Anima anima;

    //Particles
    public GameObject jumpParticle;

    public float getMoveH(){
        return moveX;
    }
    public float getMoveV(){
        return moveZ;
    }

    void Start()
    {
        anima = GetComponent<Anima>();
        rb = GetComponent<Rigidbody>();
        moveY = 0;
        vectorMovement = new Vector3(moveX,moveY, moveZ);
    }
    void FixedUpdate()
    {

        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        nextWallRight = Physics.Linecast(transform.position, wallCheckRight.position, groundLayer);
        nextWallLeft = Physics.Linecast(transform.position, wallCheckLeft.position, groundLayer);
        nextWallBack = Physics.Linecast(transform.position, wallCheckBack.position, groundLayer);
        nextWallFront = Physics.Linecast(transform.position, wallCheckFront.position, groundLayer);
        
        if(nextWallLeft && moveX < 0){
            anima.setIsRight(false);
            moveX = 0;
        }else if(nextWallRight && moveX > 0){
            anima.setIsRight(true);
            moveX = 0;
        }else if(nextWallBack && moveZ > 0){
            moveZ = 0;
        }else if(nextWallFront && moveZ < 0){
            moveZ = 0;
        }
        Vector2 normalizedXZ = new Vector2(moveX, moveZ).normalized;
        vectorMovement = new Vector3(normalizedXZ.x, moveY, normalizedXZ.y) * speed;
        rb.velocity = vectorMovement * speed;

        inFloor = Physics.Linecast(transform.position, groundCheckRight.position, groundLayer) || Physics.Linecast(transform.position, groundCheckLeft.position, groundLayer);
        
        Debug.DrawLine(wallCheckLeft.position, wallCheckRight.position, Color.red);

        rb.AddForce(Vector3.down * gravityForce, ForceMode.Acceleration);
        
    }
    IEnumerator Pulando(){
        moveY = jumpForce;
        yield return new WaitForSeconds(jumpTime/4);
        moveY = jumpForce;
        yield return new WaitForSeconds(jumpTime/4);
        moveY = jumpForce / 2;
        yield return new WaitForSeconds(jumpTime/4);
        moveY = jumpForce / 4;    
        yield return new WaitForSeconds(jumpTime/4);
        moveY = 0;
    }
    void Update(){
        
        if(Input.GetKeyDown(KeyCode.Space) && inFloor){
            StartCoroutine("Pulando");
            Instantiate(jumpParticle, new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z), Quaternion.identity);
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            StopCoroutine("Pulando");
            moveY = 0;
        }
    }
}
