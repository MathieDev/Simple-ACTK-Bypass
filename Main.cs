using MelonLoader;
using UnityEngine;
using HarmonyLib;

namespace SimpleACTK
{
    public static class BuildInfo
    {
        public const string Name = "SimpleACTK"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Bypasses ACTK Dll Force Crash."; // Description for the Mod.  (Set as null if none)
        public const string Author = "Mathie"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class SimpleACTK : MelonMod
    {
        public override void OnApplicationStart() // Runs after Game Initialization.
        {
            MelonLogger.Msg("Patching application quit!");
        }

        [HarmonyLib.HarmonyPatch(typeof(Application), "Quit", new Type[] { })]
        class ApplicationQuit2
        {
            [HarmonyLib.HarmonyPrefix]
            public unsafe static bool Prefix()
            {
                MelonLogger.Msg("Application Quit Called!");
                return false;
            }
        }
    }
}