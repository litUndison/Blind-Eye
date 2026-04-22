using UnityEngine;
public class MouseTrigger : MonoBehaviour
{
    [SerializeField] public AudioSource _entersound;
    [SerializeField] private float _emissionpower = 5f;
    
    private CardScript _card;
    private CardManagement _manager;

    private MeshRenderer _renderer;
    private MaterialPropertyBlock _mpb;
    private Color _baseEmission;
    private GameObject Canvas;

    void Awake()
    {
        _manager = GameObject.FindGameObjectWithTag("CardsManager").GetComponent<CardManagement>();
        Canvas = GameObject.FindGameObjectWithTag("GUI");
        _renderer = GetComponent<MeshRenderer>();
        _card = GetComponent<CardScript>();
        _mpb = new MaterialPropertyBlock();
        _baseEmission = _renderer.sharedMaterial.GetColor("_EmissionColor");
    }

    void OnMouseEnter()
    {
        if (!_manager._canSelectCards)
        {
            return;
        }
        
        _card.enabled = true;
        _card.Raise();
        SetEmission(_baseEmission * _emissionpower);
    }

    void OnMouseExit()
    {
        if (!_manager._canSelectCards)
        {
            return;
        }

        _card.enabled = true;
        _card.Lower();
        SetEmission(_baseEmission);
    }
    void OnMouseDown()
    {
        if (!_manager._canSelectCards)
        {
            return;
        }
        _entersound.Play();
        _card.FlyAway();
    }
    private void SetEmission(Color color)
    {
        _renderer.GetPropertyBlock(_mpb);
        _mpb.SetColor("_EmissionColor", color);
        _renderer.SetPropertyBlock(_mpb);
    }
}
