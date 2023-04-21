using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : BaseItem
{

    public override void ApplyEffectItem()
    {
        base.ApplyEffectItem();

        /*  Write your own code below */

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController == null) return;

        playerController.GetComponent<PlayerController>().m_Item = this;

        gameObject.SetActive(false);
    }
}
