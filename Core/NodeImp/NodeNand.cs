using System.Linq;

namespace LogicSim.Core.NodeImp;

public class NodeNand : Node
{
    public override string Id => "lna";
    public override string Title => "Logical Nand";

    public override bool Eval(params bool[] inputs)
    {
        return inputs.Length > 0 && !inputs.Aggregate(true, (current, input) => current && input);
    }
}