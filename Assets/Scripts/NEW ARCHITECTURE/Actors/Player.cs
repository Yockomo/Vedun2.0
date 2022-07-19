using StarterAssets;
using UnityEngine;

public class Player : Actor, IActor
{
    private MousePositionManager _mousePositionManager;

    protected override void Init()
    {
        _mousePositionManager = new MousePositionManager(transform);

        if (TryGetComponent<IMoveAndRotate>(out IMoveAndRotate movable))
        {
            AddBehaviour(new PlayerStandartMoveBehaviour(movable, GetComponent<StarterAssetsInputs>(),GetComponent<CharacterController>(),GetComponent<Animator>()));
            AddBehaviour(new PlayerStandartRotateBehaviour(movable, _mousePositionManager,GetComponent<StarterAssetsInputs>()));
        }
        else
            Debug.LogError("нет компонента перемещения у " + gameObject.name);
    }
}
