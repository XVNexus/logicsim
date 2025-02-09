namespace LogicSim.Core;

public abstract class Node
{
    public abstract string Id { get; }
    public abstract string Title { get; }

    public virtual void Init()
    {
    }

    public abstract bool Eval(params bool[] inputs);

    public virtual void MouseDown()
    {
    }

    public virtual void MouseUp()
    {
    }
}