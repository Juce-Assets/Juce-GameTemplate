using Juce.Core.Visibility;
using Juce.CoreUnity.ViewStack.Entries;
using System;
using UnityEngine;

namespace Template.Content.Meta.SplashScreenUi.ViewStack
{
    public sealed class SplashScreenUiViewStackEntry : ViewStackEntry
    {
        public SplashScreenUiViewStackEntry(
            Type id,
            Transform transform, 
            IVisible visible, 
            bool isPopup, 
            params ViewStackEntryRefresh[] refreshList
            ) : base(
                id, 
                transform, 
                visible, 
                isPopup, 
                refreshList
                )
        {
        }
    }
}
