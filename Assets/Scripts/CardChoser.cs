using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardChoser : MonoBehaviour
{
    [SerializeField] private LayerMask _cardlayer;
    [SerializeField] private float _risedistance;
    [SerializeField] private float _movespeed;
    [SerializeField] private Animator _animator;
    private GameObject _choosedcard;
    private List<GameObject> _unchoosedcards = new List<GameObject>();

    void Update()
    {
        Ray chooseray = new Ray(transform.position + transform.up * 10.0f, transform.up * -1);
        RaycastHit rayhit;
        if(Physics.Raycast(chooseray, out rayhit, 100.0f, _cardlayer))
        {
            if(_choosedcard != rayhit.collider.gameObject)
            {
                if(_choosedcard != null)
                {
                    _unchoosedcards.Add(_choosedcard);
                    _choosedcard = null;
                }
                if(_unchoosedcards.Contains(rayhit.collider.gameObject))
                {
                    _unchoosedcards.Remove(rayhit.collider.gameObject);
                }
                _choosedcard = rayhit.collider.gameObject;
            }
        }
        else
        {
            if(_choosedcard != null)
            {
                _unchoosedcards.Add(_choosedcard);
                _choosedcard = null;
            }
        }

        if(_choosedcard != null)
        {
            if(_choosedcard.transform.position.y < _choosedcard.GetComponent<CardInfo>().StartAltitude + _risedistance)
            {
                float maxytranslation = _movespeed * Time.deltaTime;
                float accesibleytranslation = _choosedcard.GetComponent<CardInfo>().StartAltitude + _risedistance - _choosedcard.transform.position.y;
                if(maxytranslation > accesibleytranslation)
                {
                    maxytranslation = accesibleytranslation;
                }
                if(maxytranslation > 0)
                {
                    _choosedcard.transform.Translate(0.0f, -maxytranslation, 0.0f);
                }
            }
            if(Input.GetKeyDown(KeyCode.Mouse0) && !_animator.GetCurrentAnimatorStateInfo(0).IsName("Click"))
            {
                _choosedcard.GetComponent<CardRotater>().enabled = true;
                Destroy(_choosedcard.GetComponent<BoxCollider>());
                GameObject manager = GameObject.Find("Manager");
                manager.GetComponent<WorkManager>()._cards.Add(_choosedcard.GetComponent<CardInfo>()._cardname);
                _choosedcard = null;
                if(manager.GetComponent<WorkManager>()._cards.Count >= 5)
                {
                    GetComponent<CursorEndHandler>().enabled = true;
                    GameObject.Find("Manager").GetComponent<WorkManager>().MakePrompt();
                }
            }
        }

        if(_unchoosedcards.Count != 0)
        {
            List<GameObject> lyingcards = new List<GameObject>();
            foreach(GameObject card in _unchoosedcards)
            {
                float maxytranslation = _movespeed * Time.deltaTime;
                float accesibleytranslation = card.transform.position.y - card.GetComponent<CardInfo>().StartAltitude;
                if(maxytranslation > accesibleytranslation)
                {
                    maxytranslation = accesibleytranslation;
                }
                if(maxytranslation > 0)
                {
                    card.transform.Translate(0.0f, maxytranslation, 0.0f);
                }
                if(card.transform.position.y == card.GetComponent<CardInfo>().StartAltitude)
                {
                    lyingcards.Add(card);
                }
            }
            if(lyingcards.Count != 0)
            {
                foreach(GameObject card in lyingcards)
                {
                    _unchoosedcards.Remove(card);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position + transform.up * 10.0f, transform.position + transform.up * -100.0f);
    }
}
