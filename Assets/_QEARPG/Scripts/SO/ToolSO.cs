using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "Scriptable Objects/Tool", order = 1)]
public class ToolSO : ItemSO
{
    [field: SerializeField]
    public GameObject GameObject { get; private set; }
}
