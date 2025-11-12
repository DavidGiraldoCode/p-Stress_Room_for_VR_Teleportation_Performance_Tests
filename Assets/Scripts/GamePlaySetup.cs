using UnityEngine;

public enum TeleportationType
{
    STANDARD
    // Add here your teleportation methods to test
}

/// <summary>
/// Defines the setting at startup. These attributes won't change during gameplay, but can be modified by the artist.
/// </summary>
[CreateAssetMenu(fileName = "GamePlaySetup", menuName = "Scriptable Objects/GamePlaySetup")]
public class GamePlaySetup : ScriptableObject
{
    [Header("Platform Timing Settings")]
    [Tooltip("Time (seconds) the player has to reach the new platform.")]
    [Range(10, 50)]
    [SerializeField] private float timeoutToReachPlatform = 50f;

    [Header("Teleportation Area Settings")]
    [Tooltip("Default radius of the teleportation area before shrinking.")]
    [Range(0.6f, 4.0f)]
    [SerializeField] private float teleportationAreaRadius = 2f;

    [Tooltip("Minimum radius of the teleportation area after it finishes shrinking.")]
    [Range(0.1f, 0.5f)]
    [SerializeField] private float minimumTeleportationAreaRadius = 0.2f;

    [Tooltip("Number of steps over which the teleportation area shrinks to its minimum size.")]
    [Range(1, 10)]
    [SerializeField] private uint teleportationAreaShrinkingSteps = 5;


    [Header("Game Mode Settings")]
    [Tooltip("Number of areas to teleport to.")]
    [Range(2,8)]
    [SerializeField] private uint teleportationAreasCount = 6;
    [Tooltip("Number of teleportation destinations in the real game mode.")]
    [Range(1,50)]
    [SerializeField] private uint realGameTeleportationDestinationsCount = 5;

    [Tooltip("Number of teleportation destinations in the tryout (practice) mode.")]
    [Range(1,5)]
    [SerializeField] private uint tryoutGameTeleportationDestinationsCount = 3;

   

    // Exposing setting as read-only attributes
    public float TeleportationAreaRadius => teleportationAreaRadius;
    public float MinimumTeleportationAreaRadius => minimumTeleportationAreaRadius;
    public uint TeleportationAreaShrinkingSteps => teleportationAreaShrinkingSteps;
    public uint TeleportationAreaCount => teleportationAreasCount;
    public uint RealGameTeleportationDestinationsCount => realGameTeleportationDestinationsCount;
    public uint TryoutGameTeleportationDestinationsCount => tryoutGameTeleportationDestinationsCount;
    //public TeleportationType TeleportationType => teleportationType;
    //public bool BiasedColorInstruction => biasedColorInstruction;
    //public float ReductionOnTimeoutToReachPlatform => reductionOnTimeoutToReachPlatform;
    //public float ReductionOnTeleportationAreaRadius => reductionOnTeleportationAreaRadius;

}
