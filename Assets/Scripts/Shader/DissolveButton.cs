using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dissolve_VFX
{
    public class DissolveButton : MonoBehaviour
    {
        public float m_DissolveSpeed;

        public Transform m_StartPoint;
        public Transform m_MiddlePoint;
        public Transform m_EndPoint;

        public float time;
        public float duration;

        private int m_AnimationIndex;

        private float m_DissolvePercent;
        private bool m_Dissolve;

        private Animator m_Animator;
        private Material m_DissolveMaterial;

        private void Start()
        {
            m_Dissolve = true;
            m_DissolvePercent = 1f;
            m_AnimationIndex = 0;

            m_Animator = GetComponent<Animator>();
            m_DissolveMaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;

            m_DissolveMaterial.SetFloat("_CharacterDissolve", m_DissolvePercent);

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                switch (m_AnimationIndex)
                {
                    case 1:
                        Dissapear();
                        break;
                    case 2:
                        Appear();
                        break;
                    default:
                        Appear();
                        break;
                }
            }

            if (m_Dissolve && m_DissolvePercent <= 1) { m_DissolvePercent += Time.deltaTime * m_DissolveSpeed; }
            else if (!m_Dissolve && m_DissolvePercent >= -1) { m_DissolvePercent -= Time.deltaTime * m_DissolveSpeed; }

            if (time < duration && m_AnimationIndex == 1)
            {
                PlayAnimation(m_StartPoint, m_MiddlePoint);
            }
            else if (time < duration && m_AnimationIndex == 2)
            {
                PlayAnimation(m_MiddlePoint, m_EndPoint);
            }
            else
            {
                m_Animator.SetBool("IsMoving", false);
            }

        }

        private void Appear()
        {
            transform.position = m_StartPoint.position;
            m_Dissolve = false;
            time = 0;
            m_AnimationIndex = 1;
            m_Animator.SetBool("IsMoving", true);
        }

        private void Dissapear()
        {
            m_Dissolve = true;
            time = 0;
            m_AnimationIndex = 2;
            m_Animator.SetBool("IsMoving", true);
        }

        private void PlayAnimation(Transform l_StartPoint, Transform l_EndPoint)
        {
            float t = time / duration;
            t = t * t * (3f - 2f * t);
            transform.position = Vector3.Lerp(l_StartPoint.position, l_EndPoint.position, t);
            m_DissolveMaterial.SetFloat("_CharacterDissolve", m_DissolvePercent);
            time += Time.deltaTime;
        }
    }
}

