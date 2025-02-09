namespace LogicSim.Core.NodeImp;

public class NodeBuffer : Node
{
    public override string Id => "lbu";
    public override string Title => "Logical Buffer";

    public override bool Eval(params bool[] inputs)
    {
        return inputs.Length > 0 && inputs[0];
    }
}