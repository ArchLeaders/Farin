from config import IMG_HELP, COLOR_HELP
from typing import Optional, Set
from nextcord import Message
from nextcord.ext import commands

from config import BOT


class OnMessageCog(commands.Cog):
    """Message responce commands"""

    @BOT.event
    async def on_message(message: Message) -> None:

        if message.author == BOT.user:
            return

        def in_message(words: list) -> bool:
            return any(word in message.content.lower() for word in words)

        if in_message([f"<@{BOT.user.id}>"]):
            await message.channel.send(
                "Hold on not yet! :sweat_smile:\nI'm still being worked on."
            )
            return

        if in_message(["crying"]):
            await message.channel.send(
                "**drinks tears*",
                reference=message,
                mention_author=False,
            )
            return

        if in_message(["murder", "kill", "death"]):
            await message.channel.send(
                "**interest peaks*", reference=message, mention_author=False
            )
            return


def setup(bot: commands.Bot):
    bot.add_cog(OnMessageCog(bot))
