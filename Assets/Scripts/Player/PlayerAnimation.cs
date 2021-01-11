using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private float _normalAnimationSpeed;
        [SerializeField] private float _accelerationAnimationSpeed;

        private Animator _animator;
        private static readonly int IsMovingRight = Animator.StringToHash("IsMovingRight");
        private static readonly int IsMovingLeft = Animator.StringToHash("IsMovingLeft");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            (bool IsMovingRight, bool IsMovingLeft) valueTuple = (false, false);
            if (Input.GetKey(KeyCode.D))
                valueTuple = (true, false);
            else if (Input.GetKey(KeyCode.A))
                valueTuple = (false, true);
            _animator.speed = Input.GetKey(KeyCode.LeftShift) ? _accelerationAnimationSpeed : _normalAnimationSpeed;

            _animator.SetBool(IsMovingRight, valueTuple.IsMovingRight);
            _animator.SetBool(IsMovingLeft, valueTuple.IsMovingLeft);

        }
    }
}
