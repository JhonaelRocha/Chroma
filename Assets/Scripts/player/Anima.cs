using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anima : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Movements movements;
    private bool isRight;
    private Rigidbody rb;
    public bool getIsRight(){
        return isRight;
    }
    public void setIsRight(bool isRight){
        this.isRight = isRight;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isRight = true;
        anim = GetComponent<Animator>();
        movements = GetComponent<Movements>();
    }

    void Update()
    {
        if(movements.inFloor){ //Se estiver no chão
            if(movements.getMoveH() != 0){ //Se não está parado Horizontalmente X
                if(movements.getMoveH() > 0){ //indo para direita
                    anim.SetInteger("int",1); 
                    isRight = true;
                }
                if(movements.getMoveH() < 0){ //indo para esquerda
                    anim.SetInteger("int",2);
                    isRight = false;
                }
            }else if(movements.getMoveV() != 0){ //Se não está parado Horizontalmente Z
                if(isRight){ //Manter a direita 
                    anim.SetInteger("int",1); 
                }else{ //Manter a esquerda
                    anim.SetInteger("int",2);
                }
            }else if(isRight){ //Se está parado
                anim.SetInteger("int",11);
            }else{
                anim.SetInteger("int",12);
            }
        }else{ //Se não estiver no chão
            if(movements.getMoveH() != 0){ //Se não está parado Horizontalmente X
                if(movements.getMoveH() > 0){ //indo para direita
                    isRight = true;
                    if(rb.velocity.y > 0){ //Se está subindo
                        anim.SetInteger("int",21); 
                    }else{ //Se está descendo
                        anim.SetInteger("int",31); 
                    }
                    
                }
                if(movements.getMoveH() < 0){ //indo para esquerda
                    isRight = false;
                    if(rb.velocity.y > 0){ //Se está subindo
                        anim.SetInteger("int",22);
                    }else{ //Se está descendo
                        anim.SetInteger("int",32);
                    }
                    
                }
            }else if(movements.getMoveV() != 0){ //Se não está parado verticalmente Z
                if(isRight){ //Manter a direita 
                    if(rb.velocity.y > 0){ //Se está subindo
                        anim.SetInteger("int",21); 
                    }else{ //Se está descendo
                        anim.SetInteger("int",31); 
                    }
                    
                }else{ //Manter a esquerda
                    if(rb.velocity.y > 0.5f){ //Se está subindo
                        anim.SetInteger("int",22);
                    }else{ //Se está descendo
                        anim.SetInteger("int",32);
                    }
                    
                }
            }else if(isRight){ //Se está parado
                if(rb.velocity.y > 0.5f){ //Se está subindo
                        anim.SetInteger("int",21); 
                    }else{ //Se está descendo
                        anim.SetInteger("int",31); 
                    }
            }else{
                if(rb.velocity.y > 0.5f){ //Se está subindo
                        anim.SetInteger("int",22);
                    }else{ //Se está descendo
                        anim.SetInteger("int",32);
                    }
            }
        }
        
        
    }
}
