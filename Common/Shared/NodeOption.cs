namespace Trace.Common.Standard;

public class NodeOption {
    public string Group { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public bool Service { get; set; } = true;
    public bool Gateway { get; set; }
    public bool Api { get; set; }
    public bool Graphql { get; set; }
    public string GraphqlRoot { get; set; } = "/";
    public bool Spatial { get; set; }
    public bool Mqtt { get; set; }
    public bool Proxy { get; set; }
    public bool Spa { get; set; }
    public bool Scheduler { get; set; } = true;
}