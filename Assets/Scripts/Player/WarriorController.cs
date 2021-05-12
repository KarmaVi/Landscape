using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    [SerializeField] [Range(0, 5)]
    private float _speed;

    [SerializeField] [Range(-1, 1)]
    private float _direction;

    [SerializeField]
    private Animator _animator;

    protected void Update()
    {
        _animator.SetFloat("Speed", _speed);
        _animator.SetFloat("Direction", _direction);
    }
    public void RunEvent(int velue)
    {
        Debug.Log("RunEvent");
    }

}
