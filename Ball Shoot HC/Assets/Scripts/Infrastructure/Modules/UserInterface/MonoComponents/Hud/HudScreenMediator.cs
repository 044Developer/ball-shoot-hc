namespace BallShoot.Infrastructure.Modules.UserInterface.MonoComponents.Hud
{
    public class HudScreenMediator
    {
        private readonly HudRuntimeData _runtimeData;
        private HudScreenViewModel _viewModel;

        public HudScreenMediator(HudRuntimeData runtimeData)
        {
            _runtimeData = runtimeData;
        }
        
        public void SetModel(HudScreenViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void OnLaunchBallButtonClick()
        {
            _runtimeData.OnLaunchBallButtonClick?.Invoke();
        }
    }
}