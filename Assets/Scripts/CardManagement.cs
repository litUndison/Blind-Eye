using UnityEngine;
using UnityEngine.InputSystem;

public class CardManagement : MonoBehaviour
{
    public bool _canSelectCards { get; private set; } = true;

    [SerializeField] private GameObject[] cards;

    public void LockCards()
    {
        _canSelectCards = false;
    }

    public void UnlockCards()
    {
        _canSelectCards = true;
    }
}

