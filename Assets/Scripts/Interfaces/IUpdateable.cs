namespace Interfaces
{
    public interface IUpdateable
    {
        public void OnUpdate(float deltaTime);
    }
    
    public interface IFixedUpdateable
    {
        public void OnFixedUpdate(float deltaTime);
    }

    public interface ILateUpdateable
    {
        public void OnLateUpdate(float deltaTime);
    }
}