using System.Linq;

namespace LogicSim.Core.NodeImp;

public class NodeXnor : Node
{
    public override string Id => "lnx";
    public override string Title => "Logical Xnor";

    public override bool Eval(params bool[] inputs)
    {
        return inputs.Length > 0 && !inputs.Aggregate(false, (current, input) => current != input);
    }
}