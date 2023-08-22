using UnityEngine;
using Zenject;

namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Loose
{
    public class LooseScreen : BaseUIElement
    {
        [SerializeField] private LooseScreenViewModel _viewModel;

        private LooseScreenMediator _mediator;

        [Inject]
        public void Construct(LooseScreenMediator mediator)
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
            _viewModel.RestartButton.onClick.AddListener(_mediator.OnRestartButtonClick);
        }
    }
}