using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    
    [HideInInspector] public int playerPosition; 
    [HideInInspector] public int stepCount;
    public SpaceManager spaceManager;
    [SerializeField] private Button _nextStepButton;

    private void Awake()
    {
        _nextStepButton.onClick.AddListener(spaceManager.NextStep);
        spaceManager.CreateRound(0);
    }
}
