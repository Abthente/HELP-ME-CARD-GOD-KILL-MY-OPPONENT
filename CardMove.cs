using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardMove : MonoBehaviour
{
    private Collider2D col;
    private List<Collider2D> res = new List<Collider2D>();
    private RaycastHit2D ray;

    private Vector3 mousePos;
    private Vector3 oldTransform;
    public Vector3 offset;


    public ContactFilter2D CardZone;


    private void Start()
    {
        CardZone.SetLayerMask(LayerMask.GetMask("CardZone"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ray = Physics2D.Raycast(mousePos, mousePos, 1, LayerMask.GetMask("Card"));
            if (ray)
            {
                col = ray.collider;
                oldTransform = ray.transform.position;
                offset = ray.transform.position - mousePos;
                offset.z = 1;
            }

        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (ray)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 1;
                ray.transform.position = mousePos + offset;
            }

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (ray)
            {
                Physics2D.OverlapCollider(col, CardZone, res);
                if ((res.Count != 0) && (res[0].GetComponent<HandPlace>()))
                {

                        if (res[0].GetComponent<HandPlace>().AddCards(ray.transform.gameObject))
                        {
                            ray.transform.GetComponentInParent<HandPlace>().DisableCards(ray.transform.gameObject);
                            ray.transform.SetParent(res[0].transform);
                        }

                    else
                    {
                        ray.transform.position = oldTransform;
                    }
                }
                else
                {
                    ray.transform.position = oldTransform;
                }
            }
        }
    }
}
