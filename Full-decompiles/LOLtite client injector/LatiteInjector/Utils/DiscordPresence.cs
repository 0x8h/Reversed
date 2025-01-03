// Decompiled with JetBrains decompiler
// Type: LatiteInjector.Utils.DiscordPresence
// Assembly: Latite Injector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D039E1F9-EF08-4636-8A07-8C738977DAE1
// Assembly location: C:\Users\user\Downloads\Injector.exe

using DiscordRPC;

#nullable enable
namespace LatiteInjector.Utils
{
  public static class DiscordPresence
  {
    private static readonly DiscordRpcClient DiscordClient = new DiscordRpcClient("1066896173799047199");

    public static void InitializePresence() => DiscordPresence.DiscordClient.Initialize();

    public static void DefaultPresence()
    {
      DiscordRpcClient discordClient = DiscordPresence.DiscordClient;
      RichPresence richPresence1 = new RichPresence();
      ((BaseRichPresence) richPresence1).State = "Idling in the injector";
      ((BaseRichPresence) richPresence1).Timestamps = Timestamps.Now;
      richPresence1.Buttons = new Button[1]
      {
        new Button()
        {
          Label = "Download Latite Client",
          Url = "https://discord.gg/zcJfXxKTA4"
        }
      };
      ((BaseRichPresence) richPresence1).Assets = new Assets()
      {
        LargeImageKey = "latite",
        LargeImageText = "Latite Client Icon"
      };
      RichPresence richPresence2 = richPresence1;
      discordClient.SetPresence(richPresence2);
      MainWindow.IsDiscordPresenceEnabled = true;
    }

    public static void PlayingPresence()
    {
      if (!MainWindow.IsCustomDll)
      {
        DiscordPresence.DiscordClient.UpdateDetails("Playing Minecraft " + MainWindow.MinecraftVersion);
        DiscordPresence.DiscordClient.UpdateState("with Latite Client");
      }
      else
      {
        if (!MainWindow.IsCustomDll)
          return;
        DiscordPresence.DiscordClient.UpdateDetails("Playing Minecraft " + MainWindow.MinecraftVersion);
        DiscordPresence.DiscordClient.UpdateState("with " + MainWindow.CustomDllName);
      }
    }

    public static void IdlePresence()
    {
      DiscordPresence.DiscordClient.UpdateState("Idling in the injector");
      DiscordPresence.DiscordClient.UpdateDetails("");
    }

    public static void SettingsPresence()
    {
      DiscordPresence.DiscordClient.UpdateState("Changing settings");
    }

    public static void ChangelogPresence()
    {
      DiscordPresence.DiscordClient.UpdateState("Reading the changelog");
    }

    public static void CreditsPresence()
    {
      DiscordPresence.DiscordClient.UpdateState("Reading the credits");
    }

    public static void MinimizeToTrayPresence()
    {
      if (!MainWindow.IsMinecraftRunning)
        DiscordPresence.DiscordClient.UpdateState("Minimized to tray");
      else
        DiscordPresence.PlayingPresence();
    }

    public static void StopPresence()
    {
      DiscordPresence.DiscordClient.ClearPresence();
      MainWindow.IsDiscordPresenceEnabled = false;
    }

    public static void ShutdownPresence()
    {
      if (DiscordPresence.DiscordClient.IsDisposed)
        return;
      DiscordPresence.DiscordClient.ClearPresence();
      DiscordPresence.DiscordClient.Deinitialize();
      DiscordPresence.DiscordClient.Dispose();
      MainWindow.IsDiscordPresenceEnabled = false;
    }
  }
}
