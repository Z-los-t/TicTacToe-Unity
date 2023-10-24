using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
   
   [SerializeField] private  GameObject X;
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
    }
    public void Selected()
    {
       var inst= Instantiate(X, button.transform.position, transform.rotation);
        inst.transform.SetParent(button.transform);
        button.interactable = false;
        Debug.Log("geyf");
    }
}
