using StarterAssets;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private MousePositionManager mousePositionManager;

    public override void InstallBindings()
    {
        BindHeroController();
        BindAnimatorManager();
        BindMousePositionManager();
    }

    private void BindMousePositionManager()
    {
        InstatiateAndBindFromInstance<MousePositionManager>(mousePositionManager);
    }

    private void BindHeroController()
    {
        BindFromInstance<ThirdPersonController>(playerPrefab);
    }

    private void BindAnimatorManager()
    {
        BindFromInstance<AnimatorManager>(playerPrefab);
    }

    private void InstatiateAndBindFromInstance<T>(T prefab) where T : MonoBehaviour
    {
        var instance =
            Container.InstantiatePrefabForComponent<T>(prefab);
        Container.Bind<T>().FromInstance(instance).AsSingle();
    }
    
    private void BindFromInstance<T> (GameObject instance) where T : MonoBehaviour
    {
        if (instance.TryGetComponent<T>(out T component))
        {
            Container.Bind<T>().FromInstance(component).AsSingle();
        }
        else
        {
            Debug.LogException(new System.Exception($"There is no needed component on {instance.name} object"));
        }
    }
}
