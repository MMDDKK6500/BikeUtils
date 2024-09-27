namespace BikeUtils;

using Exiled.API.Features;
using Exiled.API.Features.Components;
using Mirror;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;

public static class NPCUtils
{
    public static Dictionary<int, ReferenceHub> DummyList = new Dictionary<int, ReferenceHub>();

    //Need to clean this up but I'm lazy, Bicicleta will fix it later lolzzz
    /// <summary>
    /// Spawns a Dummy
    /// </summary>
    /// <param name="role">The <see cref="RoleTypeId"/> that the dummy will have.</param>
    /// <param name="name">The name for the dummy.</param>
    /// <returns>Returns a <see cref="ReferenceHub"/> for the spawned dummy.</returns>
    public static ReferenceHub? SpawnDummy(RoleTypeId role, string name = "CoolDummy", int id = 42)
    {
        if (DummyList.ContainsKey(id))
        {
            Log.Warn($"Dummy with id {id} is ALREADY in use, use another id to create a new dummy");
            return null;
        }

        GameObject newPlayer = Object.Instantiate(NetworkManager.singleton.playerPrefab);
        Npc npc = new Npc(newPlayer)
        { 
            IsNPC = true 
        };
        try { npc.ReferenceHub.roleManager.InitializeNewRole(RoleTypeId.None, RoleChangeReason.RemoteAdmin); } catch { }
        int num = Random.Range(999, 999999);
        var fakeConnection = new FakeConnection(num++);
        var hubPlayer = newPlayer.GetComponent<ReferenceHub>();
        NetworkServer.AddPlayerForConnection(fakeConnection, newPlayer);
        try { npc.ReferenceHub.authManager.UserId = $"{num}@basicdummy"; } catch { }
        hubPlayer.nicknameSync.Network_myNickSync = name;
        npc.ReferenceHub.roleManager.ServerSetRole(role, RoleChangeReason.RemoteAdmin);
        DummyList.Add(id, hubPlayer);

        return hubPlayer;
    }

    public static ReferenceHub? GetDummy(int id = 42) {
        if (DummyList.ContainsKey(id))
            return DummyList[id];
        return null;
    }

    public static void RemoveDummy(int id = 42) {
        if (DummyList.ContainsKey(id))
            NetworkServer.RemoveConnection(DummyList[id].PlayerId);
    }
}
