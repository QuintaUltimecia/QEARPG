using UnityEngine;

public class ItemCache : MonoBehaviour
{
    [SerializeField] private GameObject[] _items;

    public static GameObject[] Items;

    private void OnEnable() => Items = _items;
}
