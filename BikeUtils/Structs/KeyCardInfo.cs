namespace BikeUtils.Structs;

public struct KeyCardPerms
{

    public int Containment;
    public int Armory_Access;
    public bool Gate;
    public bool Warhead;
    public bool Checkpoint;
    public bool Intercom;

    internal KeyCardPerms(int containment = 0, int armory_access = 0, bool gate = false, bool warhead = false, bool checkpoint = false, bool intercom = false)
    {
        Containment = containment;
        Armory_Access = armory_access;
        Gate = gate;
        Warhead = warhead;
        Checkpoint = checkpoint;
        Intercom = intercom;
    }
}