using System;
using UnityEngine;

namespace Assets.Scripts.Scenes.MenuScenes
{
    public class MainMenu : MonoBehaviour, IScene
    {
        public string GetSceneName()
        {
            return "mainmenu";
        }

        public GameConstants.SceneType GetSceneType()
        {
            return GameConstants.SceneType.Menu;
        }

        public string GetSceneZone()
        {
            return "mainmenu";
        }

        public T GetSceneData<T>(string sceneName)
        {
            throw new NotImplementedException();
        }
    }
}
