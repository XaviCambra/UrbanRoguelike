using UnityEngine;

public class BaseItem : MonoBehaviour
{
    public virtual void ApplyEffectItem()
    {
        Player_BLACKBOARD playerBlackBoard = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BLACKBOARD>();
        playerBlackBoard.m_Item = null;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Player_BLACKBOARD playerBlackBoard = other.GetComponent<Player_BLACKBOARD>();

        if (playerBlackBoard == null) return;

        if (playerBlackBoard.m_Item != null) return;

        else
        {
            playerBlackBoard.GetComponent<Player_BLACKBOARD>().m_Item = this;

            gameObject.SetActive(false);
        }

    }*/
}
