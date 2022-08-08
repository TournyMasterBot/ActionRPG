using static Assets.Scripts.GameConstants;

namespace Assets.Scripts.Scenes
{
    public interface IScene
    {
        string GetSceneName();
        string GetSceneZone();
        T GetSceneData<T>(string sceneName);

        SceneType GetSceneType();
    }
}
