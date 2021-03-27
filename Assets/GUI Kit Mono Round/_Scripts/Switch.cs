using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    [SerializeField] private Image switchHandle;
    
    [Space(5)]
    [SerializeField] private Sprite switchOn;
    [SerializeField] private Sprite switchOff;
    
    [FormerlySerializedAs("_isOn")] [SerializeField] private bool isOn = false;

    public Button _button;
    private Slider _slider;

    public Color onColor;
    public Color offColor;
    public TextMeshProUGUI notificationText;

    // Start is called before the first frame update
    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClickSwitchButton);
        _slider = transform.GetChild(0).GetComponent<Slider>();

    }

    private void OnClickSwitchButton()
    {
        if (!isOn) isOn = true;
        else isOn = false;

        _button.enabled = false;

        StartCoroutine(ActiveSwitchSlider());
    }


    public void OnClickSwitchButton(bool on)
    {
        if (!on) isOn = true;
        else isOn = false;

        _button.enabled = false;

        StartCoroutine(ActiveSwitchSlider());
    }

    IEnumerator ActiveSwitchSlider()
    {
        float endValue = 0;
        Sprite handle = switchOff;
        if (isOn)
        {
            endValue = 1;
            handle = switchOn;
            notificationText.color = onColor;
            notificationText.text = "ON";
        }
        else
        {
            notificationText.color = offColor;
            notificationText.text = "OFF";
        }
  
        while (_slider.value != endValue)
        {
            if(isOn) _slider.value += Time.smoothDeltaTime * 10;
            else _slider.value -= Time.smoothDeltaTime * 10;
            
            yield return null;
        }

        switchHandle.sprite = handle; 
        
        yield return new WaitForEndOfFrame();
        
        _button.enabled = true;
    }
    
    
}
