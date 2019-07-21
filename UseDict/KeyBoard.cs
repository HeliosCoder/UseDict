using Telegram.Bot.Types.ReplyMarkups;

namespace UseDict
{
    class KeyBoard
    {
        private static KeyboardButton key(string text)
        {
            KeyboardButton kb = new KeyboardButton(text);
            return kb;
        }
        public static ReplyKeyboardMarkup MainKeyFa()
        {
            string btn1 = "فارسی🇮🇷 به انگلیسی🇬🇧󠁧󠁢󠁥󠁮󠁧󠁿";
            string btn2 = "انگلیسی🇬🇧 به فارسی󠁧󠁢󠁥󠁮󠁧󠁿🇮🇷";

            ReplyKeyboardMarkup rpl = new ReplyKeyboardMarkup();

            KeyboardButton[] row1 = new KeyboardButton[] { key(btn1) };
            KeyboardButton[] row2 = new KeyboardButton[] { key(btn2) };

            rpl.Keyboard = new KeyboardButton[][] { row1,row2 };
            rpl.ResizeKeyboard = true;
            return rpl;
        }
        public static ReplyKeyboardMarkup MainKeyEn()
        {
            string btn1 = "Persian🇮🇷 To English🇬🇧";
            string btn2 = "English🇬🇧 To Persian🇮🇷";

            ReplyKeyboardMarkup rpl = new ReplyKeyboardMarkup();

            KeyboardButton[] row1 = new KeyboardButton[] { key(btn1) };
            KeyboardButton[] row2 = new KeyboardButton[] { key(btn2) };

            rpl.Keyboard = new KeyboardButton[][] { row1, row2 };
            rpl.ResizeKeyboard = true;
            return rpl;
        }
        public static ReplyKeyboardMarkup MainKey()
        {
            string btn1 = string.Format("🇬🇧فارسی" + " به "+ "انگلیسی🇮🇷");
            string btn2 = string.Format("🇬🇧English" + " To " + "Persian🇮🇷");

            ReplyKeyboardMarkup rpl = new ReplyKeyboardMarkup();

            KeyboardButton[] row1 = new KeyboardButton[] { key(btn1) };
            KeyboardButton[] row2 = new KeyboardButton[] { key(btn2) };

            rpl.Keyboard = new KeyboardButton[][] { row1, row2 };
            rpl.ResizeKeyboard = true;
            return rpl;
        }
        public static ReplyKeyboardMarkup BackEn()
        {

            ReplyKeyboardMarkup rpl = new ReplyKeyboardMarkup();
            KeyboardButton[] row1 = new KeyboardButton[] { key("Back◀️") };

            rpl.Keyboard = new KeyboardButton[][] { row1 };
            rpl.ResizeKeyboard = true;
            return rpl;
        }
        public static ReplyKeyboardMarkup BackFa()
        {

            ReplyKeyboardMarkup rpl = new ReplyKeyboardMarkup();
            KeyboardButton[] row1 = new KeyboardButton[] { key("◀️بازگشت") };

            rpl.Keyboard = new KeyboardButton[][] { row1 };
            rpl.ResizeKeyboard = true;
            return rpl;
        }
    }
}
