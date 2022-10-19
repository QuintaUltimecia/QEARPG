using UnityEngine;
using QuintaEssenta.Library;

public class DIContainer : BaseBehaviour
{
    [SerializeField]
    private Component[] _components;

    public Object GetInjectComponent(System.Type type)
    {
        var component = new Object();

        foreach (var item in _components)
        {
            if (type == item.GetType())
                component = item;
        }

        if (component == null)
            Debug.LogWarning($"Inject typeof(" + type.Name + ") in container is null");

        return component;
    }
}
