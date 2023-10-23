using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject brush;
    private bool isBePainted;
    public static DefaultObject instance;
    public Color defaultColor;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(brush.GetComponent<Brush>().getIsPainting()){
            brush.GetComponent<Brush>().toPaint(instance.gameObject);
        }
    }
    void OnMouseDown(){
        if(!brush.GetComponent<Brush>().getIsPainting()){
            StartCoroutine("bePainted");
            instance = this;
            brush.GetComponent<Brush>().setIsPainting(true);
        }
        
    }
    IEnumerator bePainted(){
        yield return new WaitForSeconds(0.3f);
        brush.GetComponent<Animator>().SetInteger("int",1);
        yield return new WaitForSeconds(0.7f);
        brush.GetComponent<Animator>().SetInteger("int",0);
        spriteRenderer.color = brush.GetComponent<SpriteRenderer>().color;
        brush.GetComponent<Brush>().setIsPainting(false);
    }
}
