using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCreation : MonoBehaviour
{
    private string characterNameInput;
    private CharacterFeatures.CharacterClass characterClassInput;

    [SerializeField] private TMP_InputField _inputFieldName;
    [SerializeField] private TMP_Dropdown _dropdownClass;

    [SerializeField] private GameObject playerPrefab;

    public void CreateNewCharacter()
    {
        characterNameInput = _inputFieldName.text;
        characterClassInput = (CharacterFeatures.CharacterClass)_dropdownClass.value;

        GameObject newCharacter = Instantiate(playerPrefab);

        newCharacter.transform.position = new Vector3(35, 0, 14);
        print(newCharacter.GetComponent<Character>());
        newCharacter.GetComponent<Character>().Initialization(characterNameInput, characterClassInput);

        gameObject.SetActive(false);
    }
}
