using System;

namespace Celeste.Mod.NoDialogCeleste;

public class NoDialogCelesteModule : EverestModule {
    public static NoDialogCelesteModule Instance { get; private set; }

    public override Type SettingsType => typeof(NoDialogCelesteModuleSettings);
    public static NoDialogCelesteModuleSettings Settings => (NoDialogCelesteModuleSettings) Instance._Settings;

    public override Type SessionType => typeof(NoDialogCelesteModuleSession);
    public static NoDialogCelesteModuleSession Session => (NoDialogCelesteModuleSession) Instance._Session;

    public override Type SaveDataType => typeof(NoDialogCelesteModuleSaveData);
    public static NoDialogCelesteModuleSaveData SaveData => (NoDialogCelesteModuleSaveData) Instance._SaveData;

    public NoDialogCelesteModule() {
        Instance = this;
#if DEBUG
        // debug builds use verbose logging
        Logger.SetLogLevel(nameof(NoDialogCelesteModule), LogLevel.Verbose);
#else
        // release builds use info logging to reduce spam in log files
        Logger.SetLogLevel(nameof(NoDialogCelesteModule), LogLevel.Info);
#endif
    }

    public override void Load() {
        On.Celeste.Textbox.Render += modRender;
    }

    public override void Unload() {
        On.Celeste.Textbox.Render -= modRender;
    }

    private static void modRender(On.Celeste.Textbox.orig_Render orig, Textbox self) {
        // Don't call orig, just don't render anything
    }
}