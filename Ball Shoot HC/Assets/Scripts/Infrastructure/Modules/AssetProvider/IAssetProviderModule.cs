using UnityEngine;

namespace BallShoot.Infrastructure.Modules.AssetProvider
{
    public interface IAssetProviderModule
    {
        public T GetAsset<T>(string assetPath) where T : Object;
    }
}