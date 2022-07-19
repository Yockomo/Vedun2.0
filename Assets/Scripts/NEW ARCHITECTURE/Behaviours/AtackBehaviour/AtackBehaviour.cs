using Assets.Scripts.NEW_ARCHITECTURE.Components.AtackComponent;

namespace Assets.Scripts.NEW_ARCHITECTURE.Behaviours.AtackBehaviour
{
    public abstract class AtackBehaviour<T> : BaseBehaviour, IAtackBehaviour where T : ICanAtack
    {
        protected T attacker;
        protected AtackStates currentState;

        protected AtackBehaviour(T attacker)
        {
            this.attacker = attacker;
        }
    }

    public enum AtackStates { DEFAULT, ATACK, PAUSE, UNPAUSE, }

    public interface IAtackBehaviour : IBehaviour
    {
    }
}
