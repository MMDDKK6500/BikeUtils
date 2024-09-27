namespace BikeUtils;

using System.Linq;
using BikeUtils.Structs;
using Exiled.API.Enums;
using Exiled.API.Features;

public class KeyCardUtils
{

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

    public static KeyCardPerms UpdateInfo(KeyCardPerms thisKeyInfo, ItemType? itemType)
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

    public static bool CanPlayerOpen(Player player, KeycardPermissions requiredPermissions)
    {
        bool podeAbrir = false;
        var keycards = player.Items.Where(item => (int)item.Type >= (int)ItemType.KeycardJanitor && (int)item.Type <= (int)ItemType.KeycardO5).Select(item => item.Type);
        foreach (var keycard in keycards)
        {
            KeyCardPerms theKeyInfo = UpdateInfo(new KeyCardPerms(), keycard);
            if (requiredPermissions.HasFlag(KeycardPermissions.Checkpoints)) if (theKeyInfo.Checkpoint) podeAbrir = true; else { podeAbrir = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ExitGates)) if (theKeyInfo.Gate) podeAbrir = true; else { podeAbrir = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.Intercom)) if (theKeyInfo.Intercom) podeAbrir = true; else { podeAbrir = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.AlphaWarhead)) if (theKeyInfo.Warhead) podeAbrir = true; else { podeAbrir = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ContainmentLevelOne)) if (theKeyInfo.Containment >= 1) podeAbrir = true; else { podeAbrir = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ContainmentLevelTwo)) if (theKeyInfo.Containment >= 2) podeAbrir = true; else { podeAbrir = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ContainmentLevelThree)) if (theKeyInfo.Containment >= 3) podeAbrir = true; else { podeAbrir = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ArmoryLevelOne)) if (theKeyInfo.Armory_Access >= 1) podeAbrir = true; else { podeAbrir = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ArmoryLevelTwo)) if (theKeyInfo.Armory_Access >= 2) podeAbrir = true; else { podeAbrir = false; continue; }
            if (requiredPermissions.HasFlag(KeycardPermissions.ArmoryLevelThree)) if (theKeyInfo.Armory_Access >= 3) podeAbrir = true; else { podeAbrir = false; continue; }

            if (podeAbrir) break;
        }
        return podeAbrir;
    }
}
