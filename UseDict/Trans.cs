using System;
using System.Net;
using System.Text;

namespace UseDict
{
    class Trans
    {

        public static string EnToFa(string input)
        {
            string translation = string.Empty;
            try
            {
                // Download translation

                string url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
                                            "en",
                                            "fa",
                                           input);
                string result = string.Empty;
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 " +
                                                    "(KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                    result = wc.DownloadString(url);
                }
                // Get translated text
                // Get phrase collection
                string text = result;
                int index = text.IndexOf(string.Format(",,\"{0}\"", "en"));
                if (index == -1)
                {
                    // Translation of single word
                    int startQuote = text.IndexOf('\"');
                    if (startQuote != -1)
                    {
                        int endQuote = text.IndexOf('\"', startQuote + 1);
                        if (endQuote != -1)
                        {
                            translation = text.Substring(startQuote + 1, endQuote - startQuote - 1);
                        }
                    }
                }
                else
                {
                    // Translation of phrase
                    text = text.Substring(0, index);
                    text = text.Replace("],[", ",");
                    text = text.Replace("]", string.Empty);
                    text = text.Replace("[", string.Empty);
                    text = text.Replace("\",\"", "\"");
                }

                translation = translation.Trim();
                translation = translation.Replace(" ?", "?");
                translation = translation.Replace(" !", "!");
                translation = translation.Replace(" ,", ",");
                translation = translation.Replace(" .", ".");
                translation = translation.Replace(" ;", ";");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            // Return result
            return translation;
        }


        public static string FaToEn(string input)
        {
            string translation = string.Empty;
            try
            {
                // Download translation

                string url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
                                            "fa",
                                            "en",
                                           input);
                string result = string.Empty;
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 " +
                                                    "(KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                    result = wc.DownloadString(url);
                }
                // Get translated text
                // Get phrase collection
                string text = result;
                int index = text.IndexOf(string.Format(",,\"{0}\"", "en"));
                if (index == -1)
                {
                    // Translation of single word
                    int startQuote = text.IndexOf('\"');
                    if (startQuote != -1)
                    {
                        int endQuote = text.IndexOf('\"', startQuote + 1);
                        if (endQuote != -1)
                        {
                            translation = text.Substring(startQuote + 1, endQuote - startQuote - 1);
                        }
                    }
                }
                else
                {
                    // Translation of phrase
                    text = text.Substring(0, index);
                    text = text.Replace("],[", ",");
                    text = text.Replace("]", string.Empty);
                    text = text.Replace("[", string.Empty);
                    text = text.Replace("\",\"", "\"");
                }

                translation = translation.Trim();
                translation = translation.Replace(" ?", "?");
                translation = translation.Replace(" !", "!");
                translation = translation.Replace(" ,", ",");
                translation = translation.Replace(" .", ".");
                translation = translation.Replace(" ;", ";");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            // Return result
            return translation;
        }
    }
}
