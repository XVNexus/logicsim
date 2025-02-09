namespace LogicSim.Core.NodeImp;

public class NodeLamp : Node
{
    public override string Id => "ola";
    public override string Title => "Output Lamp";

    public bool State { get; set; }

    public override bool Eval(params bool[] inputs)
    {
        State = inputs.Length > 0 && inputs[0];
        return false;
    }
}