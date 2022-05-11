﻿using Juce.Core.Di.Installers;
using Template.Contents.LoadingScreen.LoadingScreenUi.Installers;
using UnityEngine;

namespace Template.Contexts.LoadingScreen
{
    public sealed class LoadingScreenContextInstance : MonoBehaviour
    {
        [SerializeField] private LoadingScreenUiInstaller loadingScreenUiInstaller = default;

        public IInstaller LoadingScreenUiInstaller => loadingScreenUiInstaller;
    }
}
