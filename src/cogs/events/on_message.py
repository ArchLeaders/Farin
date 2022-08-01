from config import BOT
from nextcord import Message
from nextcord.ext import commands
from utils import load_json


class OnMessageCog(commands.Cog):
    """Message responce commands"""

    @BOT.event
    async def on_message(message: Message) -> None:

        if message.author == BOT.user:
            return

        system_vars = {"@author": f"<@{message.author.id}>"}

        def in_msg(words: list) -> bool:
            return any(word in message.content.lower() for word in words)

        farin = load_json("farin")
        key = "Any"

        if in_msg([f"<@{BOT.user.id}>"]):
            key = "Farin"

        for _, words in farin[key].items():
            if any(word in message.content.lower() for word in words[0]):

                msg = words[1][0]
                for _key, _value in system_vars.items():
                    msg = msg.replace(_key, _value)

                await message.channel.send(msg, reference=message, mention_author=False)
                return

        await BOT.process_commands(message)


def setup(bot: commands.Bot):
    bot.add_cog(OnMessageCog(bot))
