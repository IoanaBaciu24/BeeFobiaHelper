using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public GameObject uiText;
    //public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        uiText.SetActive(false);
    }
    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(3);
        uiText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            uiText.SetActive(true);
            StartCoroutine("WaitFor");
        }
    }
    // Update is called once per frame
    //void Update()
    //{
    //    if(Vector3.Distance(player.transform.position, transform.position) < 3)
    //    {
    //        uiText.SetActive(true);
    //        StartCoroutine("WaitFor");
    //    }
    //}
}
