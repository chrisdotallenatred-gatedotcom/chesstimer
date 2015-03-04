namespace Chess_Timer_v_4.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        internal static Bitmap CT_cross
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("CT_cross", resourceCulture);
            }
        }

        internal static Bitmap CT_tick
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("CT_tick", resourceCulture);
            }
        }

        internal static byte[] CTDIG
        {
            get
            {
                return (byte[]) ResourceManager.GetObject("CTDIG", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static byte[] MotorwerkOblique
        {
            get
            {
                return (byte[]) ResourceManager.GetObject("MotorwerkOblique", resourceCulture);
            }
        }

        internal static byte[] pcf
        {
            get
            {
                return (byte[]) ResourceManager.GetObject("pcf", resourceCulture);
            }
        }

        internal static byte[] pcf1
        {
            get
            {
                return (byte[]) ResourceManager.GetObject("pcf1", resourceCulture);
            }
        }

        internal static byte[] QuartzMS
        {
            get
            {
                return (byte[]) ResourceManager.GetObject("QuartzMS", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("Chess_Timer_v_4.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }
    }
}

