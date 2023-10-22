using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Brush : MonoBehaviour
{
    public float speed;
    public GameObject player;
    private Anima anima;
    private float moveX = 0;
    private SpriteRenderer spriteRenderer;
    public Color color;
    void Start(){
        anima = player.GetComponent<Anima>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if(anima.getIsRight()){
            moveX = Mathf.Lerp(transform.position.x, player.transform.position.x - 0.5f, speed);
        }else{
            moveX = Mathf.Lerp(transform.position.x, player.transform.position.x + 0.5f, speed);
        }
        
        float moveY = Mathf.Lerp(transform.position.y, player.transform.position.y, speed);
        float moveZ = Mathf.Lerp(transform.position.z, player.transform.position.z + 0.25f, speed);
        transform.position = new Vector3(moveX,moveY,moveZ);
    }
    void Update(){
        spriteRenderer.color = color;
        /*
        if(player.transform.position.x > transform.position.x){
            spriteRenderer.flipX = true;
        }else{
            spriteRenderer.flipX = false;
        }
        */
    }
}
