using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeItem : BaseItem
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_ExplosionRadius;
    [SerializeField] private float m_MaxDistance;
    [SerializeField] private float m_MaxBounds;
    [SerializeField] private float m_CurrentBound;
    private bool m_UsedItem;


    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */
        m_UsedItem = true;
        gameObject.SetActive(true);
        

    }

    private void Update()
    {
        if (m_UsedItem)
        {
            transform.Translate(Vector3.forward * m_MoveSpeed * Time.deltaTime);
        }
    }
}
