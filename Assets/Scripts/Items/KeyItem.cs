using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : BaseItem
{
    [SerializeField] private float m_DetectionRadius;

    public override void ApplyEffectItem()
    {

        /*  Write your own code below */

        Collider[] l_colliders = Physics.OverlapSphere(m_PlayerController.transform.position, m_DetectionRadius);
        
        foreach (Collider l_nearbyObject in l_colliders)
        {
            if (l_nearbyObject.tag == "OpenDoorTrigger")
            {
                Debug.Log("Door Trigger Detected");
                DoorTriggerController l_DoorTrigger = l_nearbyObject.GetComponent<DoorTriggerController>();

                l_DoorTrigger.OpenDoor();

                Debug.Log("KeyUsed");

                m_InventoryManager.UseItem();
            }

            else return;
        }
    }
}
