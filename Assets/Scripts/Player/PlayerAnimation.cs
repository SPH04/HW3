using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private float _normalAnimationSpeed;
    [SerializeField] private float _accelerationAnimationSpeed;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        (bool IsMovingRight, bool IsMovingLeft) values = (false, false);

        if (Input.GetKey(KeyCode.D))
            values = (true, false);
        if (Input.GetKey(KeyCode.A))
            values = (false, true);
        if (Input.GetKey(KeyCode.LeftShift))
            _animator.speed = _accelerationAnimationSpeed;
        else
            _animator.speed = _normalAnimationSpeed;

        _animator.SetBool("IsMovingRight", values.IsMovingRight);
        _animator.SetBool("IsMovingLeft", values.IsMovingLeft);

    }
}
