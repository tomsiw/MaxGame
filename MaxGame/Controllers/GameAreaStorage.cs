using MaxGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MaxGame.Controllers
{
    public class GameAreaStorage
    {
        private static string defaultDir = ".\\Games";

        public static string DefaultDirectory { get { return Path.GetFullPath(defaultDir); } }

        public bool Save(GameArea area, string file)
        {
            try { SaveText(area.ToString(), file); return true; }
            catch (Exception) { return false; }
        }

        public GameArea Load(string file)
        {
            try
            {
                var area = new GameArea();
                if (area.FromString(LoadText(file)))
                    return area;
                return null;
            }
            catch (Exception) { return null; }
        }

        protected virtual void SaveText(string text, string file)
        {
            File.WriteAllText(file, text);
        }

        protected virtual string LoadText(string file)
        {
            return File.ReadAllText(file);
        }

        public static List<string> GetGameFilesFromDefaultLocation()
        {
            if (!Directory.Exists(DefaultDirectory))
                return new List<string>();
            return Directory.GetFiles(DefaultDirectory, "*.max").ToList();
        }

        public static void TryCreateDefaultGameDirectory()
        {
            if (Directory.Exists(DefaultDirectory))
                return;
            try { Directory.CreateDirectory(DefaultDirectory); }
            catch { }
        }

        public static string SelectFileToSave()
        {
            using (var sfd = new SaveFileDialog())
            {
                GameAreaStorage.TryCreateDefaultGameDirectory();
                sfd.RestoreDirectory = true;
                sfd.InitialDirectory = GameAreaStorage.DefaultDirectory;
                sfd.Filter = "Game files|*.max|All files|*.*";
                sfd.DefaultExt = ".max";
                if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return null;
                return sfd.FileName;
            }
        }

        public static string SelectFileToLoad()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.RestoreDirectory = true;
                ofd.DefaultExt = ".max";
                ofd.RestoreDirectory = true;
                ofd.InitialDirectory = GameAreaStorage.DefaultDirectory;
                ofd.Filter = "Game files|*.max|All files|*.*";
                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return null;
                return ofd.FileName;
            }
        }
    }
}
