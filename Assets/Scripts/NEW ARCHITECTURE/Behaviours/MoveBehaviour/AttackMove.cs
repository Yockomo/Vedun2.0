using System;
using UnityEngine;
using System.Collections;

namespace NEW_ARCHITECTURE.Behaviours.MoveBehaviour
{
    public class AttackMove : MonoBehaviour
    {
        [SerializeField] private float delayToMove = 0.3f;
        [SerializeField] private float moveDistance = 1f; 
        [SerializeField] private float _attackSpeed = 4f; 
        
        private CharacterController _controller;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        public void AttackOnMove()
        {
            Vector3 lastPlayerPos = _controller.transform.position;
            StartCoroutine(AttackMoveCorutine(lastPlayerPos));
        }

        private IEnumerator AttackMoveCorutine(Vector3 lastPlayerPos)
        {
            yield return new WaitForSeconds(delayToMove);
            while (Vector3.Distance(lastPlayerPos, _controller.transform.position) < moveDistance)
            {
                yield return new WaitForFixedUpdate();
                _controller.Move(_controller.transform.forward * ( _attackSpeed * Time.deltaTime));
            }
        }
    }
    
}