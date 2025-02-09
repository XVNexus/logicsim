using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicSim.Core;

public class Sim
{
    public Dictionary<int, Node> Nodes { get; } = new();
    public List<Joint> Joints { get; } = [];
    public Dictionary<int, Dictionary<int, bool>> InputBuffer { get; } = new();
    public Dictionary<int, bool> OutputBuffer { get; } = new();

    public int Tick { get; private set; }

    public void Init()
    {
        // Allocate input output buffer memory for every node
        foreach (var node in Nodes)
        {
            InputBuffer[node.Key] = new Dictionary<int, bool>();
            OutputBuffer[node.Key] = false;
        }

        // Add entries in the input buffer dictionaries for every joint
        foreach (var joint in Joints)
        {
            InputBuffer[joint.To][joint.From] = false;
        }
    }

    public void Stop()
    {
        // Deallocate the buffers
        InputBuffer.Clear();
        OutputBuffer.Clear();

        // Reset tick counter
        Tick = 0;
    }

    public void Update()
    {
        // Reevaluate each node output according to values stores in the input buffer
        foreach (var node in Nodes)
        {
            OutputBuffer[node.Key] = node.Value.Eval(InputBuffer[node.Key].Values.ToArray());
        }

        // Propagate output values along joints
        foreach (var joint in Joints)
        {
            InputBuffer[joint.To][joint.From] = OutputBuffer[joint.From];
        }

        // Update tick counter
        Tick++;
    }

    public void MouseDown(int id)
    {
        if (Nodes.TryGetValue(id, out var node)) node.MouseDown();
    }

    public void MouseUp(int id)
    {
        if (Nodes.TryGetValue(id, out var node)) node.MouseUp();
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"[ T+{Tick} ]");
        foreach (var node in Nodes)
        {
            var targets = (from joint in Joints where joint.From == node.Key select joint.To).ToList();
            result.AppendLine(
                $"{node.Key} {node.Value.Title} = {OutputBuffer[node.Key]} -> {string.Join(' ', targets)}");
        }

        return result.ToString()[..^1];
    }
}