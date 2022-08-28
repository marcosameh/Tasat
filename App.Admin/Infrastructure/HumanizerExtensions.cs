namespace Humanizer
{
    public static partial class StringHumanizeExtensions
    {
        public static string Humanize2(this string input)
        {
            var humanized = input.Humanize();
            var words = humanized.Split(' ');
            for (int i = 0; i < words.Length; i++)
                if (words[i] == "photoes")
                    words[i] = "photos";
                else if (words[i] == "Photoes")
                    words[i] = "Photos";
            return string.Join(" ", words);
        }
    }
}