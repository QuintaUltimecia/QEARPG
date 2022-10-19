using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private string _name;

    public void SetName(string value) =>
        Name = value;

    public string Name { get => _name; private set => _name = value; }
}
