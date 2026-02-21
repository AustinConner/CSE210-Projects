using System.Text.Json.Serialization;

public class ScriptureJson
{
    [JsonPropertyName("volume_title")]
    public string VolumeTitle { get; set; }

    [JsonPropertyName("book_title")]
    public string BookTitle { get; set; }

    [JsonPropertyName("book_short_title")]
    public string BookShortTitle { get; set; }

    [JsonPropertyName("chapter_number")]
    public int ChapterNumber { get; set; }

    [JsonPropertyName("verse_number")]
    public int VerseNumber { get; set; }

    [JsonPropertyName("verse_title")]
    public string VerseTitle { get; set; }

    [JsonPropertyName("verse_short_title")]
    public string VerseShortTitle { get; set; }

    [JsonPropertyName("scripture_text")]
    public string Text { get; set; }
}