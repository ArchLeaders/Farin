import nextcord

from utils import load_json
from nextcord.ext import commands


class CensorCog(commands.Cog):
    """Handles and censors content posted by users"""

    def __init__(self, bot: commands.Bot):
        self.bot = bot

    @commands.Cog.listener()
    async def on_message(self, message: nextcord.Message):

        # return if the message is from the bot
        if message.author.bot == True:
            return

        # set the different flags
        censor = False
        flag = False
        censored_db: dict = load_json("censored")

        for block, level in censored_db.items():

            if bytes.fromhex(block).decode("utf-8") in message.content.lower().replace(
                " ", ""
            ).replace("*", "").replace("_", "").replace("\\", "").replace("/", ""):

                if level == 1:
                    flag = not censor
                elif censored_db[block] == 2:
                    censor = True
                    flag = False

        if censor == True:
            await message.channel.send(
                "*Do be silent, we mustn't speak such language before master Benji*",
                reference=message,
                mention_author=False,
            )
            return

        elif flag == True:
            await message.channel.send(
                "https://tenor.com/view/captain-america-marvel-avengers-gif-14328153",
                reference=message,
                mention_author=False,
            )
            return


def setup(bot: commands.Bot):
    bot.add_cog(CensorCog(bot))
