using UnityEngine;

public class GiveItem : MonoBehaviour
{
    [SerializeField] private GameObject _button;
    [SerializeField] private GameObject _lootWindow;

    private GameObject[] _lootSlot = new GameObject[29];
    private Player _player;

    public void Interaction()
    {
        int randomItemCount = Random.Range(1, 28);

        for (int i = 0; i < randomItemCount; i++)
        {
            _lootSlot[i] = _lootWindow.transform.Find("ScrollView").transform.Find("LayoutGroup").transform.Find($"Image ({i})").gameObject;
            GameObject sp = Instantiate(Resources.Load<GameObject>($"inventorySprite/inventorySprite"), _lootSlot[i].transform);
            sp.GetComponent<SpriteOperation>().inventoryPlayer = _player.GetComponent<InventoryPlayer>();
        }

        _lootWindow.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _player = player;
            _button.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other) { if (other.GetComponent<Player>()) _button.SetActive(false); }
}
