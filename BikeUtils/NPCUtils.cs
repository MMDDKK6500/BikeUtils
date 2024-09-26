namespace BikeUtils;

using Exiled.API.Features;
using Exiled.API.Features.Components;
using Mirror;
using PlayerRoles;


public static class NPCUtils
{
    //Need to clean this up but I'm lazy, Bicicleta will fix it later lolzzz
    /// <summary>
    /// Spawns a Dummy
    /// </summary>
    /// <param name="role">The <see cref="RoleTypeId"/> that the dummy will have.</param>
    /// <param name="name">The name for the dummy.</param>
    /// <returns>Returns a <see cref="ReferenceHub"/> for the spawned dummy.</returns>
    public static ReferenceHub SpawnDummy(RoleTypeId role, string name)
    {

        var newPlayer = UnityEngine.Object.Instantiate(NetworkManager.singleton.playerPrefab);

        Npc npc = new(newPlayer)
        {
            IsNPC = true
        };
        
        try
        {
            npc.ReferenceHub.roleManager.InitializeNewRole(role, RoleChangeReason.RemoteAdmin);
        }
        catch
        { }

        int num = UnityEngine.Random.Range(999, 99999);

        var fakeConnection = new FakeConnection(num++);

        var hubPlayer = newPlayer.GetComponent<ReferenceHub>();

        NetworkServer.AddPlayerForConnection(fakeConnection, newPlayer);
        try
        {
            npc.ReferenceHub.authManager.UserId = $"{num}@bogbuts";
        }
        catch
        { }

        hubPlayer.nicknameSync.Network_myNickSync = name;

        return hubPlayer;
        }
}
