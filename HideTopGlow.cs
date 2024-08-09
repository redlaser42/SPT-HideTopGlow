using SPT.Reflection.Patching;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFT.UI;
using System.Runtime.CompilerServices;
using UnityEngine.UI;


namespace HideTopGlow.Patches
{
    internal class HideTopGlowPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(EnvironmentUI), nameof(EnvironmentUI.method_0));
        }


        [PatchPostfix]
        static void Postfix(Image imageToFadeOut, Image imageToFadeIn, bool forced)
        {
            imageToFadeIn.gameObject.SetActive(false);
        }
    }
}
