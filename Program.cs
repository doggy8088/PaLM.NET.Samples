using PaLM.NET;

var apikey = Environment.GetEnvironmentVariable("GOOGLE_PALM_APIKEY");

using var palm = new PaLMClient(apikey);

var textPromptOptions = new TextOption()
{
    Temperature = 0,
    TopK = 40,
    TopP = 0.95,
    CandidateCount = 1,
    MaxOutputTokens = 1024
};

textPromptOptions.Prompt.Text = """
Who are all the people and places named in the paragraph below? Respond in JSON.

Paragraph: Apollo 11 launched from Cape Kennedy on July 16, 1969, carrying Commander Neil Armstrong, Command Module Pilot Michael Collins and Lunar Module Pilot Edwin "Buzz" Aldrin into an initial Earth-orbit of 114 by 116 miles. An estimated 650 million people watched Armstrong's televised image and heard his voice describe the event as he took "...one small step for a man, one giant leap for mankind" on July 20, 1969.
""";

var text_result = await palm.GenerateTextAsync(textPromptOptions);

Console.WriteLine(text_result.Candidates[0].Output);