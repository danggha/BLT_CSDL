
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Drawing;

namespace BotKCuaHa
{

    public partial class bot : Form
    {

        public TelegramBotClient botClient;
        
        public long chatId; 

        int logCounter = 0;

        void AddLog(string msg)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.BeginInvoke((MethodInvoker)delegate ()
                {
                    AddLog(msg);
                });
            }
            else
            {
                logCounter++;
                if (logCounter > 100)
                {
                    txtLog.Clear();
                    logCounter = 0;
                }
                txtLog.AppendText(msg + "\r\n");
            }
            Console.WriteLine(msg);
        }

        /// <summary>
        /// 
        /// </summary>
        public bot()
        {
            InitializeComponent();
            
            string token = "5800732194:AAFtX0kWuejKPBiYxSQO9YdPnXzQ34YsH9E";

            

            botClient = new TelegramBotClient(token);  // Tạo  bot 

            CancellationTokenSource cts = new CancellationTokenSource();//kiểm soát chương trình  

            
            ReceiverOptions receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>() 
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,  //hàm xử lý và trả về kq
                pollingErrorHandler: HandlePollingErrorAsync,  //xử lý lỗi 
                receiverOptions: receiverOptions,  
                cancellationToken: cts.Token    
                                                
            );

            Task<User> me = botClient.GetMeAsync(); 
            
            AddLog($"Thằng bot: @{me.Result.Username}");

            
            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                bool ok = false;
                
                Telegram.Bot.Types.Message message = null; 

                
                if (update.Message != null)  
                {
                    
                    message = update.Message;   
                    ok = true;
                }
               
                if (update.EditedMessage != null)
                {
                    message = update.EditedMessage;
                    ok = true;
                }

               
                if (!ok || message == null) return; //thoát ngay

                string messageText = message.Text;
                if (messageText == null) return;  

                chatId = message.Chat.Id;  //id của người chát với bot

                AddLog($"{chatId}: {messageText}");  //show lên để xem -> chứ k phải gửi về telegram

                string reply = "";  //đây là text trả lời

                string messLow = messageText.ToLower(); 

               

                // 1. khi hỏi về thầy Cốp:
                if (messLow.StartsWith("gv"))
                {
                    reply = "FeedBack Giáo viên:🥲 Thầy đẹp trai quá!";
                }
                
                else if (messLow.StartsWith("tk "))
                {
                    string tensv = messageText.Substring(3);
                    TimKiemDB tkDB = new TimKiemDB();
                    reply = tkDB.timSV("%" + tensv.Replace(' ', '%') + "%");
                }


                else 
                {
                    reply = "🤡Sao sao: " + messageText;
                }


                // ----------- KẾT THÚC XỬ LÝ -----------------------------------------------------------------------
                AddLog(reply); 


                Telegram.Bot.Types.Message sentMessage = await botClient.SendTextMessageAsync(
                          
                           chatId: chatId, 
                           text: reply,   
                           parseMode: ParseMode.Html  
                      );

            }

           
            Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
               
                Console.WriteLine("Looi roi anh ouwi");
                AddLog("----       Lỗi rồi -> K rõ lỗi j  -----------");
                return Task.CompletedTask;
            }
        }

        private void formBot_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}

////commmwnt
