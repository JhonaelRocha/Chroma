using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNPC : MonoBehaviour
{
    public GameObject panel;
    public Vector3 offset = new Vector3(0f, 2f, 0f);
    private Camera mainCamera;
    public GameObject player;
    public float distaceToDialogue;

    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if(Vector3.Distance(player.transform.position,transform.position) < distaceToDialogue){
            panel.SetActive(true);
        }else{
            panel.SetActive(false);
        }
    }
    void LateUpdate()
    {
        if (panel != null && mainCamera != null){
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position + offset);
            panel.transform.position = screenPosition;
        }
    }
}
