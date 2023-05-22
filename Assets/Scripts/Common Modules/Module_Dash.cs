using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Module_Dash : MonoBehaviour
{
    public bool DashDisplacement(Vector3 l_Direction, float l_Distance, float l_Speed)
    {
        RaycastHit l_RayCast;

        if (Physics.Raycast(transform.position, l_Direction, out l_RayCast, l_Distance))
        {
            Vector3 l_HitPoint = l_RayCast.point;
            Vector3 l_DisplacementPosition = l_HitPoint - (l_HitPoint - transform.position).normalized;

            StartCoroutine(DashMovement(l_DisplacementPosition, l_Speed));
            return false;
        }
        return true;
    }

    private IEnumerator DashMovement(Vector3 l_DisplacementPosition, float l_Speed)
    {
        float l_TimeSpent = 0;
        float l_MaxTimeSpent = l_Speed;

        Vector3 l_StartPosition = transform.position;

        while (l_TimeSpent != l_MaxTimeSpent)
        {
            float l_ActualTime = l_TimeSpent / l_MaxTimeSpent;

            Vector3 interpolatedPosition = Vector3.Lerp(l_StartPosition, l_DisplacementPosition, l_ActualTime);

            l_TimeSpent = (l_TimeSpent + 1) % (l_MaxTimeSpent + 1);

            transform.position = interpolatedPosition;
            yield return null;
        }

        transform.position = l_DisplacementPosition;
    }
}
