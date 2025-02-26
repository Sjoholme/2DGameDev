using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBasic : MonoBehaviour
{
    public Transform camera;
    public float relativeMove = .3f;
    public bool lockY = false;
     

    void Update()
    {
        if(lockY)
        {
            transform.position = new Vector2(camera.position.x * relativeMove, transform.position.y);
        }else
        {
            transform.position = new Vector2(camera.position.x * relativeMove, camera.position.y * relativeMove);
        }
        
    }
}
