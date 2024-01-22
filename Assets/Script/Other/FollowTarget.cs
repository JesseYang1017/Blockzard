using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Vector3 offset;
    private Transform playerTransform;
    public float zoom_speed = 13;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        offset = transform.position - playerTransform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;
        float scroll_val = Input.GetAxis("Mouse ScrollWheel");
        if (Camera.main.fieldOfView + scroll_val * zoom_speed >= 25 && Camera.main.fieldOfView + scroll_val * zoom_speed <= 84){
            Camera.main.fieldOfView += scroll_val * zoom_speed;

        }
        

    }
}
