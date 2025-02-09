using System.Linq;

namespace LogicSim.Core.NodeImp;

public class NodeXor : Node
{
    public override string Id => "lxo";
    public override string Title => "Logical Xor";

    public override bool Eval(params bool[] inputs)
    {
        return inputs.Length > 0 && inputs.Aggregate(false, (current, input) => current != input);
    }
}