# RemoveCustomFemaleBodies

A [Synthesis](https://github.com/Mutagen-Modding/Synthesis) patcher for Skyrim SE/AE that strips custom body/skin
overrides (`WNAM` / `WornArmor`) from female NPCs so they fall back to their Race's default skin — the one your
installed body/texture mod replaces.

## What it does

For every winning female NPC record in your load order:

1. Skips it if its base plugin is in the **Plugins to Exclude** list (defaults to the vanilla masters:
   `Skyrim.esm`, `Update.esm`, `Dawnguard.esm`, `HearthFires.esm`, `Dragonborn.esm`), so only mod-added or
   mod-overridden NPCs are touched.
2. Skips child-race NPCs (configurable — children use a different skeleton/body, so forcing an adult skin
   onto them looks wrong).
3. If the NPC has a custom skin (`WornArmor`) override, clears it so the game falls back to the NPC's Race's
   default skin at runtime.

This does **not** touch `DefaultOutfit`/worn clothing — only the naked-body skin reference. If an NPC is always
dressed, you won't see a visual change unless the outfit exposes skin.

## Building

Requires the [.NET 9 SDK](https://dotnet.microsoft.com/download).

```
cd RemoveCustomFemaleBodies
dotnet build
```

## Running via Synthesis

1. Open Synthesis (through Mod Organizer 2 or standalone).
2. Click **Git Repository** (or add it as a local patcher pointing at this folder).
3. If using Git Repository, set the repository path to wherever you host this project, or point Synthesis at
   the local folder directly via **Add New Patcher → From Local Folder**.
4. Once added, open its **Settings** tab to review/edit the excluded plugin list or toggle child-skipping.
5. Run the patch group as usual — it produces `RemoveCustomFemaleBodies.esp`.

## Notes

- Load this patch **after** any NPC appearance mods you want overridden, so it wins the conflict for `WornArmor`.
- If you want to force a *specific* skin (rather than falling back to the Race default), swap
  `npc.WornArmor.SetToNull();` in `Program.cs` for `npc.WornArmor.SetTo(myArmorFormKey);`.
