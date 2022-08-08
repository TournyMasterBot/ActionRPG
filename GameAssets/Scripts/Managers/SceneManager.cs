using Assets.Scripts.Scenes;
using Assets.Scripts.Scenes.GameScenes;
using Assets.Scripts.Scenes.MenuScenes;
using System.Collections.Generic;

namespace Assets.Scripts.Managers
{
    public static class SceneManager
    {
        public static Dictionary<string, IScene> Scenes = new Dictionary<string, IScene>();

        public static void Initialize()
        {
            AddScene(new MainMenu());
            AddScene(new Scene1());
        }

        public static void AddScene(IScene scene)
        {
            if (!Scenes.ContainsKey(scene.GetSceneName()))
            {
                Scenes.Add(scene.GetSceneName(), scene);
            }
        }

        public static T GetSceneData<T>(string sceneName)
        {
            if (Scenes.ContainsKey(sceneName))
            {
                return Scenes[sceneName].GetSceneData<T>(sceneName);
            }
            return default(T);
        }

        public static void RemoveScene(string sceneName)
        {
            Scenes.Remove(sceneName);
        }
    }
}
