using UnityEngine;
using Zenject;

namespace BallShoot.Infrastructure.Bootstrap
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGame _game;

        [Inject]
        public void Construct(IGame game)
        {
            _game = game;
        }

        private void Awake()
        {
            _game.StartApplication();
        }

        private void OnApplicationQuit()
        {
            _game.QuitApplication();
        }
    }
}