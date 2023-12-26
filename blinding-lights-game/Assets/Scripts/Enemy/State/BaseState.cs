public abstract class BaseState
{
    //instance of enemy class and state machine
    public StateMachine stateMachine;
    public Enemy enemy;
    
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();

    
}