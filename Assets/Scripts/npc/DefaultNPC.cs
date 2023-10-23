using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultNPC : MonoBehaviour
{
    public GameObject player;
    private bool isSolved;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSolved){
            if(transform.position.x < player.transform.position.x){
                anim.SetInteger("int",11);
            }else{
                anim.SetInteger("int",12);
            }
        }else{
            if(transform.position.x < player.transform.position.x){
                anim.SetInteger("int",1);
            }else{
                anim.SetInteger("int",2);
            }
        }
    }
    void OnMouseDown(){
        isSolved = true;
    }
}
