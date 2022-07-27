using UnityEngine;

    public class EnemyMoveAndRotateComponent : MonoBehaviour, IMoveAndRotate
    {
        public Transform Transform => transform;

        public float MoveSpeed => 0;

        public float SpeedChangeRate => 0;

        public float RotationSmoothTime => 0;

        public float JumpHeight => 0;
        public float Gravity => 0;
        public float JumpTimeout => 0;
        public float FallTimeout => 0;
        public float GroundedOffset => 0;
        public float GroundedRadius => 0;
        public LayerMask GroundLayers => 0;
    }