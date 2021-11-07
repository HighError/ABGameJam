public class EventSystem
{
    public delegate void EventHandler();

    public static event EventHandler OnGameLosed;
    public static void CallOnGameLosed() { if (OnGameLosed != null) OnGameLosed(); }

    public static event EventHandler OnWindowsCloseNeeded;
    public static void CallOnWindowsCloseNeeded() { if (OnWindowsCloseNeeded != null) OnWindowsCloseNeeded(); }

    public static event EventHandler OnLevelCompleted;
    public static void CallOnLevelCompleted() { if (OnLevelCompleted != null) OnLevelCompleted(); }

    public static event EventHandler OnUpdateScoreNeeded;
    public static void CallOnUpdateScoreNeeded() { if (OnUpdateScoreNeeded != null) OnUpdateScoreNeeded(); }

    public static event EventHandler OnEnableMissionDetailWindowNeeded;
    public static void CallOnEnableMissionDetailWindowNeeded() { if (OnEnableMissionDetailWindowNeeded != null) OnEnableMissionDetailWindowNeeded(); }

    public static event EventHandler OnRecordUpdateNeeded;
    public static void CallOnRecordUpdateNeeded() { if (OnRecordUpdateNeeded != null) OnRecordUpdateNeeded(); }

    public static event EventHandler OnSoundSettingsUpdateNeeded;
    public static void CallOnSoundSettingsUpdateNeeded() { if (OnSoundSettingsUpdateNeeded != null) OnSoundSettingsUpdateNeeded(); }

    public static event EventHandler OnNotificationsShowNeeded;
    public static void CallOnNotificationsShowNeeded() { if (OnNotificationsShowNeeded != null) OnNotificationsShowNeeded(); }

    public static event EventHandler OnOverlayUpdateNeeded;
    public static void CallOnOverlayUpdateNeeded() { if (OnOverlayUpdateNeeded != null) OnOverlayUpdateNeeded(); }
}