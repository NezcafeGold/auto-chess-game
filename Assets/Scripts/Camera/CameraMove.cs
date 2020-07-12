using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // public float dragSpeed = 2;
    // private Vector3 dragOrigin;
    //
    // public bool cameraDragging = true;
    //
    // public float outerLeft = -10f;
    // public float outerRight = 10f;
    //
    //
    // void Update()
    // {
    //     Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    
    //     float left = Screen.width * 0.2f;
    //     float right = Screen.width - (Screen.width * 0.2f);
    //    
    //     if(mousePosition.x < left)
    //     {
    //         cameraDragging = true;
    //     }
    //     else if(mousePosition.x > right)
    //     {
    //         cameraDragging = true;
    //     }
    //     
    //     if (cameraDragging) {
    //        
    //         if (Input.GetMouseButtonDown(0))
    //         {
    //             dragOrigin = Input.mousePosition;
    //             return;
    //         }
    //        
    //         if (!Input.GetMouseButton(0)) return;
    //        
    //         Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
    //         Vector3 move = new Vector3(pos.x * dragSpeed, 0, 0);
    //        
    //         if (move.x > 0f)
    //         {
    //             if(this.transform.position.x < outerRight)
    //             {
    //                 transform.Translate(move, Space.World);
    //             }
    //         }
    //         else{
    //             if(this.transform.position.x > outerLeft)
    //             {
    //                 transform.Translate(move, Space.World);
    //             }
    //         }
    //     }
    // }
    
    private Vector3 ResetCamera; // original camera position
    private Vector3 Origin; // place where mouse is first pressed
    private Vector3 Diference; // change in position of mouse relative to origin
    
    public float outerLeft = -5f;
    public float outerRight = 5f;
    public float outerUp= -2f;
    public float outerDown = 2f;
    
    void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }
    void LateUpdate()
    {
        if(Input.GetMouseButtonDown(2))
        {
            Origin = MousePos();
        }
        if (Input.GetMouseButton(2))
        {
            Diference = MousePos() - transform.position;
            
            
            transform.position = Origin - Diference;
            
            if (transform.position.x < outerLeft)
                transform.position = new Vector3(outerLeft, transform.position.y, transform.position.z);
            
            if (transform.position.x > outerRight)
                transform.position = new Vector3(outerRight, transform.position.y, transform.position.z);
            
            if (transform.position.y < outerDown)
                transform.position = new Vector3(transform.position.x, outerDown, transform.position.z);
            
            if (transform.position.y > outerUp)
                transform.position = new Vector3(transform.position.x, outerUp, transform.position.z);
            
        }
        if (Input.GetMouseButton(1)) // reset camera to original position
        {
            transform.position = ResetCamera;
        }
    }
    // return the position of the mouse in world coordinates (helper method)
    Vector3 MousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
