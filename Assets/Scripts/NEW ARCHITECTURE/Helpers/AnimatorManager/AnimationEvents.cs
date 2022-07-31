using System;
using System.Collections;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public event Action NextComboAtackEvent;
    public event Action OffComboEvent;

    public event Func<IEnumerator> MoveOnAtackCoroutineEvent;

    public void NextComboAtack()
    {
        NextComboAtackEvent?.Invoke();
    }

    public void OffCombo()
    {
        OffComboEvent?.Invoke();
    }

    public void AttackOnMove()
    {
        StartCoroutine(MoveOnAtackCoroutineEvent?.Invoke());
    }
}
