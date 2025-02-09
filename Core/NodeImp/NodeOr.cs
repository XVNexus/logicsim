using System;
using System.Linq;

namespace LogicSim.Core.NodeImp;

public class NodeOr : Node
{
    public override string Id => "lor";
    public override string Title => "Logical Or";

    public override bool Eval(params bool[] inputs)
    {
        return inputs.Length > 0 && inputs.Aggregate(false, (current, input) => current || input);
    }
}