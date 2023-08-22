using UnityEngine;
using Zenject;

namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Hud
{
    public class HudScreen : BaseUIElement
    {
        [SerializeField] private HudScreenViewModel _viewModel;

        private HudScreenMediator _mediator;

        [Inject]
        public void Construct(HudScreenMediator mediator)
        {
            _mediator = mediator;

            _mediator.SetModel(_viewModel);
        }

        public override void Initialize()
        {
            base.Initialize();

            InitializeButtons();
        }

        public override void Dispose()
        {
            base.Dispose();

            DisposeButtons();
        }

        private void InitializeButtons()
        {
            _viewModel.LaunchBallButton.onClick.AddListener(_mediator.OnLaunchBallButtonClick);
        }

        private void DisposeButtons()
        {
            _viewModel.LaunchBallButton.onClick.RemoveListener(_mediator.OnLaunchBallButtonClick);
        }
    }
}