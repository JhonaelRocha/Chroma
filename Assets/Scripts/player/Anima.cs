using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anima : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Movements movements;
    private bool isRight;
    void Start()
    {
        isRight = true;
        anim = GetComponent<Animator>();
        movements = GetComponent<Movements>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movements.getMoveH() != 0 || movements.getMoveV() != 0){
            if(movements.getMoveH() > 0){
                
                 anim.SetInteger("int",1); 
                 isRight = true;
            }
            if(movements.getMoveH() < 0){
                anim.SetInteger("int",2);
                isRight = false;
            }  
        }else if(isRight){
            anim.SetInteger("int",11);
        }else{
            anim.SetInteger("int",12);
        }
        
    }
}
