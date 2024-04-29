using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRecentre : MonoBehaviour
{
    private CinemachineFreeLook F_camera;
    void Start()
    {
        F_camera= GetComponent<CinemachineFreeLook>();
    }

   
    void Update()
    {                                                                                // In Controller Right Button
        if(Input.GetKey(KeyCode.LeftControl)||Input.GetAxis("CameraRecentre")==1)   // Moving the camera towards the character facing
        {
            F_camera.m_RecenterToTargetHeading.m_enabled = true;
        }
        else F_camera.m_RecenterToTargetHeading.m_enabled= false;
    }
    
}
