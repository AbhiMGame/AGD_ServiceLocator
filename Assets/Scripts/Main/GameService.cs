
using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
   public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    public WaveService waveService { get; private set; }
    public MapService mapService { get; private set; }


    [SerializeField] private UIService uIService;
    public UIService UIservice => uIService;

    [SerializeField] private WaveScriptableObject waveScriptableObject;
    public WaveService WaveService => waveService;

    [SerializeField] private MapScriptableObject mapScriptableObject;
    public MapService MapService => mapService;


    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    // [SerializeField] private MapScriptableObject MapScriptableObject;
   
   

    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;
    private SpriteRenderer tileOverlay;
    public GameEventController<int> OnMapSelected { get; private set; }

    private void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
        waveService = new WaveService(waveScriptableObject);
        soundService = new SoundService(soundScriptableObject,audioEffects,backgroundMusic);
        mapService = new MapService(mapScriptableObject,tileOverlay);


    }

    private void Update()
    {
        playerService.Update();
    }

}
