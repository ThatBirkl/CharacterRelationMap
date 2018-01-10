using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_NewNodeCancel : MonoBehaviour
{
    private Button buttonCancel;
    void Start ()
    {
        buttonCancel = transform.GetChild(2).GetComponent<Button>(); //Get the Cancel Button
        buttonCancel.onClick.AddListener(OnClick);
    }
	
	void Update ()
    {
        if (Input.GetButtonDown("Escape"))
        {
            OnClick();
        }
	}

    private void OnClick()
    {
        Destroy(gameObject);
    }
}
