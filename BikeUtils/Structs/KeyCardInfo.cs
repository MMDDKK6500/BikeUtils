namespace BikeUtils.Structs;

public struct KeyCardPerms
{

    public int Containment { get; set; } = 0;
    public int Armory_Access { get; set; } = 0;
    public bool Gate { get; set; } = false;
    public bool Warhead { get; set; } = false;
    public bool Checkpoint { get; set; } = false;
    public bool Intercom { get; set; } = false;

    internal KeyCardPerms(int containment, int armory_access, bool gate, bool warhead, bool checkpoint, bool intercom)
    {
        Containment = containment;
        Armory_Access = armory_access;
        Gate = gate;
        Warhead = warhead;
        Checkpoint = checkpoint;
        Intercom = intercom;
    }
}