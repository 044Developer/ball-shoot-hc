using UnityEngine;
using Zenject;

namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Win
{
    public class WinScreen : BaseUIElement
    {
        [SerializeField] private WinScreenViewModel _viewModel;

        private WinScreenMediator _mediator;

        [Inject]
        public void Construct(WinScreenMediator mediator)
        {
            _mediator = mediator;

            _mediator.SetModel(_viewModel);
        }

        public override void Initialize()
        {
            base.Initialize();

            InitializeButtons();
        }

        public override void Open()
        {
            base.Open();

            _mediator.OnOpenScreen();
        }

        public override void Dispose()
        {
            base.Dispose();

            DisposeButtons();
        }

        private void InitializeButtons()
        {
            _viewModel.RestartButton.onClick.AddListener(_mediator.OnRestartButtonClick);
        }

        private void DisposeButtons()
        {
            _viewModel.RestartButton.onClick.RemoveListener(_mediator.OnRestartButtonClick);
        }
    }
}