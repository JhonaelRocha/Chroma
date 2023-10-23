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
    private Color[] colors = {Color.blue,Color.green,Color.red,Color.yellow,Color.white};
    private int colorValue;
    private bool isPainting;
    public static Brush instance;

    public bool getIsPainting(){
        return isPainting;
    }
    public void setIsPainting(bool isTrue){
        isPainting = isTrue;
    }
    public Brush getInstance(){
        return instance;
    }
    void Start(){
        anima = player.GetComponent<Anima>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        instance = this;
    }
    void FixedUpdate()
    {
        if(!isPainting){
            if(anima.getIsRight()){
                moveX = Mathf.Lerp(transform.position.x, player.transform.position.x - 0.5f, speed);
            }else{
                moveX = Mathf.Lerp(transform.position.x, player.transform.position.x + 0.5f, speed);
            }
        
            float moveY = Mathf.Lerp(transform.position.y, player.transform.position.y, speed);
            float moveZ = Mathf.Lerp(transform.position.z, player.transform.position.z + 0.25f, speed);
            transform.position = new Vector3(moveX,moveY,moveZ);
        }
        
    }
    void Update(){
        if(player.transform.position.x > transform.position.x){
            spriteRenderer.flipX = true;
        }else{
            spriteRenderer.flipX = false;
        }

        //Change Color MouseWheel
        float mouseWheel = Input.GetAxisRaw("Mouse ScrollWheel");

        if (mouseWheel > 0){
            colorValue = (colorValue + 1) % colors.Length;
        }else if (mouseWheel < 0){
            colorValue = (colorValue - 1 + colors.Length) % colors.Length;
        }

        spriteRenderer.color = colors[colorValue];
        
    }

    public void toPaint(GameObject obj){
        Vector3 targetPosition = obj.transform.position + new Vector3(0, 0.5f, -0.25f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * 3);
    }
}
