using System.Collections.Generic;

namespace WordMaster.Core
{
    /// <summary>
    /// A set of all languages that localized strings can be translated to.
    /// Loosely based on ISO 639-1 two letter language codes.
    /// </summary>
    public enum Language
    {
        Afar,
        Abkhazian,
        Avestan,
        Afrikaans,
        Akan,
        Amharic,
        Aragonese,
        Arabic,
        Assamese,
        Avaric,
        Aymara,
        Azerbaijani,
        Bashkir,
        Belarusian,
        Bulgarian,
        Bihari,
        Bislama,
        Bambara,
        Bengali,
        Tibetan,
        Breton,
        Bosnian,
        Catalan,
        Chechen,
        Chamorro,
        Corsican,
        Cree,
        Czech,
        ChurchSlavic,
        Chuvash,
        Welsh,
        Danish,
        German,
        Maldivian,
        Bhutani,
        Ewe,
        Greek,
        EnglishUK,
        EnglishUS,
        Esperanto,
        Spanish,
        Estonian,
        Basque,
        Persian,
        Fulah,
        Finnish,
        Fijian,
        Faroese,
        French,
        WesternFrisian,
        Irish,
        ScottishGaelic,
        Galician,
        Guarani,
        Gujarati,
        Manx,
        Hausa,
        Hebrew,
        Hindi,
        HiriMotu,
        Croatian,
        Haitian,
        Hungarian,
        Armenian,
        Herero,
        Interlingua,
        Indonesian,
        Interlingue,
        Igbo,
        SichuanYi,
        Inupiak,
        Ido,
        Icelandic,
        Italian,
        Inuktitut,
        Japanese,
        Javanese,
        Georgian,
        Kongo,
        Kikuyu,
        Kuanyama,
        Kazakh,
        Kalaallisut,
        Cambodian,
        Kannada,
        Korean,
        Kanuri,
        Kashmiri,
        Kurdish,
        Komi,
        Cornish,
        Kirghiz,
        Latin,
        Luxembourgish,
        Ganda,
        Limburgish,
        Lingala,
        Laotian,
        Lithuanian,
        LubaKatanga,
        Latvian,
        Malagasy,
        Marshallese,
        Maori,
        Macedonian,
        Malayalam,
        Mongolian,
        Moldavian,
        Marathi,
        Malay,
        Maltese,
        Burmese,
        Nauru,
        NorwegianBokmal,
        Ndebele,
        Nepali,
        Ndonga,
        Dutch,
        NorwegianNynorsk,
        Norwegian,
        Navaho,
        Nyanja,
        Provencal,
        Ojibwa,
        Oromo,
        Oriya,
        Ossetic,
        Punjabi,
        Pali,
        Polish,
        Pushto,
        Portuguese,
        Quechua,
        Romansh,
        Kirundi,
        Romanian,
        Russian,
        Kinyarwanda,
        Sanskrit,
        Sardinian,
        Sindhi,
        NorthernSami,
        Sangro,
        Sinhalese,
        Slovak,
        Slovenian,
        Samoan,
        Shona,
        Somali,
        Albanian,
        Serbian,
        Swati,
        Sesotho,
        Sundanese,
        Swedish,
        Swahili,
        Tamil,
        Telugu,
        Tajik,
        Thai,
        Tigrinya,
        Turkmen,
        Tagalog,
        Setswana,
        Tonga,
        Turkish,
        Tsonga,
        Tatar,
        Twi,
        Tahitian,
        Uighur,
        Ukrainian,
        Urdu,
        Uzbek,
        Venda,
        Vietnamese,
        Volapuk,
        Walloon,
        Wolof,
        Xhosa,
        Yiddish,
        Yoruba,
        Zhuang,
        Chinese,
        Zulu,
        Count // Number of entries
    };

    public class WordSet
    {
        public Language mLanguage;
        public IDictionary<string, string> mWords;

        public WordSet(Language language)
        {
            mLanguage = language;
            mWords = new Dictionary<string, string>();
        }

        public WordSet(Language language, IDictionary<string, string> selectedDictionary)
        {
            mLanguage = language;
            mWords = selectedDictionary;
        }
    }

    public class WordCollection
    {
        public string mName;
        public Language mDefaultLanguage;
        public IDictionary<Language, WordSet> mWordSets;

        public WordCollection(string name, Language defaultLanguage)
        {
            mName = name;
            mDefaultLanguage = defaultLanguage;
            mWordSets = new Dictionary<Language, WordSet>();
        }

        public WordCollection(string name, Language defaultLanguage, IDictionary<Language, WordSet> selectedDictionary)
        {
            mName = name;
            mDefaultLanguage = defaultLanguage;
            mWordSets = selectedDictionary;
        }
    }

    public class WordStore
    {
        public IDictionary<string, WordCollection> mWordCollections;

        public WordStore()
        {
            mWordCollections = new Dictionary<string, WordCollection>();
        }

        public WordStore(IDictionary<string, WordCollection> selectedDictionary )
        {
            mWordCollections = selectedDictionary;
        }
    }
}