using System.Collections;
using UnityEngine;

namespace BallShoot.Infrastructure.Modules.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}