public class EventSystem
{
    public delegate void EventHandler();

    public static event EventHandler OnGameLosed;
    public static void CallOnGoldCountChanged() { if (OnGameLosed != null) OnGameLosed(); }

    public static event EventHandler OnWindowsCloseNeeded;
    public static void CallOnRaceStarted() { if (OnWindowsCloseNeeded != null) OnWindowsCloseNeeded(); }

    public static event EventHandler OnLevelCompleted;
    public static void CallOnLevelCompleted() { if (OnLevelCompleted != null) OnLevelCompleted(); }
}