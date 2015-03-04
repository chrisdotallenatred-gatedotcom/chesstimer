namespace Chess_Timer_v_4.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Drawing;
    using System.Media;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) SettingsBase.Synchronized(new Settings()));

        [DebuggerNonUserCode, DefaultSettingValue("White"), UserScopedSetting]
        public Color customThemeBgColour
        {
            get
            {
                return (Color) this["customThemeBgColour"];
            }
            set
            {
                this["customThemeBgColour"] = value;
            }
        }

        [UserScopedSetting, DebuggerNonUserCode, DefaultSettingValue("Highlight")]
        public Color customThemeTitleColour
        {
            get
            {
                return (Color) this["customThemeTitleColour"];
            }
            set
            {
                this["customThemeTitleColour"] = value;
            }
        }

        [DebuggerNonUserCode, DefaultSettingValue("Highlight"), UserScopedSetting]
        public Color customThemeValueColour
        {
            get
            {
                return (Color) this["customThemeValueColour"];
            }
            set
            {
                this["customThemeValueColour"] = value;
            }
        }

        [DebuggerNonUserCode, UserScopedSetting]
        public SoundPlayer CustomWarningSound
        {
            get
            {
                return (SoundPlayer) this["CustomWarningSound"];
            }
            set
            {
                this["CustomWarningSound"] = value;
            }
        }

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [UserScopedSetting, DefaultSettingValue("True"), DebuggerNonUserCode]
        public bool EnablePauseKey
        {
            get
            {
                return (bool) this["EnablePauseKey"];
            }
            set
            {
                this["EnablePauseKey"] = value;
            }
        }

        [DefaultSettingValue("True"), UserScopedSetting, DebuggerNonUserCode]
        public bool EnableWinKey
        {
            get
            {
                return (bool) this["EnableWinKey"];
            }
            set
            {
                this["EnableWinKey"] = value;
            }
        }

        [UserScopedSetting, DebuggerNonUserCode, DefaultSettingValue("p")]
        public char PauseKey
        {
            get
            {
                return (char) this["PauseKey"];
            }
            set
            {
                this["PauseKey"] = value;
            }
        }

        [DebuggerNonUserCode, DefaultSettingValue("0"), UserScopedSetting]
        public int selectedTheme
        {
            get
            {
                return (int) this["selectedTheme"];
            }
            set
            {
                this["selectedTheme"] = value;
            }
        }

        [DebuggerNonUserCode, DefaultSettingValue("True"), UserScopedSetting]
        public bool showSplashOnExit
        {
            get
            {
                return (bool) this["showSplashOnExit"];
            }
            set
            {
                this["showSplashOnExit"] = value;
            }
        }

        [UserScopedSetting, DefaultSettingValue("100"), DebuggerNonUserCode]
        public int updateInterval
        {
            get
            {
                return (int) this["updateInterval"];
            }
            set
            {
                this["updateInterval"] = value;
            }
        }

        [DebuggerNonUserCode, UserScopedSetting, DefaultSettingValue("0")]
        public int WarningSound
        {
            get
            {
                return (int) this["WarningSound"];
            }
            set
            {
                this["WarningSound"] = value;
            }
        }

        [UserScopedSetting, DebuggerNonUserCode, DefaultSettingValue("w")]
        public char WinKey
        {
            get
            {
                return (char) this["WinKey"];
            }
            set
            {
                this["WinKey"] = value;
            }
        }
    }
}

