using System.Linq;

namespace LogicSim.Core.NodeImp;

public class NodeAnd : Node
{
    public override string Id => "lan";
    public override string Title => "Logical And";

    public override bool Eval(params bool[] inputs)
    {
        return inputs.Length > 0 && inputs.Aggregate(true, (current, input) => current && input);
    }
}