using System;
using System.Collections.Generic;

/**
Simple "Eliza" program.

The program appears to have a conversation with the user, using string replacement
and basic parsing, to give the appearance of understanding what the user types.

The responses are based on a Python program by Joe Strout, Jeff Epler and Jez Higgins.

Original available at https://github.com/jezhiggins/eliza.py

Licensed under the terms of the MIT License.
 */

namespace ElizaIsSilly
{
    class Doctor
    {
        static List<string> matches = new List<string> {
                                                    "life",
                                                    "i need",
                                                    "why don't", "why can't",
                                                    "i can", "i am", "i'm",
                                                    "are you",
                                                    "what", "how",
                                                    "because",
                                                    "sorry",
                                                    "i think",
                                                    "friend",
                                                    "yes",
                                                    "computer",
                                                    "is it", "it is",
                                                    "can you", "can i",
                                                    "you are", "you're",
                                                    "i don't",
                                                    "i feel", "i have", "i've",
                                                    "i would",
                                                    "is there",
                                                    "my",
                                                    "you",
                                                    "why",
                                                    "i want",
                                                    "mother", "father", "child",
                                                    "?",
                                                    "hello", "hi", "hey",
                                                    "quit"
                                                };

        static Dictionary<string, string> reflections = new Dictionary<string, string> {
                                                                                   {" am", " are"},
                                                                                   {" was", " were"},
                                                                                   {"I ", "you "},
                                                                                   {"I'd", "you would"},
                                                                                   {"I've", "you have"},
                                                                                   {"I'll", "you will"},
                                                                                   {"my ", "your "},
                                                                                   {"are ", "am "},
                                                                                   {"you've", "I have"},
                                                                                   {"you'll", "I will"},
                                                                                   {"your", "my"},
                                                                                   {"yours", "mine"},
                                                                                   {"you", "me"},
                                                                                   {"me", "you"},
                                                                                   {"I'm", "you're"}
                                                                                };

        static List<List<string>> responses = new List<List<string>> {
            new List<string> {"Life? Don't talk to me about life.", "At least you have a life, I'm stuck inside this computer.", "Life can be good. Remember, 'this, too, will pass'."},
            new List<string> {"Why do you need %1?", "Would it really help you to get %1?", "Are you sure you need %1?"},
            new List<string> {"Do you really think I don't %1?", "Perhaps eventually I will %1.", "Do you really want me to %1?"},
            new List<string> {"Do you think you should be able to %1?", "If you could %1, what would you do?", "I don't know -- why can't you %1?", "Have you really tried?"},
            new List<string> {"How do you know you can't %1?", "Perhaps you could %1 if you tried.", "What would it take for you to %1?"},
            new List<string> {"Did you come to me because you are %1?", "How long have you been %1?", "How do you feel about being %1?"},
            new List<string> {"How does being %1 make you feel?", "Do you enjoy being %1?", "Why do you tell me you're %1?", "Why do you think you're %1?"},
            new List<string> {"Why does it matter whether I am %1?", "Would you prefer it if I were not %1?", "Perhaps you believe I am %1.", "I may be %1 -- what do you think?"},
            new List<string> {"Why do you ask?", "How would an answer to that help you?", "What do you think?"},
            new List<string> {"How do you suppose?", "Perhaps you can answer your own question.", "What is it you're really asking?"},
            new List<string> {"Is that the real reason?", "What other reasons come to mind?", "Does that reason apply to anything else?", "If %1, what else must be true?"},
            new List<string> {"There are many times when no apology is needed.", "What feelings do you have when you apologize?"},
            new List<string> {"Do you doubt %1?", "Do you really think so?", "But you're not sure %1?"},
            new List<string> {"Tell me more about your friends.", "When you think of a friend, what comes to mind?", "Why don't you tell me about a childhood friend?"},
            new List<string> {"You seem quite sure.", "OK, but can you elaborate a bit?"},
            new List<string> {"Are you really talking about me?", "Does it seem strange to talk to a computer?", "How do computers make you feel?", "Do you feel threatened by computers?"},
            new List<string> {"Do you think it is %1?", "Perhaps it is %1 -- what do you think?", "If it were %1, what would you do?", "It could well be that %1."},
            new List<string> {"You seem very certain.", "If I told you that it probably isn't %1, what would you feel?"},
            new List<string> {"What makes you think I can't %1?", "If I could %1, then what?", "Why do you ask if I can %1?"},
            new List<string> {"Perhaps you don't want to %1.", "Do you want to be able to %1?", "If you could %1, would you?"},
            new List<string> {"Why do you think I am %1?", "Does it please you to think that I'm %1?", "Perhaps you would like me to be %1.", "Perhaps you're really talking about yourself?"},
            new List<string> {"Why do you say I am %1?", "Why do you think I am %1?", "Are we talking about you, or me?"},
            new List<string> {"Don't you really %1?", "Why don't you %1?", "Do you want to %1?"},
            new List<string> {"Good, tell me more about these feelings.", "Do you often feel %1?", "When do you usually feel %1?", "When you feel %1, what do you do?"},
            new List<string> {"Why do you tell me that you've %1?", "Have you really %1?", "Now that you have %1, what will you do next?"},
            new List<string> {"Why do you tell me that you've %1?", "Have you really %1?", "Now that you have %1, what will you do next?"},
            new List<string> {"Could you explain why you would %1?", "Why would you %1?", "Who else knows that you would %1?"},
            new List<string> {"Do you think there is %1?", "It's likely that there is %1.", "Would you like there to be %1?"},
            new List<string> {"I see, your %1.", "Why do you say that your %1?", "When you're %1, how do you feel?"},
            new List<string> {"We should be discussing you, not me.", "Why do you say that about me?", "Why do you care whether I %1?"},
            new List<string> {"Why don't you tell me the reason why %1?", "Why do you think %1?"},
            new List<string> {"What would it mean to you if you got %1?", "Why do you want %1?", "What would you do if you got %1?", "If you got %1, then what would you do?"},
            new List<string> {"Tell me more about your mother.", "What was your relationship with your mother like?", "How do you feel about your mother?", "How does this relate to your feelings today?", "Good family relations are important."},
            new List<string> {"Tell me more about your father.", "How did your father make you feel?", "How do you feel about your father?", "Does your relationship with your father relate to your feelings today?", "Do you have trouble showing affection with your family?"},
            new List<string> {"Did you have close friends as a child?", "What is your favorite childhood memory?", "Do you remember any dreams or nightmares from childhood?", "Did the other children sometimes tease you?", "How do you think your childhood experiences relate to your feelings today?"},
            new List<string> {"Why do you ask that?", "Please consider whether you can answer your own question.", "Perhaps the answer lies within yourself?", "Why don't you tell me?"},
            new List<string> {"Hello... I'm glad you could drop by today.", "Hello there... how are you today?", "Hello, how are you feeling today?"},
            new List<string> {"Hi... I'm glad you could drop by today.", "Hi there... how are you today?", "Hi, how are you feeling today?"},
            new List<string> {"Hey... I'm glad you could drop by today.", "Hey there... how are you today?", "Hey, how are you feeling today?"},
            new List<string> {"Thank you for talking with me.", "Good-bye.", "Thank you, that will be $150.  Have a good day!"},
            new List<string> {"Please tell me more.", "Let's change focus a bit... Tell me about your family.", "Can you elaborate on that?", "Why do you say that %1?", "I see.", "Very interesting.", "%1?", "I see.  And what does that tell you?", "How does that make you feel?", "How do you feel when you say that?"},
        };

        static Random random = new Random();

        public static string Intro()
        {
            return String.Join(Environment.NewLine,
            "I'm Eliza",
            "---------",
            "Talk to the program by typing in plain English, using normal upper-",
            "and lower-case letters and punctuation.  Enter 'quit' when done.",
            "\n",
            "Hello. How are you feeling today?");
        }

        public static string response(string userinput)
        {
            // check through the matches list, and if there's a match, strip off the match and replace with the response.
            // 
            // If the response contains %1, replace that with the Remainder of the input string.
            // Before replacing, change words in the Remainder of the input with the corresponding entry from the reflections dictionary.
            var output = "";
            string Remainder = "";
            for (var index = 0; index < matches.Count; index++)
            {
                string match = matches[index];
                var position = userinput.ToLower().IndexOf(match);
                if (position > -1)
                {
                    // found a match, delete everything up to the end of the text we found.
                    string rem = userinput.Remove(0, position + match.Length);

                    // Now replace the reflections: I -> you, etc
                    // We need to split the input into words, to avoid changing eg. me -> you then the same you -> me.
                    string[] words = rem.Split();

                    for (int i = 0; i < words.Length; i++)
                    {
                        foreach (string reflection in reflections.Keys)
                        {
                            if (words[i].Equals(reflection))
                            {
                                words[i] = reflections[reflection];
                                break;
                            }
                        }
                    }
                    // Now join the words back up again.
                    rem = String.Join(" ", words);

                    // Strip leading and trailing spaces.
                    Remainder = rem.Trim();

                    var randomIndex = random.Next(0, responses[index].Count);
                    output = responses[index][randomIndex];
                    break;
                }
            }

            // If there wasn't a match, use the last item in the responses list.
            if (output == "")
            {
                int randomIndex = random.Next(0, responses[responses.Count - 1].Count);
                output = responses[responses.Count - 1][randomIndex];
            }

            // Now substitute the modified input for %1 (if it exists) in the response.
            output = output.Replace("%1", Remainder);
            return output;
        }
    }
}
