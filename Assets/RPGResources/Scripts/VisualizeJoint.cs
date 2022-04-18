using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class VisualizeJoint : MonoBehaviour
{
    void Start()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, .01f);

        foreach (Transform child in transform)
        {
            Gizmos.DrawLine(transform.position, child.position);
        }
    }
}
