using BallShoot.Infrastructure.Modules.UserInterface.Data;
using BallShoot.Infrastructure.Modules.UserInterface.Screens;
using DG.Tweening;
using UnityEngine;

namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Loading
{
    public class LoadingScreenMediator
    {
        private const int FADED_VALUE = 1;
        private const int UNFADED_VALUE = 0;
        private readonly IScreensModule _screensModule;
        private readonly LoadingScreenRuntimeData _runtimeData;
        private LoadingScreenViewModel _viewModel;

        public LoadingScreenMediator(IScreensModule screensModule, LoadingScreenRuntimeData runtimeData)
        {
            _screensModule = screensModule;
            _runtimeData = runtimeData;
        }
        
        public void SetModel(LoadingScreenViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void ResetCurrentView()
        {
            for (int i = 0; i < _viewModel.AnimatedDotsGroup.Count; i++)
            {
                CanvasGroup animatedElement = _viewModel.AnimatedDotsGroup[i];
                animatedElement.alpha = UNFADED_VALUE;
            }

            _viewModel.CanvasGroup.alpha = FADED_VALUE;
        }

        public void PlayLoadingAnimation()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.SetUpdate(true);
            sequence.SetRecyclable(true);

            for (int i = 0; i < _viewModel.AnimatedDotsGroup.Count; i++)
            {
                CanvasGroup animatedElement = _viewModel.AnimatedDotsGroup[i];
                sequence.Append(animatedElement.DOFade(FADED_VALUE, _viewModel.FadeDuration));
            }

            sequence.Append(_viewModel.CanvasGroup.DOFade(UNFADED_VALUE, _viewModel.FadeDuration));
            sequence.AppendCallback(() =>
            {
                _screensModule.CloseScreen(UIType.Loading, true);
                _runtimeData.OnLoadingAnimationEnd?.Invoke();
            });

            sequence.Play();
        }
    }
}