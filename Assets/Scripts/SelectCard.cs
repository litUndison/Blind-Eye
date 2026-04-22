using UnityEngine;

public class SelectCard : MonoBehaviour
{
    [SerializeField] private LayerMask _cardsLayer;
    [SerializeField] private float _speed;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, 1000f, _cardsLayer))
        {
            //raycastHit.collider.gameObject.GetComponent<CardScript>()._raise = true;
        }
    }
}
