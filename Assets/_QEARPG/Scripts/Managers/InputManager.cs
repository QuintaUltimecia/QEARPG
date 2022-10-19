using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private JoyStick _joyStick;

    private void Awake()
    {
        if (_joyStick.TryGetComponent(out IGiveInput giveInput))
        {
            _playerController.InitGiveInput(giveInput);
        }
        else
        {
            throw new System.Exception($"{nameof(_joyStick)} does not contained {nameof(IGiveInput)}");
        }
    }
}
