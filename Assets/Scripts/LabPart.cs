﻿using UnityEngine;

public class LabPart : MonoBehaviour, IInteractable
{
    [SerializeField] private string _itemName;

    private Outline _outline;

    public string ItemName => _itemName;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
    }

    public void OnInteractStart()
    {
        _outline.enabled = true;
    }

    public void OnInteractStop()
    {
        _outline.enabled = false;
    }

    public void OnClicked()
    {
        FocusManager.Instance.SetCurrentPart(this);
    }
}
