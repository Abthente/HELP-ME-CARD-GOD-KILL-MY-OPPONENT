using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandPlace : MonoBehaviour
{
    [SerializeField] List<GameObject> obj;
    [SerializeField] float distance;
    [SerializeField] int limit;

    private void Start()
    {
        if (obj.Count != 0)
        {
            foreach (GameObject _obj in obj)
            {
                _obj.transform.parent = transform;
            }
            SetCards(obj,distance);
        }
    }


    public void SetCards(List<GameObject> obj, float x)
    {
        if ((obj.Count != 0)&&(limit >= obj.Count))
        {
            Vector3 pos = transform.position;
            pos.x = pos.x - ((obj.Count - 1) / 2f * (obj[0].transform.localScale.x + x));
            for (int i = 0; i < obj.Count; i++)
            {
                obj[i].transform.position = pos;
                pos.x += obj[i].transform.localScale.x + distance;
            }
        }
        else
        {
            Debug.Log("лох");
        }
    }
    public bool AddCards(GameObject _obj)
    {
        if (obj.Count + 1 <= limit)
        {
            obj.Add(_obj);
            SetCards(obj, distance);
            return true;
        }

        return false;

    }
    public void DisableCards(GameObject _obj)
    {
        obj.Remove(_obj);
        SetCards(obj, distance);
    }
}
