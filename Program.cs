using Avalonia;
using System;
using LogicSim.Core;
using LogicSim.Core.NodeImp;

namespace LogicSim;

class Program
{
    /*
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
    */
    public static void Main(string[] args)
    {
        // Construct simulation
        var sim = new Sim();
        sim.Nodes[0] = new NodeNor();
        sim.Nodes[1] = new NodeNor();
        sim.Nodes[2] = new NodeAnd();
        sim.Nodes[3] = new NodeAnd();
        sim.Nodes[10] = new NodeButton();
        sim.Nodes[11] = new NodeButton();
        sim.Joints.Add(new Joint(0, 1));
        sim.Joints.Add(new Joint(1, 2));
        sim.Joints.Add(new Joint(2, 0));
        sim.Joints.Add(new Joint(0, 3));
        sim.Joints.Add(new Joint(2, 3));
        sim.Joints.Add(new Joint(3, 1));
        sim.Joints.Add(new Joint(10, 0));
        sim.Joints.Add(new Joint(11, 1));

        // Initialize simulation
        sim.Init();
        Console.WriteLine("Controls:");
        Console.WriteLine($"\tDxx = mouse down on node xx");
        Console.WriteLine($"\tUxx = mouse up on node xx");
        Console.WriteLine($"\tS = step simulation");
        Console.WriteLine($"\tT = terminate simulation");

        // Run simulation
        Console.WriteLine(sim);
        var active = true;
        while (active)
        {
            Console.Write(">>> ");
            var input = Console.ReadLine()?.ToLower() ?? "";
            if (input.Length == 0) input = "s";
            switch (input[0])
            {
                case 'd':
                    sim.MouseDown(int.Parse(input[1..]));
                    break;
                case 'u':
                    sim.MouseUp(int.Parse(input[1..]));
                    break;
                case 's':
                    sim.Update();
                    Console.WriteLine(sim);
                    break;
                case 't':
                    active = false;
                    break;
            }
        }
    }
}