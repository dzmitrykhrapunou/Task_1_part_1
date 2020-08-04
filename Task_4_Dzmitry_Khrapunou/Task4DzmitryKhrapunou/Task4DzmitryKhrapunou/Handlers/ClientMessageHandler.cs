using System.Collections.Generic;

namespace Task4DzmitryKhrapunou
{
    public class ClientMessageHandler
    {
        /// <summary>
        /// Delegate
        /// </summary>
        /// <param name="msgText">Message</param>
        public delegate string GetMessage(string msgText);

         /// <summary>
         /// Event
         /// </summary>
         public event GetMessage MessageEvent;

        /// <summary>
        /// Invoke event
        /// </summary>
        /// <param name="message">Message</param>
        public string InvokeMessageEvent(string message)
         {
             return MessageEvent(message);
         }

        /// <summary>
        /// Russian dictionary to translate message
        /// </summary>
        public readonly Dictionary<char, string> RussianDictionary = new Dictionary<char, string>()
        {
            {'a', "a"},   {'б', "b"},  {'в', "v"},   {'г', "g"},  {'д', "d"},  {'е', "e"},
            {'ё', "yo"},  {'ж', "zh"}, {'з', "z"},   {'и', "i"},  {'й', "j"},  {'к', "k"},
            {'л', "l"},   {'м', "m"},  {'н', "n"},   {'о', "o"},  {'п', "p"},  {'р', "r"},
            {'с', "s"},   {'т', "t"},  {'у', "u"},   {'ф', "f"},  {'x', "h"},  {'ц', "c"},
            {'ч', "ch"},  {'ш', "sh"}, {'щ', "sch"}, {'ъ', ""},   {'ы', "yi"}, {'ь', ""},
            {'э', "ye"},  {'ю', "yu"}, {'я', "ya"}
        };

        /// <summary>
        /// English dictionary to translate message
        /// </summary>
        public readonly Dictionary<string, char> EnglishDictionary = new Dictionary<string, char>()
        {
            {"a", 'a'},  {"b", 'б'},  {"v", 'в'},   {"g", 'г'},  {"d", 'д'},  {"e", 'е'},
            {"yo", 'ё'}, {"zh", 'ж'}, {"z", 'з'},   {"i", 'и'},  {"j", 'й'},  {"k", 'к'},
            {"l", 'л'},  {"m", 'м'},  {"n", 'н'},   {"o", 'о'},  {"p", 'п'},  {"r", 'р'},
            {"s", 'с'},  {"t", 'т'},  {"u", 'у'},   {"f", 'ф'},  {"h", 'x'},  {"c", 'ц'},
            {"ch", 'ч'}, {"sh", 'ш'}, {"sch", 'щ'}, {"yi", 'ы'}, {"ye", 'э'}, {"yu", 'ю'},
            {"ya", 'я'}

        };        
    }
}
