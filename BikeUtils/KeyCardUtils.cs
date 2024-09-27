namespace BikeUtils;

using System.Linq;
using BikeUtils.Structs;
using Exiled.API.Enums;
using Exiled.API.Features;

public class KeyCardUtils
{
    //função que vai rodar uma secagem de item do player
    public static ItemType? GetBestCardInInventory(Player player)
    {
        //filtra os itens e organiza do maior numero para o menor
        var keycards = player.Items
            .Where(item => (int)item.Type >= (int)ItemType.KeycardJanitor && (int)item.Type <= (int)ItemType.KeycardO5)
            .Select(item => item.Type)
            .OrderByDescending(item => (int)item)
            .ToList();

        //checa se a lista keycards tem um valor //pega a primeira variavel dessa lista
        if (keycards.Any()) return (ItemType?)keycards.FirstOrDefault();
        return null;
    }

    //atualiza as informações do cartão, comparando o tipo do cartão e definindo seu nivel de acesso!!!
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

    //checagem da permissão do tipo KeyCardPermission que ele ta interagindo junto com o player, para fazer a chacagem dos itens e converter ele em uma informação mais usavel
    public static bool CanPlayerOpen(Player player, KeycardPermissions requiredPermissions)
    {
        bool podeAbrir = false;
        var keycards = player.Items.Where(item => (int)item.Type >= (int)ItemType.KeycardJanitor && (int)item.Type <= (int)ItemType.KeycardO5).Select(item => item.Type);
        //loop pra cada cartão que o player tiver
        foreach (var keycard in keycards)
        {
                                             //struct do KeyCardPerms//cartão atual do foreach
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
            //aqui ele para automaticamente caso o valor final for true, pq ai n precisa mais checar pq um cartão ja passou!!!
        }
        return podeAbrir;
    }
}
