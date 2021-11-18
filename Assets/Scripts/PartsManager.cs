using System.Collections.Generic;
using UnityEngine;

public class PartsManager : MonoBehaviour
{
    [SerializeField] private List<LabPart> _parts;
    
    public static PartsManager Instance { get; private set; }
    public List<LabPart> Parts { get => _parts; private set => _parts = value; }

    private void Awake()
    {
        Instance = this;

        var parts = FindObjectsOfType<LabPart>();
        Parts = new List<LabPart>(parts);
    }
}