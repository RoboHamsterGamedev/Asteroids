using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapVisualObject : MonoBehaviour
{
    [SerializeField] protected GameObject body2D;
    [SerializeField] protected GameObject body3D;
    void OnEnable()
    {
        Prepare();
    }

    private void OnDestroy()
    {
        OnDeath();
    }
    protected void Prepare()
    {
        GameMaster.onVisualChange += ChangeVisual;
        body2D = this.GetComponentInChildren<Rigidbody2D>(true).gameObject;
        body3D = this.GetComponentInChildren<Rigidbody>(true).gameObject;
    }
    public void ChangeVisual()
    {
        if (body2D != null)
        {
            if (body2D.activeSelf) 
            {
                SwapBodies(body2D, body3D);
            }
            else SwapBodies(body3D, body2D);
        }
    }
    protected virtual void SwapBodies(GameObject activeBody, GameObject futureBody)
    {
        futureBody.transform.position = activeBody.transform.position;
        futureBody.transform.rotation = activeBody.transform.rotation;
        activeBody.SetActive(false);
        futureBody.SetActive(true);
    }

    protected void OnDeath()
    {
        GameMaster.onVisualChange -= ChangeVisual;
    }
}
