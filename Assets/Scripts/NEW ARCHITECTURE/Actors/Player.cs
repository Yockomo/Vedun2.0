using StarterAssets;
using UnityEngine;

public class Player : Actor, IActor
{
    private MousePositionManager _mousePositionManager;
    private MeleeAtack meleeAtack;

    protected override void Init()
    {
        _mousePositionManager = new MousePositionManager(transform);
        meleeAtack = GetComponent<MeleeAtack>();
        if (TryGetComponent<IMoveAndRotate>(out IMoveAndRotate movable))
        {
            var moveBehaviour = new PlayerStandartMoveBehaviour(movable, GetComponent<StarterAssetsInputs>(), GetComponent<CharacterController>(), GetComponent<Animator>());
            meleeAtack.OnAtackEventStart += moveBehaviour.SetAtackState;
            meleeAtack.OnAtackEventEnd += moveBehaviour.SetDefaultState;
            AddBehaviour(moveBehaviour);
            var rotateBehaviour = new PlayerStandartRotateBehaviour(movable, _mousePositionManager, GetComponent<StarterAssetsInputs>());
            meleeAtack.OnAtackEventStart += rotateBehaviour.SetAtackState;
            meleeAtack.OnAtackEventEnd += rotateBehaviour.SetDefaultState;
            AddBehaviour(rotateBehaviour);
        }
        else
            Debug.LogError("нет компонента перемещения у " + gameObject.name);
    }
}
