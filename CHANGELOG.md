# Additions
- `StringUtils` ([25fc018](https://github.com/MMDDKK6500/BikeUtils/commit/25fc0182fe9c48caf0c1e8d22b53200c4a70bd28))
    - `string GenerateLineBreak(int quantity)` - Generate Automatically generates line breaks for lazy people.
    - `string AdjustString()` - Makes it easy to modify text with multiple lines. (Multiple overloads)
- `KeycardUtils` ([1ee3ad8](https://github.com/MMDDKK6500/BikeUtils/commit/1ee3ad8f13ed5e7567bcef3b893584ecd17f74cc))
    - `ItemType? GetBestCardInInventory(Player player)` - Gets the best keycard in the player's inventory.
    - `KeycardPerms UpdateInfo(KeycardPerms thisKeyInfo, ItemType? itemType)` - Gets a KeycardPerms object from the ItemType object of a keycard.
    - `bool CanPlayerOpen(Player player, KeycardPermissions requiredPermissions)` - Checks if a Player has permissions for a certain set of KeycardPermissions.
- `NPCUtils`(Buggy) ([31fdf1d](https://github.com/MMDDKK6500/BikeUtils/commit/31fdf1db25c6ad666d6c196015db626e34e1b92e))
    - `Dictionary<int, ReferenceHub> DummyList` - A dictionary of the created dummies, in the ID, ReferenceHub format.
    - `ReferenceHub? SpawnDummy(RoleTypeId role, string name = "CoolDummy", int id = 42)` - Spawns a Dummy
    - `ReferenceHub? GetDummy(int id = 42)` - Gets a dummy by it's Id
    - `bool RemoveDummy(int id = 42)` - Removes a dummy by it's Id.
- `RoleClassUtils` ([6db7b15](https://github.com/MMDDKK6500/BikeUtils/commit/6db7b15163cbb838d44f04e4d9285da5bff7d6c6))
    - `string GetPlayerTagColor(Player player)` - Gets the player's tag color.
    - `string TranslateRole(RoleTypeId role)` - Translates a RoleTypeId into the Brazilian Portuguese name of role.
    - `RoleTypeId GetSCPRole(string/int number)` - Gets a string or int and checks if it is a valid playable SCP number.
    - `bool ScpRoles(RoleTypeId role)` - Checks if the given RoleTypeId is an SCP Role.
    - `GetRoleColor(RoleTypeId roleType)` - Gets a RoleTypeId and returns what color it should be.
    - `string UnityColorToHex(Color color, float boostR, float boostG, float boostB)` - Gets a Unity Color and transforms it into HEX.
    - `string UnityColorToHex(Color color, float boost = 0f)` - Same thing as the other function, but now the boost variable increases all color channels.