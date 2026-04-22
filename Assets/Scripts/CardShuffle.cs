using System.Collections.Generic;
using System;
using UnityEngine;

public class CardShuffle : MonoBehaviour
{
    [SerializeField] public List<GameObject> _cards;
    [SerializeField] private float _horizontalshift;
    [SerializeField] private float _verticalshift;

    void Awake()
    {
        List<GameObject> templist = new List<GameObject>();
        for(int i = 0; i < 32; i++)
        {
            int id = UnityEngine.Random.Range(0, _cards.Count);
            templist.Add(_cards[id]);
            _cards.RemoveAt(id);
        }
        _cards = templist;
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                _cards[j + i * 8].transform.position = new Vector3(transform.position.x + _horizontalshift * (float)j, transform.position.y, transform.position.z - _verticalshift * (float)i);
            }
        }
    }
}
