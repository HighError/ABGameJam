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
}