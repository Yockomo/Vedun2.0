using System;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public event Action NextComboAtackEvent;
    public event Action OffComboEvent;

    public void NextComboAtack()
    {
        NextComboAtackEvent?.Invoke();
    }

    public void OffCombo()
    {
        OffComboEvent?.Invoke();
    }
}
