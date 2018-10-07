using strange.extensions.mediation.impl;

namespace Views.UI
{
    public class BackgroundMusicView : EventView
    {
        protected override void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}