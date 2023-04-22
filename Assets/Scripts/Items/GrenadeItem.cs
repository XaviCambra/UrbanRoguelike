using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeItem : BaseItem
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_ExplosionRadius;
    [SerializeField] private float m_MaxBounds;
    [SerializeField] private float m_CurrentBound;


    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */

        transform.Translate(Vector3.up * m_MoveSpeed * Time.deltaTime);

    }
}
