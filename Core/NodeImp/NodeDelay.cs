namespace LogicSim.Core.NodeImp;

public class NodeDelay : Node
{
    public override string Id => "fde";
    public override string Title => "Flow Delay";

    public int Delay { get; set; }

    public bool[] States { get; private set; } = null!;

    public override void Init()
    {
        States = new bool[Delay + 1];
    }

    public override bool Eval(params bool[] inputs)
    {
        for (var i = 0; i < Delay; i++)
        {
            States[i] = States[i + 1];
        }

        States[Delay] = inputs.Length > 0 && inputs[0];

        return States[0];
    }
}