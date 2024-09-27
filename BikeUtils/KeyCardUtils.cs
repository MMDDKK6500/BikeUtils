namespace BikeUtils;

using System.Linq;
using BikeUtils.Structs;
using Exiled.API.Enums;
using Exiled.API.Features;

public static class KeycardUtils
{
    /// <summary>
    /// Gets the best keycard in the player's inventory.
    /// </summary>
    /// <param name="player">The <see cref="Player"/> you want to check.</param>
    /// <returns>Returns the best keycard in <see cref="ItemType"/> type.</returns>
    public static ItemType? GetBestCardInInventory(Player player)
    {
        var keycards = player.Items
            .Where(item => (int)item.Type >= (int)ItemType.KeycardJanitor && (int)item.Type <= (int)ItemType.KeycardO5)
            .Select(item => item.Type)
            .OrderByDescending(item => (int)item)
            .ToList();

        if (keycards.Any()) return (ItemType?)keycards.FirstOrDefault();
        return null;
    }

    /// <summary>
    /// Gets a <see cref="KeycardPerms"/> object from teh <see cref="ItemType"/> of a keycard.
    /// </summary>
    /// <param name="thisKeyInfo">The <see cref="KeycardPerms"/> you want to update.</param>
    /// <param name="itemType">The keycard you want to get the permissions from.</param>
    /// <returns><see cref="KeycardPerms"/> with the keycard's permissions.</returns>
    public static KeycardPerms UpdateInfo(KeycardPerms thisKeyInfo, ItemType? itemType)
    {
        switch (itemType)
        {
            case ItemType.KeycardJanitor: thisKeyInfo.Containment = 1; break;
            case ItemType.KeycardScientist: thisKeyInfo.Containment = 2; break;
            case ItemType.KeycardResearchCoordinator: thisKeyInfo.Containment = 2; thisKeyInfo.Checkpoint = true; break;
            case ItemType.KeycardZoneManager: thisKeyInfo.Containment = 1; thisKeyInfo.Checkpoint = true; break;
            case ItemType.KeycardGuard: thisKeyInfo.Containment = 1; thisKeyInfo.Armory_Access = 1; thisKeyInfo.Checkpoint = true; break;
            case ItemType.KeycardMTFPrivate: thisKeyInfo.Containment = 2; thisKeyInfo.Armory_Access = 2; thisKeyInfo.Checkpoint = true; break;
            case ItemType.KeycardContainmentEngineer: thisKeyInfo.Containment = 3; thisKeyInfo.Checkpoint = true; break;
            case ItemType.KeycardMTFOperative: thisKeyInfo.Containment = 2; thisKeyInfo.Armory_Access = 2; thisKeyInfo.Gate = true; thisKeyInfo.Checkpoint = true; break;
            case ItemType.KeycardFacilityManager: thisKeyInfo.Containment = 3; thisKeyInfo.Gate = true; thisKeyInfo.Warhead = true; thisKeyInfo.Checkpoint = true; thisKeyInfo.Intercom = true; break;
            case ItemType.KeycardMTFCaptain: thisKeyInfo.Containment = 2; thisKeyInfo.Armory_Access = 3; thisKeyInfo.Gate = true; thisKeyInfo.Checkpoint = true; thisKeyInfo.Intercom = true; break;
            case ItemType.KeycardChaosInsurgency: thisKeyInfo.Containment = 2; thisKeyInfo.Armory_Access = 3; thisKeyInfo.Gate = true; thisKeyInfo.Checkpoint = true; thisKeyInfo.Intercom = true; break;
            case ItemType.KeycardO5: thisKeyInfo.Containment = 3; thisKeyInfo.Armory_Access = 3; thisKeyInfo.Gate = true; thisKeyInfo.Warhead = true; thisKeyInfo.Checkpoint = true; thisKeyInfo.Intercom = true; break;
        }
        return thisKeyInfo;
    }

    /// <summary>
    /// Checks if a <see cref="Player"/> has permissions for a certain set of <see cref="KeycardPermissions"/>.
    /// </summary>
    /// <param name="player">The <see cref="Player"/> to check.</param>
    /// <param name="requiredPermissions">The <see cref="KeycardPermissions"/> object to compare against the player's permissions.</param>
    /// <returns>Returns true if the player has the provided permissions.</returns>
    public static bool CanPlayerOpen(Player player, KeycardPermissions requiredPermissions)
    {
        bool hasPerms = false;
        var keycards = player.Items.Where(item => (int)item.Type >= (int)ItemType.KeycardJanitor && (int)item.Type <= (int)ItemType.KeycardO5).Select(item => item.Type);
        foreach (var keycard in keycards)
        {
            KeycardPerms theKeyInfo = UpdateInfo(new KeycardPerms(), keycard);
            if (requiredPermissions.HasFlag(KeycardPermissions.Checkpoints)) if (theKeyInfo.Checkpoint) hasPerms = true; else { hasPerms = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ExitGates)) if (theKeyInfo.Gate) hasPerms = true; else { hasPerms = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.Intercom)) if (theKeyInfo.Intercom) hasPerms = true; else { hasPerms = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.AlphaWarhead)) if (theKeyInfo.Warhead) hasPerms = true; else { hasPerms = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ContainmentLevelOne)) if (theKeyInfo.Containment >= 1) hasPerms = true; else { hasPerms = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ContainmentLevelTwo)) if (theKeyInfo.Containment >= 2) hasPerms = true; else { hasPerms = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ContainmentLevelThree)) if (theKeyInfo.Containment >= 3) hasPerms = true; else { hasPerms = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ArmoryLevelOne)) if (theKeyInfo.Armory_Access >= 1) hasPerms = true; else { hasPerms = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ArmoryLevelTwo)) if (theKeyInfo.Armory_Access >= 2) hasPerms = true; else { hasPerms = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ArmoryLevelThree)) if (theKeyInfo.Armory_Access >= 3) hasPerms = true; else { hasPerms = false; continue; }

            if (hasPerms) break;
        }
        return hasPerms;
    }
}
