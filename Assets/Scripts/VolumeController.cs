using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer _globalSound;
    [SerializeField] private Slider _soundSettings;
    [SerializeField] private string _soundParametr;

    private float _soundValue;
    private const float _soundMultiplier = 20f;
    private void Start()
    {
        _soundValue = PlayerPrefs.GetFloat(_soundParametr, Mathf.Log10(_soundSettings.value) * _soundMultiplier);
        _soundSettings.value = Mathf.Pow(10f, _soundValue / _soundMultiplier);
        _soundSettings.onValueChanged.AddListener(ChangeSound);
        _globalSound.SetFloat(_soundParametr, _soundValue);
    }
    private void ChangeSound(float value)
    {
        _soundValue = Mathf.Log10(value) * _soundMultiplier;
        _globalSound.SetFloat(_soundParametr, _soundValue);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_soundParametr, _soundValue);
    }
}
