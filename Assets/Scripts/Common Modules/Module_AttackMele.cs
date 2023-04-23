using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_AttackMele : MonoBehaviour
{
    public LayerMask m_HitLayer;

    public void HitOnDirection(Vector3 l_DamagePosition, Vector3 l_Direction, float l_HitAngle, float l_HitRange, float l_Damage)
    {
        l_Direction.y = 0;

        RaycastHit l_RaycastHit;
        if (Physics.Raycast(l_DamagePosition, transform.TransformDirection(l_Direction * -l_HitAngle), out l_RaycastHit, l_HitRange, m_HitLayer))
        {
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.Log("Did not Hit");
        }
        if (Physics.Raycast(l_DamagePosition, transform.TransformDirection(l_Direction * l_HitAngle), out l_RaycastHit, l_HitRange, m_HitLayer))
        {
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.Log("Did not Hit");
        }
    }
}
