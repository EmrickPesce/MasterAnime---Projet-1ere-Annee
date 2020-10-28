namespace Iut.MasterAnime.ClassLibrary
{
    /// <summary>
    /// Permet de connaitre le type de l'oeuvre. 'Tout' n'étant pas un type, mais peut être utiliser pour des recherches
    /// </summary>
    public enum TypeOeuvre
    {
        Tout,
        Film,
        Série,
        Livre,
        Scan,
        Animé,
        Autre
    }

    /// <summary>
    /// Permet de définir le référentiel que l'on prend par rapport à une date dans la recherche d'une oeuvre
    /// </summary>
    public enum DateQuand
    {
        NonUtilisé,
        Avant,
        Pendant,
        Après
    }

    /// <summary>
    /// Permet de définir l'ordre d'un tri
    /// </summary>
    public enum OrdreTri
    {
        Croissant,
        Décroissant,
        Date_de_sortie,
        Type
    }
}
