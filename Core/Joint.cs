namespace LogicSim.Core;

public struct Joint(int from, int to)
{
    public int From { get; set; } = from;
    public int To { get; set; } = to;
}