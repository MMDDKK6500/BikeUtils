namespace BikeUtils.Structs;

/// <summary>
/// Keycard permissions
/// </summary>
public struct KeyCardPerms
{
    /// <summary>
    /// Containment level of the keycard, goes from 1 to 3.
    /// </summary>
    public int Containment;
    /// <summary>
    /// Armory access level, goes from 1 to 3.
    /// </summary>
    public int Armory_Access;
    /// <summary>
    /// If can open gates.
    /// </summary>
    public bool Gate;
    /// <summary>
    /// If can open warhead.
    /// </summary>
    public bool Warhead;
    /// <summary>
    /// If can open checkpoint doors.
    /// </summary>
    public bool Checkpoint;
    /// <summary>
    /// If cna open intercom room.
    /// </summary>
    public bool Intercom;

    /// <summary>
    /// Internal, idk what it does
    /// </summary>
    /// <param name="containment"></param>
    /// <param name="armory_access"></param>
    /// <param name="gate"></param>
    /// <param name="warhead"></param>
    /// <param name="checkpoint"></param>
    /// <param name="intercom"></param>
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