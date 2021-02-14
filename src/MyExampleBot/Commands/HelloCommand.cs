using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace MyExampleBot.Commands
{
    public class HelloCommandArgs : ICommandArgs
    {
        public string RawInput { get; set; }
        public string ArgsInput { get; set; }

        public override string ToString()
        {
            return new StringBuilder()
                .Append("RawInput : ").AppendLine(RawInput)
                .Append("ArgsInput : ").AppendLine(ArgsInput)
                .ToString();
        }
    }
    public class HelloCommand : CommandBase<HelloCommandArgs>
    {
        private readonly ILogger<HelloCommand> logger;
        public HelloCommand(ILogger<HelloCommand> logger) : base("hello")
        {
            this.logger = logger;
        }
        public override async Task<UpdateHandlingResult> HandleCommand(Update update, HelloCommandArgs args)
        {
            logger.LogInformation($"Command received {args} with message {update.Message}");
            string replyText = string.IsNullOrWhiteSpace(args.ArgsInput) ? "Hello Who?" : args.ArgsInput;

            await Bot.Client.SendTextMessageAsync(
                update.Message.Chat.Id,
                replyText,
                replyToMessageId: update.Message.MessageId);

            return UpdateHandlingResult.Handled;
        }
    }
}