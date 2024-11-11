namespace TDD2
{
    public interface IStack
    {

        
        int capacity { get; }

        void Push(bool data);
        void Pop();
        bool GetTop();
        string ToString();
    }
}
