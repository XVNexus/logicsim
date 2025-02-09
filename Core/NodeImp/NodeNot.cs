namespace LogicSim.Core.NodeImp;

public class NodeNot : Node
{
    public override string Id => "lnb";
    public override string Title => "Logical Not";

    public override bool Eval(params bool[] inputs)
    {
        return inputs.Length > 0 && !inputs[0];
    }
}