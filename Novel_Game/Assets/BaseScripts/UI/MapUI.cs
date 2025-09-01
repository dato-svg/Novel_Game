using UnityEngine;
using UnityEngine.UI;
using Naninovel;
using Naninovel.UI;

public class MapUI : CustomUI
{
    [SerializeField] private Button location1Btn;
    [SerializeField] private Button location2Btn;
    [SerializeField] private Button location3Btn;

    // protected override void Awake()
    // {
    // base.Awake();
    // location1Btn.onClick.AddListener(() => MoveTo("Location1"));
    // location2Btn.onClick.AddListener(() => MoveTo("Location2"));
    // location3Btn.onClick.AddListener(() => MoveTo("Location3"));
    // }

    // private async void MoveTo(string location)
    // {
    //    var player = Engine.GetService<IScriptPlayer>();
    //    await player.PreloadAndPlayAsync(location);
    // }
}
