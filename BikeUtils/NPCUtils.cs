namespace BikeUtils;

using Exiled.API.Features;
using Exiled.API.Features.Components;
using Mirror;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class containing utilities for NPCs(Buggy)
/// </summary>
public static class NPCUtils
{
    
    /// <summary>
    /// A dictionary of the created dummies, in the ID, <see cref="ReferenceHub"/> format.
    /// </summary>
    public static Dictionary<int, ReferenceHub> DummyList = new Dictionary<int, ReferenceHub>();

    //Need to clean this up but I'm lazy, Bicicleta will fix it later lolzzz
    /// <summary>
    /// Spawns a Dummy
    /// </summary>
    /// <param name="role">The <see cref="RoleTypeId"/> that the dummy will have.</param>
    /// <param name="name">The name for the dummy.</param>
    /// <param name="id">The id for the fummy.</param>
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


    /// <summary>
    /// Gets a dummy by it's Id
    /// </summary>
    /// <param name="id">The dummy's id</param>
    /// <returns>The dummy's <see cref="ReferenceHub"/> or null if not found.</returns>
    public static ReferenceHub? GetDummy(int id = 42) {
        if (DummyList.ContainsKey(id))
            return DummyList[id];
        return null;
    }
    /// <summary>
    /// Removes a dummy by it's Id.
    /// </summary>
    /// <param name="id">The dummy's id.</param>
    /// <returns>True if it was removed, or false if not removed or found.</returns>
    public static bool RemoveDummy(int id = 42) {
        if (DummyList.ContainsKey(id))
            return NetworkServer.RemoveConnection(DummyList[id].PlayerId);
        else
            return false;
    }
}
