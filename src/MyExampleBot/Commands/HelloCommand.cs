using System.Threading.Tasks;
using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace MyExampleBot.Commands
{
    public class HelloCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }
        public string ArgsInput { get; set; }
    }
    public class HelloCommand : CommandBase<HelloCommandArgs>
    {
        public HelloCommand() : base("hello")
        {
            
        }
        public override async Task<UpdateHandlingResult> HandleCommand(Update update, HelloCommandArgs args)
        {
            string replyText = string.IsNullOrWhiteSpace(args.ArgsInput) ? "Hello Who?" : args.ArgsInput;

            await Bot.Client.SendTextMessageAsync(
                update.Message.Chat.Id,
                replyText,
                replyToMessageId: update.Message.MessageId);

            return UpdateHandlingResult.Handled;
        }
    }
}