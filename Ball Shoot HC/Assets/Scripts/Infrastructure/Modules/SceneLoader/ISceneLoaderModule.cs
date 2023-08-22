using System;
using BallShoot.Infrastructure.Data;
using UnityEngine.SceneManagement;

namespace BallShoot.Infrastructure.Modules.SceneLoader
{
    public interface ISceneLoaderModule
    {
        public void Load(SceneType sceneType, LoadSceneMode loadSceneMode, Action onLoadingFinished = null);
        public void ReLoadCurrent();
    }
}