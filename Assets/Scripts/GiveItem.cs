using UnityEngine;
using System.Collections;

public class GiveItem : MonoBehaviour, ITargetPosition
{
    [SerializeField] GameObject _canvas;
    private GameObject[] giveItemSlot = new GameObject[29];
    [SerializeField] private float _distanceToActiveCanvas;

    private void Start()
    {
        
    }

    public void Interaction(CharacterController characterController = null)
    {
        int randomItemCount = Random.Range(1, 28);

        for (int i = 0; i < randomItemCount; i++)
        {
            giveItemSlot[i] = _canvas.transform.Find("ScrollView").transform.Find("LayoutGroup").transform.Find($"Image ({i})").gameObject;
            GameObject sp = Instantiate(Resources.Load<GameObject>($"inventorySprite/inventorySprite"), giveItemSlot[i].transform);
            sp.GetComponent<SpriteOperation>().inventoryPlayer = characterController.GetComponent<InventoryPlayer>();
        }

        if (characterController != null)
        {
            StartCoroutine(CanvasActive(characterController));
            Vector3 targetWalkPosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            characterController.SetTargetWalk(characterController.TargetMove.activeSelf, transform, targetWalkPosition);
        } 
    }

    private IEnumerator CanvasActive(CharacterController characterController)
    {
        while (Vector3.Distance(transform.position, characterController.transform.position) > _distanceToActiveCanvas) { yield return null; }
        _canvas.SetActive(true);
    }
}
