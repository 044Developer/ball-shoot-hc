using UnityEngine;
using Zenject;

namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Loading
{
    public class LoadingScreen : BaseUIElement
    {
        [SerializeField] private LoadingScreenViewModel _viewModel;

        private LoadingScreenMediator _mediator;

        [Inject]
        public void Construct(LoadingScreenMediator loadingScreenMediator)
        {
            _mediator = loadingScreenMediator;
            _mediator.SetModel(_viewModel);
        }

        public override void Open()
        {
            base.Open();

            _mediator.ResetCurrentView();
            
            _mediator.PlayLoadingAnimation();
        }
    }
}