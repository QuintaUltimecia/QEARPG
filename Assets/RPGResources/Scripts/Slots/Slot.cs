using UnityEngine;

public class Slot : MonoBehaviour
{
    private bool isFull;

    private void Update()
    {
        if (transform.childCount > 0)
        {
            transform.GetChild(0).transform.localPosition = Vector3.zero;
            isFull = true;
        }
        else isFull = false;
    }

    public bool IsFull { get { return isFull; } set => isFull = value; }
}