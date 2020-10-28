using Iut.MasterAnime.Winapp.Converters;
using System;
using System.IO;

namespace Iut.MasterAnime.Winapp
{
    /// <summary>
    /// Classe pouvant regrouper des méthdes utiles à d'autres classes
    /// </summary>
    public static class Utilitaires
    {
        /// <summary>
        /// Méthode permettant d'ouvrir une boite de dialogue pour que l'utilisateur choisisse une image. Celle-ci sera ensuite placée dans le dossier des Images de l'application
        /// </summary>
        /// <returns>Rends le nom de l'image</returns>
        public static string ExplorateurImage()
        {
            //Configuration de l'ouverture de la boite de dialogue
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Images";
            dialog.DefaultExt = ".jpg | .gif | .png";
            dialog.Filter = "All images files (*.jpg, *.gif, *.png) | *.jpg; *.gif; *.png | JPG files(.jpg) | *.jpg | GIF files(.gif) | *.gif | PNG files(.png) | *.png";

            //Ouverture de la boite de dialogue
            bool? result = dialog.ShowDialog();

            //Traitement du retour de la boite de dialogue
            if (result == true)
            {
                //Récupération du document
                FileInfo fi = new FileInfo(dialog.FileName);
                String filename = fi.Name;
                int i = 0;
                //Donne un nouveau nom à l'image si il existe déjà un fichier avec ce nom
                while (File.Exists(System.IO.Path.Combine(StringToImageConverter.ImagesPath, filename)))
                {
                    filename = $"{fi.Name.Remove(fi.Name.LastIndexOf('.'))}_{i}{fi.Extension}";
                    i++;
                }
                File.Copy(dialog.FileName, System.IO.Path.Combine(StringToImageConverter.ImagesPath, filename));
                return filename;
            }
            return null;
        }
    }
}
