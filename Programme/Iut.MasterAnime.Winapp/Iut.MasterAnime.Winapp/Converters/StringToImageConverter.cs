using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Iut.MasterAnime.Winapp.Converters
{
    /// <summary>
    /// Classe permettant de convertir un string en un Uri, et donc d'afficher l'image souhaitée
    /// </summary>
    class StringToImageConverter : IValueConverter
    {
        /// <summary>
        /// Le répertoir où se trouve les images
        /// </summary>
        public static String ImagesPath
        {
            get => imagesPath;
            private set { imagesPath = value; }
        }
        private static string imagesPath;

        /// <summary>
        /// Le constructeur de la classe StringToImageConverter
        /// </summary>
        static StringToImageConverter()
        {
            ImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\Images\\");
        }

        /// <summary>
        /// Le converteur de string vers un Uri pour afficher une image. Celui-ci se base sur le répertoire des imges ImagesPath
        /// </summary>
        /// <param name="value">Le string à convertire, et donc le nom de l'image</param>
        /// <param name="targetType">un Uri pour afficher une image</param>
        /// <param name="parameter">Non utilisé</param>
        /// <param name="culture">Non utilisé</param>
        /// <returns>Le Uri de l'image à afficher ou null si le nom n'est pas correcte</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String imageName = value as String;

            if (String.IsNullOrWhiteSpace(imageName)) return null;
            
            Uri retour;

            if (File.Exists(Path.Combine(ImagesPath, imageName)))
            {
                retour = new Uri(Path.Combine(ImagesPath, imageName), UriKind.RelativeOrAbsolute);
            }
            else
            {
                retour = new Uri(Path.Combine(ImagesPath, "PlacerImage.png"), UriKind.RelativeOrAbsolute);
            }

            return retour;
        }

        /// <summary>
        /// Cette méthode n'est pas implémentée
        /// </summary>
        /// <param name="value">La méthode n'est pas implémentée</param>
        /// <param name="targetType">La méthode n'est pas implémentée</param>
        /// <param name="parameter">La méthode n'est pas implémentée</param>
        /// <param name="culture">La méthode n'est pas implémentée</param>
        /// <returns>La méthode n'est pas implémentée</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
