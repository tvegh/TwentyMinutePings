using BepInEx;
using BepInEx.Configuration;
using R2API.Utils;


namespace TwentyMinutePing
{
	[BepInDependency("com.bepis.r2api")]
	[BepInPlugin("com.TeaBoneJones.TwentyMinutePing", "20 Minute Ping", "1.0.0")]
	public class TwentyMinutePing:BaseUnityPlugin
	{
        private static ConfigWrapper<int> minutes;
        public void Awake()
        {
            minutes = Config.Wrap<int>("Ping Indicator", "Minutes", "Set how long you want the ping to be enabled for, in minutes. Default = 20", 20);
            float seconds = minutes.Value * 60;
            On.RoR2.UI.PingIndicator.RebuildPing += (orig, self) =>
            {
                orig(self);
                self.SetFieldValue<float>("fixedTimer", seconds);
            };
        }
	}
}