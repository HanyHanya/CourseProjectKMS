using System;
using UnityEngine;
using UnityEngine.UI;

public class LabItemsDropdown : MonoBehaviour
{
    private Dropdown _dropdown;
    private void Start()
    {
        _dropdown = GetComponent<Dropdown>();

        _dropdown.onValueChanged.AddListener(OnValueChangedHandler);
        FocusManager.OnPartChanged += OnPartChangedHandler;

        PartsManager.Instance.Parts.ForEach(item => _dropdown.options.Add(new Dropdown.OptionData(item.ItemName)));
    }

    private void OnPartChangedHandler(LabPart obj)
    {
        for (int i = 0; i < _dropdown.options.Count; i++)
        {
            if (_dropdown.options[i].text == obj.ItemName)
            {
                _dropdown.value = i;
                break;
            }
        }
    }

    private void OnValueChangedHandler(int idx)
    {
        string name = _dropdown.options[idx].text;

        foreach (var part in PartsManager.Instance.Parts)
        {
            if (part.ItemName == name)
            {
                part.OnClicked();
                break;
            }
        }
    }
}
