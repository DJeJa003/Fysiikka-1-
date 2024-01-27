using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muutaKorkeusSlider : MonoBehaviour
{
    public Slider korkeusSlider;
    public float minKorkeus = 5.0f;
    public float maxKorkeus = 200.0f;
    public RectTransform objectRectTransform;
    public float alkuPaikkaX = 0f;
    public float loppuPaikkaX = 1000f;

    //public float nykyKorkeus;

    private void Start()
    {
        //nykyKorkeus = minKorkeus;
        asetaKorkeus(0);
    }
    
    public void asetaKorkeus(float value)
    {
        float uusiKorkeus = Mathf.Lerp(minKorkeus, maxKorkeus, value);
        Vector3 uusiPaikka = objectRectTransform.anchoredPosition;
        uusiPaikka.y = uusiKorkeus;
        objectRectTransform.anchoredPosition = uusiPaikka;
        //nykyKorkeus = Mathf.Lerp(minKorkeus, maxKorkeus, value);
        //float uusiPaikka = Mathf.Lerp(alkuPaikkaX, loppuPaikkaX, value);
        //objectRectTransform.anchoredPosition = new Vector2(uusiPaikka, objectRectTransform.anchoredPosition.x);
        //transform.localScale = new Vector3(transform.localScale.x, uusiKorkeus, transform.localScale.z);
    }
}
