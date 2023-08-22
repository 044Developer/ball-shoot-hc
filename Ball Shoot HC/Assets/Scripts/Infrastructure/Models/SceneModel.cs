using System;
using BallShoot.Infrastructure.Data;
using UnityEngine;

namespace BallShoot.Infrastructure.Models
{
    [Serializable]
    public class SceneModel
    {
        [SerializeField] private SceneType _type;
        [SerializeField] private  string _name;

        public SceneType Type => _type;
        public string Name => _name;
    }
}