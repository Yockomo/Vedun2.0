using SOScripts;

    public class DefaultEnemyAtackBehaviour : AtackBehaviour<ICanAtack>, ICanSetState<AtackStates>
    {
        private EnemyAtackConfig _atackConfig;
        
        public DefaultEnemyAtackBehaviour(ICanAtack attacker, EnemyAtackConfig atackConfig) : base(attacker)
        {
            _atackConfig = atackConfig;
        }
        
        public void SetState(AtackStates state)
        {
            currentState = state;
        }
        
        public override void Pause()
        {
            SetState(AtackStates.PAUSE);
        }

        public override void UnPause()
        {
            SetState(AtackStates.UNPAUSE);
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
                    SetState(AtackStates.DEFAULT);
                    break;
            }
        }
    }