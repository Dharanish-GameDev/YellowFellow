using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField] float ForceMagnitude;  // how much for is applied to the object with rigidbody while hitting
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;  // getting the point that hits object 

            forceDirection.y = 0f;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection*ForceMagnitude,transform.position,ForceMode.Impulse);  // adding force at the point we get
        }
    }
}
