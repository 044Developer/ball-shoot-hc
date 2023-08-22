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

        public void ReLoadCurrent()
        {
            _coroutineRunner.StartCoroutine(ReLoadCurrentScene());
        }

        private IEnumerator LoadScene(SceneType sceneType, LoadSceneMode loadSceneMode, Action onLoadingFinished)
        {
            string sceneName = _sceneConfiguration.SceneModels.Find(it => it.Type == sceneType).Name ?? string.Empty;
            /*
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoadingFinished?.Invoke();
                yield break;
            }
            */
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            while (!waitNextScene.isDone)
                yield return null;

            UnloadPreviousScene();
            _previousSceneType = sceneType;
            onLoadingFinished?.Invoke();
        }

        private IEnumerator ReLoadCurrentScene()
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

            while (!waitNextScene.isDone)
                yield return null;
        }

        private void UnloadPreviousScene()
        {
            if (_previousSceneType == SceneType.None)
                return;

            string sceneName = _sceneConfiguration.SceneModels.Find(it => it.Type == _previousSceneType).Name ?? string.Empty;

            SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.None);
        }
    }
}