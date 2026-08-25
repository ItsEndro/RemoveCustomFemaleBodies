using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Synthesis.Settings;
using System.Collections.Generic;

namespace RemoveCustomFemaleBodies
{
    public class Settings
    {
        [SynthesisSettingName("Plugins to Exclude")]
        [SynthesisTooltip("NPCs whose base record originates from one of these plugins will be left untouched. Defaults to the vanilla masters, so only mod-added/modded NPCs get patched.")]
        public List<ModKey> ExcludedMods = new()
        {
            ModKey.FromNameAndExtension("Skyrim.esm"),
            ModKey.FromNameAndExtension("Update.esm"),
            ModKey.FromNameAndExtension("Dawnguard.esm"),
            ModKey.FromNameAndExtension("HearthFires.esm"),
            ModKey.FromNameAndExtension("Dragonborn.esm"),
        };

        [SynthesisSettingName("Skip Child NPCs")]
        [SynthesisTooltip("If checked (recommended), NPCs using the child race are skipped, since forcing an adult skin onto a child model looks wrong or can break entirely.")]
        public bool SkipChildren = true;
    }
}
