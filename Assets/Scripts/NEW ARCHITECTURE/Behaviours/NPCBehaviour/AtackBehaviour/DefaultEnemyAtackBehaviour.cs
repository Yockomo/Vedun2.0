
    using System.Runtime.CompilerServices;
    using SOScripts;

    public class DefaultEnemyAtackBehaviour : AtackBehaviour<ICanAtack>
    {
        private EnemyAtackConfig _atackConfig;
        
        public DefaultEnemyAtackBehaviour(ICanAtack attacker, EnemyAtackConfig atackConfig) : base(attacker)
        {
            _atackConfig = atackConfig;
        }

        public override void Pause()
        {
            currentState = AtackStates.PAUSE;
        }

        public override void UnPause()
        {
            currentState = AtackStates.UNPAUSE;
        }
        
        public override void UpdateBehaviour()
        {
            HandleCurrentState();  
        }

        private void HandleCurrentState()
        {
            switch (currentState)
            {
                case AtackStates.DEFAULT:
                    break;
                case AtackStates.ATACK:
                    break;
                case AtackStates.PAUSE:
                    break;
                case AtackStates.UNPAUSE:
                    currentState = AtackStates.DEFAULT;
                    break;
            }
        }
        
    }