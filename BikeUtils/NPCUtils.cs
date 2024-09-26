namespace BikeUtils;

using Exiled.API.Features;
using Exiled.API.Features.Components;
using Mirror;
using PlayerRoles;


public class NPCUtils
{
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
