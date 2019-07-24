using System;
using System.IO;

namespace DnDLookup.app
{
    public static class AppConstants
    {
        public static readonly string DndLookupAppData =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DnDLookup");
    }
}