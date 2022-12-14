from config import BOT, ROLE_ADMIN, ROLE_MODERATOR
from nextcord import Message, TextChannel
from nextcord.ext import commands
from utils import has_role


class FarinShell(commands.Cog):
    """Farin shell commands"""

    def __init__(self, bot: commands.Bot):
        self.bot = bot
        self.channel: TextChannel = None

    @commands.Cog.listener()
    async def on_message(self, message: Message) -> None:

        if message.author == BOT.user:
            return

        if message.channel.id == 1003417004742561912:
            if message.content.startswith(">goto"):

                if not await has_role(message.author, [ROLE_ADMIN], message):
                    return

                channel_id = int(
                    message.content.split("#")[1].replace(">", "")
                    if "#" in message.content
                    else 0
                )
                self.channel = BOT.get_channel(channel_id)
                await message.channel.send(f"Shell hooked to <#{channel_id}>")
                return

            try:
                await self.channel.send(message.content)
            except:
                pass


def setup(bot: commands.Bot):
    bot.add_cog(FarinShell(bot))
