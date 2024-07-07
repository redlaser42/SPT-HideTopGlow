using BepInEx;
using Comfort.Common;
using EFT.UI;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace HideTopGlow
{
    [BepInPlugin("red.HideTopGlow", "HideTopGlow", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"HideTopGlow is loaded!");
        }

        private void OnDestroy()
        {
            Logger.LogInfo($"HideTopGlow is unloaded!");
        }

        void FixedUpdate()
        {
            HideTopGlow();
        }

        private void HideTopGlow()
        {
            if (Singleton<EnvironmentUI>.Instance == null) return;
            EnvironmentUI EnvironmentUI = Singleton<EnvironmentUI>.Instance;

            var field = typeof(EnvironmentUI).GetField("_topGlowRegularImage", BindingFlags.NonPublic | BindingFlags.Instance);
            var e = field.GetValue(EnvironmentUI) as Image;

            e.enabled = false;
        }
    }
}
