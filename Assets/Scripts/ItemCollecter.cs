using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollecter : MonoBehaviour
{
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collect;
    private int cherries = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cherry")){
            collect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: "+ cherries;
        }
    }
}
