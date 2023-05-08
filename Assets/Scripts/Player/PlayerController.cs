using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class PlayerController : MonoBehaviour
{
    InputController m_InputController;
    public Player_BLACKBOARD m_Blackboard;
    CharacterController m_CharacterController;

    Module_AttackRanged m_RangedAttack;
    Module_Dash m_Dash;
    Module_Animation m_Animation;

    private bool m_CanInteract;
    private bool m_CanMove;
    private bool m_Crouching;

    public bool m_CanOverheat;
    public bool m_OverheatCancelled;

    private float m_MovementSpeed;

    [SerializeField] private float m_CurrentOverheatTime;

    [SerializeField] private int m_CurrentShots;

    //[SerializeField] private Camera m_Camera;

    [SerializeField] private GameObject m_Body;
    [SerializeField] private GameObject m_Hips;

    private void Start()
    {
        m_InputController = GetComponent<InputController>();
        m_Blackboard = GetComponent<Player_BLACKBOARD>();
        m_CharacterController = GetComponent<CharacterController>();
        m_Animation = GetComponent<Module_Animation>();
        m_RangedAttack = GetComponent<Module_AttackRanged>();
        m_Dash = GetComponent<Module_Dash>();

        m_CanInteract = true;
        m_CanMove = true;
        m_Crouching = false;
        m_MovementSpeed = m_Blackboard.m_MovementSpeed;

        m_Blackboard.m_CanAttack = true;

        m_CanOverheat = true;
        m_OverheatCancelled = false;

        m_Blackboard.m_HasKey = false;
    }

    private void Update()
    {
        if(m_CanInteract == false) return;
        
        if (m_CanMove) MovementInput();

        Crouching();
        Shoot();
        UseItem();
        SetSpeed();
        
        if(m_OverheatCancelled == false) OverHeat();
    }

    void MovementInput()
    {
        Vector3 l_Direction = Vector3.zero;

        if (Input.GetKey(m_InputController.m_ForwardKey))
        {
            l_Direction += Quaternion.Euler(0, 45, 0) * Vector3.forward;
        }
        if (Input.GetKey(m_InputController.m_BackKey))
        {
            l_Direction += Quaternion.Euler(0, 45, 0) * Vector3.back;
        }
        if (Input.GetKey(m_InputController.m_LeftKey))
        {
            l_Direction += Quaternion.Euler(0, 45, 0) * Vector3.left;
        }
        if (Input.GetKey(m_InputController.m_RightKey))
        {
            l_Direction += Quaternion.Euler(0, 45, 0) * Vector3.right;
        }

        l_Direction.Normalize();

        if (Dash())
        {
            HipsFaceMouse();
            return;
        }

        if (l_Direction == Vector3.zero)
        {
            BodyFaceMouse();
            return;
        }
        else HipsFaceMouse();


        l_Direction = Module_LinearGravity.SetGravityToVector(l_Direction);

        l_Direction = l_Direction * m_MovementSpeed * Time.deltaTime;

        m_CharacterController.Move(l_Direction);
    }

    void UseItem()
    {
        if (Input.GetKeyDown(m_InputController.m_UseItemKey))
        {
            if (m_Blackboard.m_Item == null) return;

            m_Blackboard.m_Item.ApplyEffectItem();
        }
    }

    void Crouching()
    {
        if (Input.GetKeyDown(m_InputController.m_CrouchingKey))
        {
            if (m_Crouching) Crouching_Out();
            else Crouching_In();
        }
    }

    void Crouching_In()
    {
        m_Crouching = true;
        m_Blackboard.m_CanAttack = false;
        m_Animation.PlayAnimation("Crouching", m_Crouching);
        StartCoroutine(ModifyCharacterCollider(0, new Vector3(0, 0.5f, 0), 1));
    }

    void Crouching_Out()
    {
        m_Crouching = false;
        m_Blackboard.m_CanAttack = true;
        float duration = m_Animation.PlayAnimation("Crouching", m_Crouching);
        StartCoroutine(ModifyCharacterCollider(duration / 2, new Vector3(0, 1, 0), 2)); 
    }
    void SetSpeed()
    {
        if (m_Crouching)
        {
            m_MovementSpeed = m_Blackboard.m_CrouchingSpeed;
        }
        else if (!m_Crouching)
        {
            m_MovementSpeed = m_Blackboard.m_MovementSpeed;
        }
    }

    private bool Dash()
    {
        if (Input.GetKeyDown(m_InputController.m_DashKey) == false) return false;

        m_Dash.DashDisplacement(m_Body.transform.forward, m_Dash.m_DashDistance, m_Dash.m_DashSpeed);
        return true;
    }

    IEnumerator ModifyCharacterCollider(float transitionDuration, Vector3 l_Position, float l_Height)
    {
        yield return new WaitForSeconds(transitionDuration);
        m_CharacterController.center = l_Position;
        m_CharacterController.height = l_Height;
    }


    void BodyFaceMouse()
    {
        m_Body.transform.forward = m_InputController.m_MouseDirectionScreen();
        if (m_Body.transform.localRotation.y * Mathf.Rad2Deg > 40)
        {
            Quaternion l_HipsRotation = m_Body.transform.localRotation;
            l_HipsRotation.y -= 40 * Mathf.Deg2Rad;
            m_Hips.transform.localRotation = l_HipsRotation;
        }
        else if (m_Body.transform.localRotation.y * Mathf.Rad2Deg < -40)
        {
            Quaternion l_HipsRotation = m_Body.transform.localRotation;
            l_HipsRotation.y += 40 * Mathf.Deg2Rad;
            m_Hips.transform.localRotation = l_HipsRotation;
        }
    }

    void HipsFaceMouse()
    {
        m_Body.transform.forward = m_InputController.m_MouseDirectionScreen();
        m_Hips.transform.forward = m_InputController.m_MouseDirectionScreen();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown((int) MouseButton.Left) && m_Blackboard.m_CanAttack)
        {
            m_RangedAttack.ShootOnDirection(m_Blackboard.m_ShootPoint.position, m_Blackboard.m_ShootPoint.transform.rotation, m_Blackboard.m_BulletSpeed, m_Blackboard.m_ShootingDamage, "Enemy");
            OverHeat();
        }
    }

    private void OverHeat()
    {
        if (m_CanOverheat)
        {
            if (m_CurrentShots >= m_Blackboard.m_MaxOverHeat)
            {
                m_Blackboard.m_CanAttack = false;
                Reload();
                return;
            }
            StopCoroutine(Reload());
            StartCoroutine(Reload());
        }
    }

    public IEnumerator CancelOverHeat()
    {
        m_OverheatCancelled = true;
        yield return new WaitForSeconds(m_Blackboard.m_OverHeatCancelDuration);
        m_OverheatCancelled = false;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(m_Blackboard.m_ReloadSpeed);
        m_Blackboard.m_CanAttack = true;
        m_CurrentShots = 0;
    }

    private void OnEnable()
    {
        gameObject.GetComponent<Player_Health>().m_PlayerIsDead += InvertInteract;
    }

    private void OnDisable()
    {
        gameObject.GetComponent<Player_Health>().m_PlayerIsDead -= InvertInteract;
    }
    private void InvertInteract()
    {
        m_CanInteract = false;
    }
}
