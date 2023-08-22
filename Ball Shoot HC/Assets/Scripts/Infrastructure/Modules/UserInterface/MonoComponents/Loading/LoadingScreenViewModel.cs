using System;
using System.Collections.Generic;
using UnityEngine;

namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Loading
{
    [Serializable]
    public class LoadingScreenViewModel
    {
        [Header("Animated elements")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private List<CanvasGroup> _animatedDotsGroup;

        [Header("Settings")]
        [SerializeField] private float _fadeDuration;

        public CanvasGroup CanvasGroup => _canvasGroup;
        public List<CanvasGroup> AnimatedDotsGroup => _animatedDotsGroup;
        public float FadeDuration => _fadeDuration;
    }
}