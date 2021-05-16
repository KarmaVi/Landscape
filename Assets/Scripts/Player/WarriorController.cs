using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class WarriorController : MonoBehaviour
{
    [SerializeField] private bool m_IsRun;
    [SerializeField] private float m_RunSpeed;
    [SerializeField] private float m_WalkSpeed;
    [SerializeField] private bool m_UseFovKick;
    [SerializeField] private FOVKick m_FovKick = new FOVKick();
    [SerializeField] private WarriorController _animatorController;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _flashlight;
    [SerializeField] private GameObject _target;
    [SerializeField] [Range(0, 5)] private float _speed;
    [SerializeField] [Range(-1, 1)] private float _direction;
    [SerializeField] [Range(0, 1)] private float _weightRightHand;
    [SerializeField] [Range(0, 1)] private float _weightLefttHand;

    private CharacterController m_CharacterController;
    private Vector2 m_Input;
    private bool _isFlashlightActive = true;
    public Transform _star = null;


    public void SetSpeed(float currentSpeed)
    {
        _animator.SetFloat("Speed", currentSpeed);
    }
    public void SetFlashlightActive(bool isActive)
    {
        _weightLefttHand = isActive ? 1 : 0;
        _flashlight.gameObject.SetActive(isActive);
    }
    //event function
    protected void OnAnimatorIK(int layerIndex)
    {
        if (_animator)
        {
            //голова
            _animator.SetLookAtWeight(Vector3.Dot(transform.forward, _star.transform.position - transform.position), 2);
            _animator.SetLookAtPosition(_star.position);

            //правая рука
            _weightRightHand = (Vector3.Dot(transform.forward, _target.transform.position - transform.position) > 0) ? 1 : 0;
            _animator.SetIKPosition(AvatarIKGoal.RightHand, _target.transform.position);
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _weightRightHand);

            //левая рука
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _flashlight.transform.position);
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _weightLefttHand);

            //ноги
            var leftFootWeight = _animator.GetFloat("RaightLegIKWeight");
            var rightFootWeight = _animator.GetFloat("LefttLegIKWeight");

            var leftFoot = _animator.GetBoneTransform(HumanBodyBones.LeftFoot);
            var rightFoot = _animator.GetBoneTransform(HumanBodyBones.RightFoot);

            RaycastHit hit;
            if(Physics.Raycast(leftFoot.position, Vector3.down, out hit, 10f))
            {
                Debug.Log(leftFoot.position);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;
        //_animatorController.SetSpeed(desiredMove.magnitude * _speed);


    }
    private void GetInput(out float _speed)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool wasrun = m_IsRun;

#if !MOBILE_INPUT
    m_IsRun = !Input.GetKey(KeyCode.LeftShift);
#endif
        _speed = m_IsRun ? m_RunSpeed : m_WalkSpeed;
        m_Input = new Vector2(horizontal, vertical);

        if(m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }
        if(m_IsRun != wasrun && m_UseFovKick && m_CharacterController.velocity.sqrMagnitude > 0)
        {
            StopAllCoroutines();
            StartCoroutine(!m_IsRun ? m_FovKick.FOVKickUp() : m_FovKickDown());
        }
    }

    private void StartCoroutine(object p)
    {
        throw new System.NotImplementedException();
    }

    private string m_FovKickDown()
    {
        throw new System.NotImplementedException();
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _isFlashlightActive = !_isFlashlightActive;
            _flashlight.SetActive(_isFlashlightActive);
            //_animatorController.SetFlashlightActive(_isFlashlightActive);
        }
    }
    
    public void RunEvent(int velue)
    {
        Debug.Log("RunEvent");
    }

}
