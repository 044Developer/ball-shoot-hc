using System;
using System.Collections;
using BallShoot.Infrastructure.Configurations;
using BallShoot.Infrastructure.Data;
using BallShoot.Infrastructure.Modules.CoroutineRunner;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BallShoot.Infrastructure.Modules.SceneLoader
{
    public class SceneLoaderModule : ISceneLoaderModule
    {
        private readonly ICoroutineRunner _coroutineRunner = null;
        private readonly ProjectSceneConfiguration _sceneConfiguration = null;
        private SceneType _previousSceneType = SceneType.None;

        public SceneLoaderModule(ICoroutineRunner coroutineRunner, ProjectSceneConfiguration sceneConfiguration)
        {
            _coroutineRunner = coroutineRunner;
            _sceneConfiguration = sceneConfiguration;
        }
        
        public void Load(SceneType sceneType, LoadSceneMode loadSceneMode, Action onLoadingFinished = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneType, loadSceneMode, onLoadingFinished));
        }
        
        private IEnumerator LoadScene(SceneType sceneType, LoadSceneMode loadSceneMode, Action onLoadingFinished)
        {
            string sceneName = _sceneConfiguration.SceneModels.Find(it => it.Type == sceneType).Name ?? string.Empty;
            
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoadingFinished?.Invoke();
                yield break;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            while (!waitNextScene.isDone)
                yield return null;

            UnloadPreviousScene();
            _previousSceneType = sceneType;
            onLoadingFinished?.Invoke();
        }

        private void UnloadPreviousScene()
        {
            if (_previousSceneType == SceneType.None)
                return;

            string sceneName = _sceneConfiguration.SceneModels.Find(it => it.Type == _previousSceneType).Name ?? string.Empty;

            SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.None);
        }
    }
    public interface ISceneLoaderModule
    {
        public void Load(SceneType sceneType, LoadSceneMode loadSceneMode, Action onLoadingFinished = null);
    }
}