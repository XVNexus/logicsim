namespace LogicSim.Core.NodeImp;

public class NodeSwitch : Node
{
    public override string Id => "isw";
    public override string Title => "Input Switch";

    public bool State { get; set; }

    public override void MouseDown()
    {
        State = !State;
    }

    public override bool Eval(params bool[] inputs)
    {
        return State;
    }
}