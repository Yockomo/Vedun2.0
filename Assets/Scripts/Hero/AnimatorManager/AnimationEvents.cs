using System;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public event Action NextComboAtackEvent;
    public event Action OffComboEvent;
    public event Action MoveOnAtackEvent;

    public void NextComboAtack()
    {
        NextComboAtackEvent?.Invoke();
    }

    public void OffCombo()
    {
        OffComboEvent?.Invoke();
    }

    public void MoveOnAtack()
    {
        MoveOnAtackEvent?.Invoke();
    }
}
