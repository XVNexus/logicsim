using System;

namespace LogicSim.Core.NodeImp;

public class NodeButton : Node
{
    public override string Id => "ibu";
    public override string Title => "Input Button";

    public bool State { get; set; }

    public override void MouseDown()
    {
        State = true;
    }

    public override void MouseUp()
    {
        State = false;
    }

    public override bool Eval(params bool[] inputs)
    {
        return State;
    }
}