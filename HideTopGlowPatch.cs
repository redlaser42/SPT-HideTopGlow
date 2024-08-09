using Spt.Reflection.Patching;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFT.UI;
using System.Runtime.CompilerServices; 


namespace HideTopGlow.Patches
{
    internal class HideTopGlowPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(EnvironmentUI), nameof(EnvironmentUI.method_0));
        }



        [PatchPrefix]
        static bool Prefix()
        {
            EnvironmentUI.Class2446 @class = new EnvironmentUI.Class2446();
            @class.imageToFadeOut = imageToFadeOut;
            if (forced)
            {
                @class.imageToFadeOut.gameObject.SetActive(false);
                imageToFadeIn.gameObject.SetActive(false);
                return;
            }
            return false
        }

        [PatchPrefix]
        static void Postfix()
        {
            //code here will run AFTER the original code is executed.
        }
    }
}
