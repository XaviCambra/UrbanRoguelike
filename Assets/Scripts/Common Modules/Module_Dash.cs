using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Module_Dash : MonoBehaviour
{
    public void DashDisplacement(Vector3 l_Direction, float l_Distance, float l_Speed)
    {
        transform.position = transform.position + l_Direction.normalized * l_Distance;
        return;
        RaycastHit l_RayCast;

        if (Physics.Raycast(transform.position, l_Direction, out l_RayCast, l_Distance))
        {
            Vector3 l_DisplacementPosition = l_RayCast.point;

            l_DisplacementPosition = l_DisplacementPosition - (l_DisplacementPosition - transform.position).normalized;

            //StartCoroutine(DashMovement(l_DisplacementPosition, l_Speed));

            transform.position = l_DisplacementPosition;
            return;
        }

        transform.position = l_Direction.normalized * l_Distance;
        //StartCoroutine(DashMovement(l_Direction * l_Distance, l_Speed));
    }

    private IEnumerator DashMovement(Vector3 l_DisplacementPosition, float l_Speed)
    {
        float elapsedFrames = 0;
        float interpolationFramesCount = l_Speed;

        Vector3 l_StartPosition = transform.position;

        while (elapsedFrames != interpolationFramesCount)
        {
            float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

            Vector3 interpolatedPosition = Vector3.Lerp(l_StartPosition, l_DisplacementPosition, interpolationRatio);

            elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);

            transform.position = interpolatedPosition;
            yield return null;
        }

        transform.position = l_DisplacementPosition;
    }
}
