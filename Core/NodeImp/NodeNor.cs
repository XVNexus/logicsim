using System;
using System.Linq;

namespace LogicSim.Core.NodeImp;

public class NodeNor : Node
{
    public override string Id => "lno";
    public override string Title => "Logical Nor";

    public override bool Eval(params bool[] inputs)
    {
        return inputs.Length > 0 && !inputs.Aggregate(false, (current, input) => current || input);
    }
}