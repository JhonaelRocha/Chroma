using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float posX,posY,posZ;
    public float maxX,minX,maxZ,minZ;
    private float moveX,moveY,moveZ;
    void FixedUpdate()
    {
        
        moveX = Mathf.Lerp(transform.position.x,Mathf.Clamp(player.transform.position.x, minX, maxX),speed);
        moveY = Mathf.Lerp(transform.position.y,player.transform.position.y,speed);
        moveZ = Mathf.Lerp(transform.position.z,Mathf.Clamp(player.transform.position.z, minZ, maxZ),speed);

        transform.position = new Vector3(moveX + posX,moveY + posY,moveZ + posZ);
    }
}
