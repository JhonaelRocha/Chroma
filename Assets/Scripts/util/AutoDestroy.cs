using System.Collections;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float timeToDestroy;
    void Start()
    {
        StartCoroutine("autoDestroy");
    }
    IEnumerator autoDestroy(){
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(this.gameObject);
    }
}
