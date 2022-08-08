using System;
using UnityEngine;

namespace Assets.Scripts.Scenes.GameScenes
{
    public class Scene1 : MonoBehaviour, IScene
    {
        public string GetSceneName()
        {
            return "scene1";
        }

        public GameConstants.SceneType GetSceneType()
        {
            return GameConstants.SceneType.Game;
        }

        public string GetSceneZone()
        {
            return "Zone1";
        }

        public T GetSceneData<T>(string sceneName)
        {
            throw new NotImplementedException();
        }
    }
}
