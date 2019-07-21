using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace UseDict
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static readonly string token = "889503993:AAFFgqXesJwe90LC1wZlopdhXn8WuLnJpaw";
        static TelegramBotClient bot = new TelegramBotClient(token);
        static model.UseDictBotDBEntities1 db = new model.UseDictBotDBEntities1();

        private void Bot_OnMessageRecived(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            try
            {
                if (e.Message.Type == MessageType.Text)
                {
                    if (e.Message.Text == "/start")
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id,
    @"
✋سلام من ربات UseDict  هستم ❣️
✅ من مترجم و دوست شما هستم
✅ من می توانم کلمات شما را به فارسی ترجمه کنم
✅ من می توانم متن های شما را به فارسی ترجمه کنم

برای ارتباط با پشتیبانی، به آیدی زیر پیام بدین
@HeliosCoder
+=+ - +=+ - +=+ - +=+ - +=+
✋Hi , I am UseDict Bot❣️
✅ I am translator and your friend 
✅ I can translate your words to Persian
✅ I can translate your texts to Persian
To contact a support, submit a message to the following ID
@HeliosCoder
"
                                                                    , replyMarkup: KeyBoard.MainKey());
                        var User = (from a in db.tbl_UseDict where a.ChatID == e.Message.Chat.Id select a).Count();
                        if (User == 0)
                        {
                            model.tbl_UseDict tbl = new model.tbl_UseDict()
                            {
                                ChatID = e.Message.Chat.Id,
                            };
                            db.tbl_UseDict.Add(tbl);
                            db.SaveChanges();
                        }
                    }
                    else if (e.Message.Text == "◀️بازگشت")
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id,
    @"
✋سلام من ربات UseDict  هستم ❣️
✅ من مترجم و دوست شما هستم
✅ من می توانم کلمات شما را به فارسی ترجمه کنم
✅ من می توانم متن های شما را به فارسی ترجمه کنم

برای ارتباط با پشتیبانی، به آیدی زیر پیام بدین
@HeliosCoder
"
                                                , replyMarkup: KeyBoard.MainKeyFa());
                    }
                    else if (e.Message.Text == "Back◀️")
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id,
    @"
✋Hi , I am UseDict Bot❣️
✅ I am translator and your friend 
✅ I can translate your words to Persian
✅ I can translate your texts to Persian

To contact a support, submit a message to the following ID
@HeliosCoder
"
                                                , replyMarkup: KeyBoard.MainKeyEn());
                    }

                    else if (e.Message.Text == "انگلیسی🇬🇧 به فارسی󠁧󠁢󠁥󠁮󠁧󠁿🇮🇷" || e.Message.Text == "English🇬🇧 To Persian🇮🇷" || e.Message.Text == "🇬🇧English To Persian🇮🇷")
                    {
                        var User = (from a in db.tbl_UseDict where a.ChatID == e.Message.Chat.Id select a).FirstOrDefault();
                        User.Source = "en";
                        User.Target = "fa";
                        db.Entry(User).State = EntityState.Modified;
                        db.SaveChanges();
                        bot.SendTextMessageAsync(e.Message.Chat.Id,
    @"
Enter your word or words
Or
Enter your text
"
    , replyMarkup: KeyBoard.BackEn());
                    }
                    else if (e.Message.Text == "فارسی🇮🇷 به انگلیسی🇬🇧󠁧󠁢󠁥󠁮󠁧󠁿" || e.Message.Text == "Persian🇮🇷 To English🇬🇧" || e.Message.Text == "🇬🇧فارسی به انگلیسی🇮🇷")
                    {
                        var User = (from a in db.tbl_UseDict where a.ChatID == e.Message.Chat.Id select a).FirstOrDefault();
                        User.Source = "fa";
                        User.Target = "en";
                        db.Entry(User).State = EntityState.Modified;
                        db.SaveChanges();
                        bot.SendTextMessageAsync(e.Message.Chat.Id,
    @"
کلمه یا کلمات خود را وارد کنید
یا
متن خود را وارد کنید
"
    , replyMarkup: KeyBoard.BackFa());
                    }
                    else
                    {
                        var User = (from a in db.tbl_UseDict
                                    where a.ChatID == e.Message.Chat.Id
                                    select a).FirstOrDefault();
                        if (User.Source == "en" && User.Target == "fa")
                        {
                            bot.SendTextMessageAsync(e.Message.Chat.Id, Trans.EnToFa(e.Message.Text));
                        }
                        else if (User.Source == "fa" && User.Target == "en")
                        {
                            bot.SendTextMessageAsync(e.Message.Chat.Id, Trans.FaToEn(e.Message.Text));
                        }
                    }
                }
            }
            catch { }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bot.OnMessage += Bot_OnMessageRecived;
            bot.StartReceiving();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
